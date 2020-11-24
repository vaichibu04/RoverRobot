using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverRobot;

namespace RoverRobotTest
{
    [TestClass]
    public class When_Moving_Rover
    {
        [TestMethod]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            Plateau moon = new Plateau();
            moon.PlateauGrid = new int[40, 30];

            Rover objRover = new Rover();
            objRover.SetPosition("[10 10 N]");
            moon.Rovers.Add(objRover);

            var newPosition = objRover.Move("R1R3L2L1"); //13 8 N

            Assert.AreEqual("[13 8 N]", newPosition);
        }

        [TestMethod]
        public void Impermissible_Command_Sequence_Causes_Fall_Off_Plateau()
        {
            Plateau moon = new Plateau();
            moon.PlateauGrid = new int[40, 30];

            Rover objRover = new Rover();
            objRover.SetPosition("[35 25 N]");
            moon.Rovers.Add(objRover);

            objRover.Move("R6"); //41 25 E

            var isOnPlateau = moon.IsRoverOnPlateau(objRover);

            Assert.AreEqual(false, isOnPlateau);
        }
    }
}
