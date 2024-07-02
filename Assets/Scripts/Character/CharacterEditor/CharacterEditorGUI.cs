using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    public class CharacterEditorGUI : MonoBehaviour
    {
        public TMP_InputField characterNameInputField;
        public TextMeshProUGUI apCounter;
        public TextMeshProUGUI moneyCounter;

        public AttributePanel attributesPanel;
        public GUIListPanel<Stat> statsListPanel;
        public GUIListPanel<Skill> skillsListPanel;
        public GUIListPanel<Item> itemsListPanel;

        public Button newButton;
        public Button loadButton;
        public Button saveButton;
        public Button lowerMoneyButton;

        private CharacterEditor characterEditor;
        private Character currentCharacter;

        private void Start()
        {
            characterEditor = new CharacterEditor();
            CreateNewCharacter();

            if (attributesPanel != null)
            {
                attributesPanel.SetCharacterEditor(characterEditor, this);
            }
            else
            {
                Debug.LogError("attributesPanel is null in Start");
            }

            statsListPanel.SetCharacterEditor(characterEditor, this);
            skillsListPanel.SetCharacterEditor(characterEditor, this);
            itemsListPanel.SetCharacterEditor(characterEditor, this);

            newButton.onClick.AddListener(OnNewCharacterButtonClick);
            loadButton.onClick.AddListener(OnLoadCharacterButtonClick);
            saveButton.onClick.AddListener(OnSaveCharacterButtonClick);
            lowerMoneyButton.onClick.AddListener(OnLowerMoneyButtonClick);
        }

        private void CreateNewCharacter()
        {
            currentCharacter = characterEditor.CreateNewCharacter("NewCharacter", 100); // Example initial AP

            if (CharacterManager.Instance != null)
            {
                CharacterManager.Instance.AddCharacter(currentCharacter); // Add the new character to the active list
            }
            else
            {
                Debug.LogError("CharacterManager.Instance is null");
            }

            UpdateGUI();
        }

        private void UpdateGUI()
        {
            Debug.Log("UpdateGUI called");

            if (currentCharacter == null)
            {
                Debug.LogError("currentCharacter is null");
                return;
            }

            if (characterNameInputField == null)
            {
                Debug.LogError("characterNameInputField is null");
            }
            else
            {
                characterNameInputField.text = currentCharacter.name;
            }

            if (apCounter == null)
            {
                Debug.LogError("apCounter is null");
            }
            else
            {
                apCounter.text = "AP: " + characterEditor.GetAdvancementPoints().ToString();
            }

            if (moneyCounter == null)
            {
                Debug.LogError("moneyCounter is null");
            }
            else
            {
                moneyCounter.text = "Money: " + characterEditor.GetStartingMoney().ToString();
            }

            if (attributesPanel == null)
            {
                Debug.LogError("attributesPanel is null");
            }
            else
            {
                attributesPanel.SetAttributes(currentCharacter.attributes.attributes);
            }

            if (statsListPanel == null)
            {
                Debug.LogError("statsListPanel is null");
            }
            else
            {
                statsListPanel.SetGUIItems(currentCharacter.stats.stats);
            }

            if (skillsListPanel == null)
            {
                Debug.LogError("skillsListPanel is null");
            }
            else
            {
                skillsListPanel.SetGUIItems(currentCharacter.skills.skills);
            }

            if (itemsListPanel == null)
            {
                Debug.LogError("itemsListPanel is null");
            }
            else
            {
                List<Item> allItems = new List<Item>();
                if (currentCharacter.items.leftHand != null) allItems.Add(currentCharacter.items.leftHand);
                if (currentCharacter.items.rightHand != null) allItems.Add(currentCharacter.items.rightHand);
                if (currentCharacter.items.body != null) allItems.Add(currentCharacter.items.body);
                allItems.AddRange(currentCharacter.items.belt);
                allItems.AddRange(currentCharacter.items.backpack);
                itemsListPanel.SetGUIItems(allItems);
            }
        }

        public void Refresh()
        {
            UpdateGUI();
        }

        public void OnNewCharacterButtonClick()
        {
            CreateNewCharacter();
        }

        public void OnSaveCharacterButtonClick()
        {
            if (currentCharacter != null)
            {
                currentCharacter.name = characterNameInputField.text;
                CharacterManager.Instance.SaveCharacter(currentCharacter, Application.persistentDataPath);
                Debug.Log("Character saved: " + currentCharacter.name);
            }
            else
            {
                Debug.LogWarning("No character to save.");
            }
        }

        public void OnLoadCharacterButtonClick()
        {
            string characterName = "NewCharacter"; // This should be dynamic in a full implementation
            currentCharacter = CharacterManager.Instance.LoadCharacter(characterName, Application.persistentDataPath);
            if (currentCharacter != null)
            {
                UpdateGUI();
            }
            else
            {
                Debug.LogWarning("Failed to load character: " + characterName);
            }
        }

        public void OnLowerMoneyButtonClick()
        {
            if (characterEditor.LowerStartingMoney(2000)) // Adjust amount as needed
            {
                UpdateGUI();
            }
            else
            {
                Debug.LogWarning("Not enough starting money to deduct.");
            }
        }
    }
}
