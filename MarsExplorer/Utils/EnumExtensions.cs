using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using MarsExplorer.Model;

namespace MarsExplorer.Utils
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())?.First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name;
        }

        public static BaseOrientation InstantiateOrientation(this string value)
        {
            return value switch
            {
                "E" => new EastOrientation(),
                "W" => new WestOrientation(),
                "N" => new NorthOrientation(),
                "S" => new SouthOrientation(),
                _ => throw new InvalidOperationException($"Invalid Orientation: {value}")
            };
        }
    }
}