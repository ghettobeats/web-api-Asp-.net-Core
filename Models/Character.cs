using System.ComponentModel.DataAnnotations;

namespace dotnet_RPG.Models
{
    public class Character
    {
        public int Id { get; set; } 
        [Required]
        public string Name  { get; set; } ="Antonio";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

    }
}