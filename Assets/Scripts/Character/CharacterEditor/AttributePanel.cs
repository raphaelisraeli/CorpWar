using UnityEngine;
using System.Collections.Generic;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    public class AttributePanel : MonoBehaviour
    {
        public Transform listContainer; // Container to hold the list items
        public GameObject attributeGUIPrefab; // Prefab for a single attribute GUI item

        private List<Attribute> attributes = new List<Attribute>();
        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void SetCharacterEditor(CharacterEditor editor, CharacterEditorGUI editorGUI)
        {
            characterEditor = editor;
            characterEditorGUI = editorGUI;
        }

        public void SetAttributes(List<Attribute> newAttributes)
        {
            // Clear existing items
            foreach (Transform child in listContainer)
            {
                Destroy(child.gameObject);
            }

            // Add new items
            attributes = newAttributes;
            foreach (var attribute in attributes)
            {
                GameObject attributeItem = Instantiate(attributeGUIPrefab, listContainer);
                AttributeGUIItem attributeGUIItem = attributeItem.GetComponent<AttributeGUIItem>();
                if (attributeGUIItem != null)
                {
                    attributeGUIItem.Initialize(attribute);
                    attributeGUIItem.Setup(characterEditor, characterEditorGUI);
                }
            }
        }
    }
}
