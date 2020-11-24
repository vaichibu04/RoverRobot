using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverRobot
{
    
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }

        public string currentPosition { get { return $"[{X} {Y} {Facing}]"; } }

        public Rover()
        {
            X = 0;
            Y = 0;
            Facing = Direction.N;
        }

        public Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Facing = direction;
        }

        /// <summary>
        /// Example: [10 10 N]
        /// </summary>
        /// <param name="formattedPosition"></param>
        public void SetPosition(string formattedPosition)
        {
            formattedPosition = formattedPosition.Trim('[', ']');
            var psitionValues = formattedPosition.Split(' ');

            if(int.TryParse(psitionValues[0], out int xPos))
            {
                X = xPos;
            }else
            {
                throw new Exception("Invalid Position X");
            }

            if (int.TryParse(psitionValues[1], out int yPos))
            {
                Y = yPos;
            }else
            {
                throw new Exception("Invalid Position Y");
            }

            if (psitionValues[2].TryParseEnum(out Direction direction))
            {
                Facing = direction;
            }
            else
            {
                throw new Exception("Invalid ROVER Direction");
            }

        }

        public void SetPosition(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Facing = direction.ParseEnum<Direction>();
        }


        public string Move(string commands)
        {
            var moves = ParseCommands(commands);
            foreach (var move in moves)
            {
                
                if (move.commandType == CommandType.Rotate)
                {
                    var commandValue = ((CommandValue<Rotation>)move);
                    RotatebyNinetyDegree(commandValue.Value);
                }
                else if(move.commandType == CommandType.TakeStep)
                {
                    var commandValue = ((CommandValue<int>)move);
                    Move(commandValue.Value);
                }

            }

            return currentPosition;
        }

        #region Private Methods

        private void Move(int count)
        {
            if (Facing == Direction.N)
                Y += count;
            else if (Facing == Direction.S)
                Y -= count;
            else if (Facing == Direction.E)
                X += count;
            else if (Facing == Direction.W)
                X -= count;
        }

        private void RotatebyNinetyDegree(Rotation rotate)
        {
            if (rotate == Rotation.Left)
            {
                switch (Facing)
                {
                    case Direction.N:
                        Facing = Direction.W;
                        break;
                    case Direction.S:
                        Facing = Direction.E;
                        break;
                    case Direction.E:
                        Facing = Direction.N;
                        break;
                    case Direction.W:
                        Facing = Direction.S;
                        break;
                    default:
                        break;
                }

            }
            else
            {
                switch (Facing)
                {
                    case Direction.N:
                        Facing = Direction.E;
                        break;
                    case Direction.S:
                        Facing = Direction.W;
                        break;
                    case Direction.E:
                        Facing = Direction.S;
                        break;
                    case Direction.W:
                        Facing = Direction.N;
                        break;
                    default:
                        break;
                };

            }
        }


        private List<Command> ParseCommands(string commands)
        {
            var commandsResp = new List<Command>();

            var moves = commands.ToUpper().ToCharArray();

            Command prevCommand = null;
            foreach (char move in moves)
            {
                if (move == 'L')
                {
                    prevCommand = new RotateCommand(Rotation.Left);
                    commandsResp.Add(prevCommand);
                }
                else if (move == 'R')
                {
                    prevCommand = new RotateCommand(Rotation.Right);
                    commandsResp.Add(prevCommand);
                }
                else
                {
                    var success = int.TryParse(move.ToString(), out int steps);
                    if (success)
                    {
                        if (prevCommand != null && prevCommand.commandType == CommandType.TakeStep)
                        {
                            //If previous value was a number and current is also a number then both number are combined step example: 12 is a step 12 and not 1 & 2 as different steps
                            var newPrevStepValue = int.Parse($"{((CommandValue<int>)prevCommand).Value}{steps}");
                            ((CommandValue<int>)prevCommand).Value = newPrevStepValue;
                        }
                        else
                        {
                            prevCommand = new TakeStepCommand(steps);
                            commandsResp.Add(prevCommand);

                        }
                    }
                    else
                    {
                        throw new Exception("Illegal Move command");
                    }
                }
            }

            return commandsResp;
        }

        #endregion
    }

}
