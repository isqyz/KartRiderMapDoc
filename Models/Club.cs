﻿namespace KartRiderMapDoc.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<Player>? playerScore;
    }
}
