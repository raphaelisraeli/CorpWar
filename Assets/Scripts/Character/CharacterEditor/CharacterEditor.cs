using System.Collections.Generic;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    public class CharacterEditor
    {
        private Character currentCharacter;
        private int advancementPoints;
        private int startingMoney;

        // Method to create a new character
        public Character CreateNewCharacter(string name, int initialAP)
        {
            currentCharacter = new Character(name);
            advancementPoints = initialAP;
            startingMoney = 0; // Initial starting money
            InitializeCharacterAttributes(currentCharacter);
            return currentCharacter;
        }

        // Method to generate attributes for a new character
        private void InitializeCharacterAttributes(Character character)
        {
            character.attributes.attributes.Add(new Attribute("Endurance", 1, "Physical endurance"));
            character.attributes.attributes.Add(new Attribute("Agility", 1, "Physical agility"));
            character.attributes.attributes.Add(new Attribute("Reflexes", 1, "Speed of reactions"));
            character.attributes.attributes.Add(new Attribute("Strength", 1, "Physical strength"));
            character.attributes.attributes.Add(new Attribute("Willpower", 1, "Mental strength"));
            character.attributes.attributes.Add(new Attribute("Logic", 1, "Ability to reason"));
            character.attributes.attributes.Add(new Attribute("Perception", 1, "Awareness of surroundings"));
            character.attributes.attributes.Add(new Attribute("Spirit", 1, "Spiritual strength"));
        }

        // Method to raise an attribute value using FormulaEvaluator
        public bool RaiseAttribute(Attribute attribute)
        {
            int cost = FormulaEvaluator.Evaluate($"{attribute.value + 1} * 5", new Dictionary<string, int>());
            if (advancementPoints >= cost)
            {
                advancementPoints -= cost;
                attribute.value += 1;
                return true;
            }
            return false;
        }

        // Method to lower an attribute value using FormulaEvaluator
        public bool LowerAttribute(Attribute attribute)
        {
            int refund = FormulaEvaluator.Evaluate($"{attribute.value} * 5", new Dictionary<string, int>());
            if (attribute.value > 0)
            {
                advancementPoints += refund;
                attribute.value -= 1;
                return true;
            }
            return false;
        }

        // Method to raise a skill value using FormulaEvaluator
        public bool RaiseSkill(Skill skill)
        {
            int cost = FormulaEvaluator.Evaluate($"{skill.value + 1} * 2", new Dictionary<string, int>());
            if (advancementPoints >= cost)
            {
                advancementPoints -= cost;
                skill.value += 1;
                return true;
            }
            return false;
        }

        // Method to lower a skill value using FormulaEvaluator
        public bool LowerSkill(Skill skill)
        {
            int refund = FormulaEvaluator.Evaluate($"{skill.value} * 2", new Dictionary<string, int>());
            if (skill.value > 0)
            {
                advancementPoints += refund;
                skill.value -= 1;
                return true;
            }
            return false;
        }

        // Method to add starting money
        public bool AddStartingMoney(int amount)
        {
            int cost = FormulaEvaluator.Evaluate($"{amount / 2000}", new Dictionary<string, int>());
            if (advancementPoints >= cost)
            {
                advancementPoints -= cost;
                startingMoney += amount;
                return true;
            }
            return false;
        }

        // Method to lower starting money
        public bool LowerStartingMoney(int amount)
        {
            if (startingMoney >= amount && amount % 2000 == 0)
            {
                int refund = FormulaEvaluator.Evaluate($"{amount / 2000}", new Dictionary<string, int>());
                startingMoney -= amount;
                advancementPoints += refund;
                return true;
            }
            return false;
        }

        // Method to get the current character being edited
        public Character GetCurrentCharacter()
        {
            return currentCharacter;
        }

        // Method to get the current advancement points
        public int GetAdvancementPoints()
        {
            return advancementPoints;
        }

        // Method to get the current starting money
        public int GetStartingMoney()
        {
            return startingMoney;
        }

        // Method to save the current character's data
        public void SaveCurrentCharacter(string filePath)
        {
            if (currentCharacter != null)
            {
                currentCharacter.SaveCharacterData(filePath + "/" + currentCharacter.name + ".json");
            }
        }
    }
}
