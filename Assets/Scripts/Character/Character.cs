namespace MyGame.Core
{

    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;

    [System.Serializable]
    public class Character
    {
        public string name;

        // Instances of nested classes
        public Attributes attributes = new Attributes();
        public Stats stats = new Stats();
        public Skills skills = new Skills();
        public Traits traits = new Traits();
        public Spells spells = new Spells();
        public Items items = new Items();

        // Constructor
        public Character(string name)
        {
            this.name = name;
        }

        // Parameterless constructor for flexibility
        public Character() { }

        // Method to save character data to a JSON file
        public void SaveCharacterData(string filePath)
        {
            string json = JsonUtility.ToJson(this, true);
            File.WriteAllText(filePath, json);
        }

        // Method to load character data from a JSON file
        public void LoadCharacterData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                Debug.LogError("Cannot load character data. File not found: " + filePath);
            }
        }

        [System.Serializable]
        public class Attributes
        {
            // List of all attributes a character has
            public List<Attribute> attributes = new List<Attribute>();
        }

        [System.Serializable]
        public class Stats
        {
            // List of all stats a character has
            public List<Stat> stats = new List<Stat>();

            // Method to calculate all stat values based on current attributes
            public void CalculateAllStatValues(List<Attribute> attributes)
            {
                foreach (var stat in stats)
                {
                    stat.CalculateValue(attributes);
                }
            }
        }

        [System.Serializable]
        public class Skills
        {
            // List of all skills a character has
            public List<Skill> skills = new List<Skill>();
        }

        [System.Serializable]
        public class Traits
        {
            // List of all traits a character has
            public List<Trait> traits = new List<Trait>();
        }

        [System.Serializable]
        public class Spells
        {
            // List of all spells a character has
            public List<Spell> spells = new List<Spell>();
        }

        [System.Serializable]
        public class Items
        {
            public Item leftHand;
            public Item rightHand;
            public Item body;
            public List<Item> belt = new List<Item>();
            public List<Item> backpack = new List<Item>();
        }
    }
}