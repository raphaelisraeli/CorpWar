
using UnityEngine;
using TMPro;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    public class StatGUIItem : MonoBehaviour, InterfaceGUIItem<Stat>
    {
        public TextMeshProUGUI label;
        public TextMeshProUGUI value;

        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void Initialize(Stat GUIItem)
        {
            label.text = GUIItem.name;
            value.text = GUIItem.value.ToString();
        }

        public void Setup(CharacterEditor characterEditor, CharacterEditorGUI characterEditorGUI)
        {
            this.characterEditor = characterEditor;
            this.characterEditorGUI = characterEditorGUI;
        }
    }
}
