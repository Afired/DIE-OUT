using Afired.Utils.Prefabs;
using UnityEditor;
using UnityEngine;

namespace Afired.Utils.Editor {
    
    [CustomPropertyDrawer(typeof(Prefab))]
    public class PrefabPropertyDrawer : PropertyDrawer {
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, GUIContent.none, property);
            SerializedProperty prefab = property.FindPropertyRelative("_prefab");
            label.text += " (Prefab)";
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            prefab.objectReferenceValue = EditorGUI.ObjectField(position, prefab.objectReferenceValue, typeof(GameObject), false);
            EditorGUI.EndProperty();
        }
        
    }
    
}
