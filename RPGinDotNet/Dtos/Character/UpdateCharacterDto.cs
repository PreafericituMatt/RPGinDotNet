﻿using RPGinDotNet.Models;

namespace RPGinDotNet.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defence { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public RpgClass Class { get; set; }
    }
}
