using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MyGame.Core;

namespace MyGame.CharacterEditor
{
    public class AttributeGUIItem : MonoBehaviour
    {
        public TextMeshProUGUI label;
        public Button minusButton;
        public TextMeshProUGUI counter;
        public Button plusButton;

        private Attribute attribute;
        private CharacterEditor characterEditor;
        private CharacterEditorGUI characterEditorGUI;

        public void Initialize(Attribute attribute)
        {
            this.attribute = attribute;
            label.text = attribute.name;
            counter.text = attribute.value.ToString();
            Debug.Log($"Initialized with attribute: {attribute.name}, value: {attribute.value}");
        }

        public void Setup(CharacterEditor characterEditor, CharacterEditorGUI characterEditorGUI)
        {
            this.characterEditor = characterEditor;
            this.characterEditorGUI = characterEditorGUI;
            minusButton.onClick.AddListener(OnMinusButtonClicked);
            plusButton.onClick.AddListener(OnPlusButtonClicked);
            Debug.Log("Setup called with CharacterEditor and CharacterEditorGUI");
        }

        private void OnMinusButtonClicked()
        {
            DebugNullReferences();
            if (characterEditor.LowerAttribute(attribute))
            {
                counter.text = attribute.value.ToString();
                characterEditorGUI.Refresh();
            }
        }

        private void OnPlusButtonClicked()
        {
            DebugNullReferences();
            if (characterEditor.RaiseAttribute(attribute))
            {
                counter.text = attribute.value.ToString();
                characterEditorGUI.Refresh();
            }
        }

        private void DebugNullReferences()
        {
            if (characterEditor == null)
            {
                Debug.LogError("CharacterEditor is null in OnPlusButtonClicked");
            }
            else
            {
                Debug.Log("CharacterEditor is not null in OnPlusButtonClicked");
            }

            if (attribute == null)
            {
                Debug.LogError("Attribute is null in OnPlusButtonClicked");
            }
            else
            {
                Debug.Log("Attribute is not null in OnPlusButtonClicked");
            }
        }
    }
}
