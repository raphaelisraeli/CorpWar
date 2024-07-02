using System.Collections.Generic;
using UnityEngine;

namespace MyGame.CharacterEditor
{
    public class GUIListPanel<T> : MonoBehaviour
    {
        public Transform listContainer; // Container to hold the list items
        public GameObject listItemPrefab; // Prefab for a single list item

        private List<T> GUIItems = new List<T>();
        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void SetCharacterEditor(CharacterEditor editor, CharacterEditorGUI editorGUI)
        {
            characterEditor = editor;
            characterEditorGUI = editorGUI;
        }

        // Method to set the GUI items in the list
        public void SetGUIItems(List<T> newGUIItems)
        {
            // Clear existing items
            foreach (Transform child in listContainer)
            {
                Destroy(child.gameObject);
            }

            // Add new items
            GUIItems = newGUIItems;
            foreach (var GUIItem in GUIItems)
            {
                GameObject listItem = Instantiate(listItemPrefab, listContainer);
                InterfaceGUIItem<T> listItemComponent = listItem.GetComponent<InterfaceGUIItem<T>>();
                if (listItemComponent != null)
                {
                    listItemComponent.Initialize(GUIItem);
                    if (listItemComponent is AttributeGUIItem attributeGUIItem)
                    {
                        attributeGUIItem.Setup(characterEditor, characterEditorGUI);
                    }
                    else if (listItemComponent is StatGUIItem statGUIItem)
                    {
                        statGUIItem.Setup(characterEditor, characterEditorGUI);
                    }
                    else if (listItemComponent is SkillGUIItem skillGUIItem)
                    {
                        skillGUIItem.Setup(characterEditor, characterEditorGUI);
                    }
                    else if (listItemComponent is ItemGUIItem itemGUIItem)
                    {
                        itemGUIItem.Setup(characterEditor, characterEditorGUI);
                    }
                }
            }
        }
    }
}
