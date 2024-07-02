
using UnityEngine;
using TMPro;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    
    public class SkillGUIItem : MonoBehaviour, InterfaceGUIItem<Skill>
    {
        public TextMeshProUGUI label;
        public TextMeshProUGUI value;

        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void Initialize(Skill GUIItem)
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
