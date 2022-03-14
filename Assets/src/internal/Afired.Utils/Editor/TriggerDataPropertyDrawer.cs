using Afired.Utils.Triggers;
using UnityEditor;
using UnityEngine;

namespace Afired.Utils.Editor {
    
    [CustomPropertyDrawer(typeof(TriggerData))]
    public class TriggerPropertyDrawer : PropertyDrawer {
        
        private int _lineCount;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            
            _lineCount = 0;
            EditorGUI.BeginProperty(position, label, property);
            
            EditorGUI.BeginChangeCheck();
            
            _lineCount++;
            Rect rect1 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
            SerializedProperty colliderTypeProperty = property.FindPropertyRelative("ColliderType");
            ColliderType colliderType = (ColliderType) EditorGUI.EnumPopup(rect1, "Collider Type", (ColliderType) colliderTypeProperty.enumValueIndex);
            colliderTypeProperty.enumValueIndex = (int) colliderType;
            
            if(EditorGUI.EndChangeCheck() && EditorApplication.isPlaying)
                property.FindPropertyRelative("ColliderTypeIsDirty").boolValue = true;
            
            
            EditorGUI.BeginChangeCheck();
            
            _lineCount++;
            Rect rect2 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
            SerializedProperty centerProperty = property.FindPropertyRelative("Center");
            centerProperty.vector3Value = EditorGUI.Vector3Field(rect2, "Center", centerProperty.vector3Value);
            
            if(colliderType == ColliderType.Box) {
                _lineCount++;
                Rect rect3 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
                SerializedProperty sizeProperty = property.FindPropertyRelative("Size");
                sizeProperty.vector3Value = EditorGUI.Vector3Field(rect3, "Size", sizeProperty.vector3Value);
            }
            
            if(colliderType == ColliderType.Capsule || colliderType == ColliderType.Sphere) {
                _lineCount++;
                Rect rect4 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
                SerializedProperty radiusProperty = property.FindPropertyRelative("Radius");
                radiusProperty.floatValue = EditorGUI.FloatField(rect4, "Radius", radiusProperty.floatValue);
            }
            
            if(colliderType == ColliderType.Capsule) {
                _lineCount++;
                Rect rect5 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
                SerializedProperty heightProperty = property.FindPropertyRelative("Height");
                heightProperty.floatValue = EditorGUI.FloatField(rect5, "Height", heightProperty.floatValue);
            }
            
            if(colliderType == ColliderType.Capsule) {
                _lineCount++;
                Rect rect6 = new Rect(position.min.x, position.min.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * (_lineCount - 1), position.size.x, EditorGUIUtility.singleLineHeight);
                SerializedProperty directionProperty = property.FindPropertyRelative("Direction");
                directionProperty.enumValueIndex = (int) (Axis) EditorGUI.EnumPopup(rect6, "Direction", (Axis) directionProperty.enumValueIndex);
                EditorGUI.EndProperty();
            }
            
            if(EditorGUI.EndChangeCheck() && EditorApplication.isPlaying)
                property.FindPropertyRelative("ColliderValuesAreDirty").boolValue = true;
            
        }
        
//        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
//            VisualElement container = new VisualElement();
//            
//            PropertyField colliderType = new PropertyField(property.FindPropertyRelative("ColliderType"));
//            
//            container.Add(colliderType);
//            
//            return container;
//        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight * _lineCount + EditorGUIUtility.standardVerticalSpacing * (_lineCount - 1);
        }
        
    }
    
}
