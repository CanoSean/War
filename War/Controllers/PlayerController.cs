using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using War.Areas.Identity.Data;
using War.Data;
using War.Domain;
using War.Factories;
using War.Models;
using War.Tasks;

namespace War.Controllers
{
    /// <summary>
    /// Controller for all the Players data and Cards data.
    /// </summary>
    public class PlayerController : Controller
    {

        private readonly ILogger<PlayerController> _logger;
        private DataObjectFactory _factory = new DataObjectFactory();
        private PlayerTask _playerTask = new PlayerTask();
        /// <summary>
        /// DB for all cards and players related data
        /// </summary>
        private readonly ApplicationDbContext _db;
        /// <summary>
        /// DB for creation of new users/players
        /// </summary>
        private readonly WarDBContext _wdb;
        Card card;
        List<Card> cards;

        public PlayerController(ILogger<PlayerController> logger, ApplicationDbContext db, WarDBContext wdb)
        {
            _wdb = wdb;
            _db = db;
            _logger = logger;
        }
        /// <summary>
        /// index view
        /// </summary>
        /// <returns> view for the index page</returns>
        public IActionResult Index()
        {
            return View(cards);
        }
        /// <summary>
        /// not in use atm for multiplayer
        /// </summary>
        /// <returns>view for privacy page </returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// game view
        /// </summary>
        /// <returns>page for game </returns>
        public IActionResult Game()
        {
            return View();
        }

        // This part is all for testing before I added all the data on to the database
        //[HttpGet]
        //public JsonResult GetCards()
        //{
        //    cards = new List<Card>();

        //    cards.Add(new Card(1, "diamond", "2"));
        //    cards.Add(new Card(2, "diamond", "3"));
        //    cards.Add(new Card(3, "diamond", "4"));
        //    cards.Add(new Card(4, "diamond", "5"));
        //    cards.Add(new Card(5, "diamond", "6"));
        //    cards.Add(new Card(6, "diamond", "7"));
        //    cards.Add(new Card(7, "diamond", "8"));
        //    cards.Add(new Card(8, "diamond", "9"));
        //    cards.Add(new Card(9, "diamond", "10"));
        //    cards.Add(new Card(10, "diamond", "jack"));
        //    cards.Add(new Card(11, "diamond", "queen"));
        //    cards.Add(new Card(12, "diamond", "king"));
        //    cards.Add(new Card(13, "diamond", "ace"));


        //    return new JsonResult(Ok(cards));
        //}
        /// <summary>
        /// gets the cards from database
        /// </summary>
        /// <returns>all cards</returns>
        [HttpGet]
        public JsonResult GetCards()
        {
            using (var repository = _factory.CreateRepository("Default"))
            {
                var cards = _playerTask.GetAllCards(repository);
                return new JsonResult(Ok(cards));
            }
        }
        /// <summary>
        /// get each players card
        /// </summary>
        /// <returns> retrun specific cards that got shuffled</returns>
        [HttpGet]
        public JsonResult GetPlayerCards()
        {
            IEnumerable<Card> objCardData = _db.Cards;
            return new JsonResult(Ok(objCardData.ToList().Shuffle()));
        }

        /// <summary>
        /// this will retrun the data of game history
        /// </summary>
        /// <param name="player"></param>
        /// <returns>players game history</returns>
        [HttpPost]
        public IActionResult Record(Player player)
        {
            //_db.Players.Add(new Player(player.Wins, player.Username, player.Loses, player.GamePlayed, player.NumberOfMove, player.Enemy));
            _db.Players.Add(player);
            _db.SaveChanges();
            return new JsonResult(Ok());
        }
        /// <summary>
        /// for the graph data
        /// </summary>
        /// <param name="player"></param>
        /// <returns>wins and lose</returns>
        [HttpPost]
        public IActionResult Graph(String player)
        {
            IEnumerable<Player> objPlayerData = _db.Players.Where(x => x.Username.Contains(player));

            var wins = 0;
            var loses = 0;
            for (int i = 0; i < objPlayerData.Count(); i++)
            {
                if (objPlayerData.ToList()[i].Wins == 1 && objPlayerData.ToList()[i].Loses == 0)
                {
                    wins++;
                }
                else if(objPlayerData.ToList()[i].Loses == 1 && objPlayerData.ToList()[i].Wins == 0)
                {
                    loses++;
                }
            }
            

            var winsloses = new int[2]
            {
                wins,
                loses
            };

            return Json(winsloses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    /**
     * Inner Class that handles all the Shuffling of cards
     **/
    public static class EnumerableExtensions
    {
        private static Random rng = new Random();
        public static void ShuffleList<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (rng == null) throw new ArgumentNullException(nameof(rng));

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }

}