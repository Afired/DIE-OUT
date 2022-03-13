using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Afired.Utils.Editor.GameManager {
    
    public static class TabButtonGroup {
        
        private static GUIStyle _toggleButtonStyleSelected = null;
        private static GUIStyle _toggleButtonStyleNormal = null;

        
        public static bool Draw(ref int index, string[] options) {
            
            int activeIndex = index;
            
            if (_toggleButtonStyleSelected == null) {
                _toggleButtonStyleNormal = new GUIStyle(SirenixGUIStyles.ToolbarTab);
                _toggleButtonStyleNormal.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
                
                _toggleButtonStyleSelected = new GUIStyle(SirenixGUIStyles.ToolbarTab);
                _toggleButtonStyleSelected.normal.textColor = new Color(1f, 1f, 1f, 1f);
                _toggleButtonStyleSelected.hover.textColor = new Color(1f, 1f, 1f, 1f);
                _toggleButtonStyleSelected.active.textColor = new Color(1f, 1f, 1f, 1f);
                _toggleButtonStyleSelected.fontStyle = FontStyle.Bold;
            }
            
            GUILayout.BeginHorizontal(new GUIStyle(SirenixGUIStyles.ToolbarBackground) { fixedHeight = 25});
            
            for(int i = 0; i < options.Length; i++) {
                if(GUILayout.Button(options[i], activeIndex == i ? _toggleButtonStyleSelected : _toggleButtonStyleNormal)) {
                    activeIndex = i;
                }
            }
            
            GUILayout.EndHorizontal();

            bool valueHasChanged = index != activeIndex;

            index = activeIndex;

            return valueHasChanged;
        }
        
    }
    
}
