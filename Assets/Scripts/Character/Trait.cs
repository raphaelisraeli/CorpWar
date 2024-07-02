namespace MyGame.Core
{

    using System;

    [System.Serializable]
    public class Trait
    {
        public string name;
        public string description;
        public bool isPositive;

        public Trait(string name, string description, bool isPositive)
        {
            this.name = name;
            this.description = description;
            this.isPositive = isPositive;
        }
    }
}