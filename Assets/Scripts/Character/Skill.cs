namespace MyGame.Core
{

    using System;

    [System.Serializable]
    public class Skill
    {
        public string name;
        public int value;
        public string description;
        public Attribute relevantAttribute;

        public Skill(string name, int rating, string description, Attribute relevantAttribute)
        {
            this.name = name;
    #pragma warning disable CS1717 // Assignment made to same variable
            this.value = value;
    #pragma warning restore CS1717 // Assignment made to same variable
            this.description = description;
            this.relevantAttribute = relevantAttribute;
        }
    }
}