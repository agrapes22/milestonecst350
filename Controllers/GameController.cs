using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{
    public class GameController : Controller
    {
        static List<CellModel> cells = new List<CellModel>();
        Random rand = new Random();
        static int GRID_SIZE = 36;

        public IActionResult Index()
        {
            cells = new List<CellModel>();

            for (int i = 0; i < GRID_SIZE; i++)
            {
                cells.Add(new CellModel(i, rand.Next(2)));
            }
            return View("Index", cells);
        }

        public IActionResult HandleLeftClick(string buttonNumber)
        {
            int bN = int.Parse(buttonNumber);

            //State 1 will be safe, state 2 is a bomb, when 1 is click, change to 3 (show num of safe) when 2 is clicked, game over, show bomb image
            cells.ElementAt(bN).State = (buttons.ElementAt(bN).State + 2);

            return View("Index", cells);
        }
    }
}
