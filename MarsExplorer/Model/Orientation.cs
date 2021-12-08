using System.ComponentModel.DataAnnotations;

namespace MarsExplorer.Model
{
    public enum Orientation
    {
        [Display(Name = "N", Description = "North")]
        North = 1,

        [Display(Name = "S", Description = "South")]
        South = 2,

        [Display(Name = "E", Description = "East")]
        East = 3,

        [Display(Name = "W", Description = "West")]
        West = 4
    }
}