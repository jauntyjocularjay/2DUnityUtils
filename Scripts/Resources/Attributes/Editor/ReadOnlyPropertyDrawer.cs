using UnityEngine;
using UnityEditor;

namespace DMBTools
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Store original GUI state
            bool isEnabled = GUI.enabled;
            
            // Disable GUI for read-only effect
            GUI.enabled = false;
            
            // Draw the property field as normal but disabled
            EditorGUI.PropertyField(position, property, label, true);
            
            // Restore original GUI state
            GUI.enabled = isEnabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}