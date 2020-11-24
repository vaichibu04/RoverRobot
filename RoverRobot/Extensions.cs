using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverRobot
{
    static class Extensions
    {
        public static TEnum ParseEnum<TEnum>(this string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }

        public static bool TryParseEnum<TEnum>(this string value, out TEnum result) where TEnum : struct 
        {
            return Enum.TryParse<TEnum>(value,true, out result);

        }
    }
}
