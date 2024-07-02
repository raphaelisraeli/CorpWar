using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Core
{
    public class CharacterManager : MonoBehaviour
    {
        // Singleton instance
        public static CharacterManager Instance;

        // List of all active characters in the game
        public List<Character> activeCharacters = new List<Character>();

        private void Awake()
        {
            // Singleton pattern: Ensure only one instance of CharacterManager exists
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Persist between scenes
            }
            else
            {
                Debug.LogWarning("Duplicate CharacterManager instance found. Destroying duplicate.");
                Destroy(gameObject);
            }

            // Initialize characters (load from save file or create new characters)
            InitializeCharacters();
        }

        // Method to initialize characters (could be used to load from a save file in the future)
        private void InitializeCharacters()
        {
            // Placeholder for initializing characters
            // Example: Load characters from a save file or instantiate them in-game
            // This is currently a placeholder and should be implemented as needed
        }

        // Method to add a new character to the list
        public void AddCharacter(Character character)
        {
            if (!activeCharacters.Contains(character))
            {
                activeCharacters.Add(character);
            }
        }

        // Method to remove a character from the list
        public void RemoveCharacter(Character character)
        {
            if (activeCharacters.Contains(character))
            {
                activeCharacters.Remove(character);
            }
        }

        // Method to get a character by name
        public Character GetCharacterByName(string characterName)
        {
            return activeCharacters.Find(character => character.name == characterName);
        }

        // Method to save all characters' data
        public void SaveAllCharacters(string directoryPath)
        {
            foreach (var character in activeCharacters)
            {
                character.SaveCharacterData(directoryPath + "/" + character.name + ".json");
            }
        }

        // Method to load a specific character's data
        public Character LoadCharacter(string characterName, string filePath)
        {
            Character character = new Character(characterName);
            character.LoadCharacterData(filePath + "/" + characterName + ".json");
            AddCharacter(character); // Ensure the character is added to the active list
            return character;
        }

        // Method to save a single character's data
        public void SaveCharacter(Character character, string filePath)
        {
            if (activeCharacters.Contains(character))
            {
                character.SaveCharacterData(filePath + "/" + character.name + ".json");
            }
            else
            {
                Debug.LogWarning("Character not found in the active list.");
            }
        }
    }
}
