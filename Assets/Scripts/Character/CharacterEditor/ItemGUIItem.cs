
using UnityEngine;
using TMPro;
using MyGame.Core;

namespace MyGame.CharacterEditor
{

    public class ItemGUIItem : MonoBehaviour, InterfaceGUIItem<Item>
    {
        public TextMeshProUGUI label;
        public TextMeshProUGUI description;

        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void Initialize(Item GUIItem)
        {
            label.text = GUIItem.Name;
            description.text = GUIItem.Description;
        }

        public void Setup(CharacterEditor characterEditor, CharacterEditorGUI characterEditorGUI)
        {
            this.characterEditor = characterEditor;
            this.characterEditorGUI = characterEditorGUI;
        }
    }
}
