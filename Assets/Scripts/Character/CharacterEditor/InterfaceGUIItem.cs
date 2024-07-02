namespace MyGame.CharacterEditor
{
    public interface InterfaceGUIItem<T>
    {
        void Initialize(T GUIItem);
        void Setup(CharacterEditor characterEditor, CharacterEditorGUI characterEditorGUI);
    }
}
