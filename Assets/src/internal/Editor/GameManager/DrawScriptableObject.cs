using Afired.Utils.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObject<T> : IGameManagerTab where T : ScriptableObject {
        
        public string TabName { get; }
        public bool ShouldDrawEditor => false;
        public bool ShouldDrawBaseMenu => false;
        [ShowIf("@_scriptableObject != null")] [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        [SerializeField] private T _scriptableObject;
        
        public DrawScriptableObject(string tabName) {
            TabName = tabName;
        }
        
        public void OnInitialize() {
            _scriptableObject = EditorSerialization.LoadScriptableObject<T>();
        }
        
        public void SetSelected(object item) {
            
        }
        
        public OdinMenuTree BuildMenuTree() {
            return new OdinMenuTree();
        }
        
    }
    
}
