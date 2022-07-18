// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 var x = document.getElementById("myAudio");
x.play();
x.volume = 0.2;
                                
//test Game view

$(document).ready(function () {
    const clicksound = new Audio();
    clicksound.src = "/sounds/click.mp3"
    $.ajax({
        type: "POST",
        url: "/PlayerController/Graph/",
        data: { player: name },
        success: function (data) {
            console.log(data)
            var barColor = ['#555555', '#333333']
            const labels = [
                'Wins',
                'Loses'
            ];
            new Chart("myChart",
                {
                    type: 'doughnut',
                    data: {
                        labels: labels,
                        datasets: [{
                            backgroundColor: barColor,
                            data: [data[0], data[1]]
                        }]
                    }
                }
            )
        },
        error: function (req, status, error) {
            console.log(status)
        }
    })
});

