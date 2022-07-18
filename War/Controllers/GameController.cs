using Microsoft.AspNetCore.Mvc;
using War.Data;
using War.Domain;
using War.Factories;
using War.Tasks;

namespace War.Controllers
{
    /**
     * Controller for Game logic like gathering each accounts data to show on grid and indifidual data
     */
    public class GameController : Controller
    {
        //database for handling the card and the players data
        private readonly ApplicationDbContext _db;
        //database for the login and registering new players/users
        private readonly WarDBContext _wdb;
        private DataObjectFactory _factory = new DataObjectFactory();
        private PlayerTask _playerTask = new PlayerTask();
        //constructor
        public GameController(ApplicationDbContext db, WarDBContext wdb)
        {
            _wdb = wdb;
            _db = db;
        }
        //dispalying all the data on the game grid
        public IActionResult GameGrid()
        {
            IEnumerable<Player> objPlayerData = _db.Players;
            return View(objPlayerData);
        }
        //post action to get all the data that the users connected to
        [HttpPost]
        public IActionResult GameHistory(String player)
        {
            IEnumerable<Player> objPlayerData = _db.Players.Where(x => x.Username.Contains(player));
            return Json(objPlayerData.ToList());
        }
        //for future use "Multiplayer"
        [HttpGet]
        public JsonResult GetCards()
        {
            using (var repository = _factory.CreateRepository("Default"))
            {
                var cards = _playerTask.GetAllCards(repository);
                return new JsonResult(Ok(cards));
            }
        }
        [HttpGet]
        //public JsonResult GetPlayerCards()
        //{
        //    IEnumerable<Card> objCardData = _db.Cards;
        //    return new JsonResult(Ok(objCardData.ToList().Shuffle()));
        //}
        public IActionResult CreatePlayer()
        {
            IEnumerable<Player> objPlayerData = _db.Players;
            return View(objPlayerData);
        }


    }


}
