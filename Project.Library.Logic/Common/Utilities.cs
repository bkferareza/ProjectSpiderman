using System;

namespace Project.Library.Logic.Common
{
    public static class Utilities
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
