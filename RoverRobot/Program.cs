using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoverRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau moon = new Plateau();
            moon.PlateauGrid = new int[40, 30];
            
            Rover objRover = new Rover();
            moon.Rovers.Add(objRover);


            objRover.SetPosition(10, 10, "N");
            Console.WriteLine($"Current Position: {objRover.currentPosition}");
            string command = "R1R3L2L1";
            var newPosition = objRover.Move(command); //13 8 N
            Console.WriteLine($"The ROVER new position for command {command} is {newPosition}");

            Console.WriteLine("\n\nDo you want to try ROVER positioning Y/N");

            if (Console.ReadLine().ToUpper() != "Y")
            {
                return;
            }

            Start:
            Console.WriteLine("\n--Options--");
            Console.WriteLine("1: Initialize Position");
            Console.WriteLine("2: Move Rover");
            Console.WriteLine("3: Display Rover Position");
            Console.WriteLine("4: Is Rover on Grid");
            Console.WriteLine("5: Exit");
            Console.WriteLine("6: Reset Screen");

            Console.WriteLine("\n\nEnter Option");

            while (true)
            {
                
                if (int.TryParse(Console.ReadLine(), out int opt))
                {
                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("Press enter ROVER initial position in format example [10 10 N].");
                            try
                            {
                                objRover.SetPosition(Console.ReadLine());
                                Console.WriteLine("Initialize success.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error occured:" + ex.Message);
                            }

                            break;

                        case 2:
                            Console.WriteLine("Please enter the ROVER command sequence");
                            try
                            {
                                newPosition = objRover.Move(Console.ReadLine()); //Example: "R1R3L2L1" = 13 8 N
                                Console.WriteLine($"The ROVER is moved and its new position is {newPosition}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error occured:" + ex.Message);
                            }
                            break;

                        case 3:
                            Console.WriteLine($"The ROVER current position is {objRover.currentPosition}");
                            break;

                        case 4:
                            var isOnGrid = moon.IsRoverOnPlateau(objRover) ? "Is" : "Is NOT";
                            Console.WriteLine($"The ROVER {isOnGrid} on the GRID.");
                            break;

                        case 5:
                            return;

                        case 6:
                            Console.Clear();
                            goto Start;

                        default:
                            Console.WriteLine($"Invalid Option, please try again.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid Option, please try again.");
                }

                Console.WriteLine($"\nEnter Option.");

            }

        }

        
    }

}
