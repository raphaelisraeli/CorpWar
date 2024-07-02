namespace MyGame.Core
{

    using System;

    [System.Serializable]
    public class Spell
    {
        public string name;
        public string description;
        public int manaCost;
        public int power;

        public Spell(string name, string description, int manaCost, int power)
        {
            this.name = name;
            this.description = description;
            this.manaCost = manaCost;
            this.power = power;
        }
    }
}