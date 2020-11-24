using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverRobot
{
    
    public class Command
    {
        public CommandType commandType { get; set; }
        public Command(CommandType type)
        {
            commandType = type;
        }
    }
    interface CommandValue<T>
    {
        T Value { get; set; }
    }


    public class RotateCommand : Command, CommandValue<Rotation>
    {
        public Rotation Value { get; set; }
        public RotateCommand(Rotation val) : base(CommandType.Rotate)
        {
            Value = val;
        }
        
    }

    public class TakeStepCommand : Command, CommandValue<int>
    {
        public int Value { get; set; }
        public TakeStepCommand(int val) : base(CommandType.TakeStep)
        {
            Value = val;
        }

    }
}
