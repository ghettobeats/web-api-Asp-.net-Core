using dotnet_RPG.Models;

namespace dotnet_RPG.Dtos.Character
{
    public class DeleteCharacterDto
    {
          public int Id { get; set; } 
        public string Name  { get; set; } ="Antonio";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}