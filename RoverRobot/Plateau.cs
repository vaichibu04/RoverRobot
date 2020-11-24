using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverRobot
{
    public class Plateau
    {
        public int[,] PlateauGrid { get; set; }
        public List<Rover> Rovers = new List<Rover>();
        public bool IsRoverOnPlateau(Rover rover)
        {
            var xAxisLength = PlateauGrid.GetLength(0);
            var yAxisLenth = PlateauGrid.GetLength(1);

            return (rover.X >= 0 && rover.Y >= 0 && rover.X < xAxisLength && rover.Y < yAxisLenth);
        }
    }

}
