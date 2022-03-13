using Afired.Utils.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Afired.Utils.Editor.GameManager {
    
    public class DrawScriptableObjectTree<T> : IGameManagerTab where T : ScriptableObject {
        
        public string TabName { get; }
        public bool ShouldDrawEditor => true;
        public bool ShouldDrawBaseMenu => true;
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        [SerializeField] private T _selected;
        [LabelWidth(100)] [PropertyOrder(-2)] [HorizontalGroup("CreateNew")]
        [SerializeField] private string _nameForNew;
        
        public DrawScriptableObjectTree(string tabName) {
            TabName = tabName;
        }
        
        public void SetSelected(object item) {
            if(item is T newSelected) {
                _selected = newSelected;
            }
        }
        
        public void OnInitialize() { }
        
        public OdinMenuTree BuildMenuTree() {
            OdinMenuTree tree = new OdinMenuTree();
            tree.AddRange(EditorSerialization.LoadScriptableObjects<T>(), effect => $"{TabName}/{effect.name} : {effect.GetHashCode()}");
            return tree;
        }

        [HorizontalGroup("CreateNew")] [GUIColor(0.7f, 0.7f, 1.0f)]
        [Button] public void CreateNew() {
            if(string.IsNullOrEmpty(_nameForNew) || string.IsNullOrWhiteSpace(_nameForNew))
                return;

            T newItem = ScriptableObject.CreateInstance<T>();
            
            AssetDatabase.CreateAsset(newItem, "Assets/ScriptableObjects/" + "\\" + _nameForNew + ".asset");
            AssetDatabase.SaveAssets();

            _nameForNew = "";
        }
        
        [HorizontalGroup("CreateNew")] [GUIColor(1.0f, 0.7f, 0.7f)]
        [Button] public void DeleteSelected() {
            if(_selected == null)
                return;
            string path = AssetDatabase.GetAssetPath(_selected);
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.SaveAssets();
            _selected = null;
        }
        
        [PropertySpace(20)] [HideLabel] [ShowInInspector] [PropertyOrder(-1)]
        [ReadOnly] private string _spacer => _selected?.name ?? "";
        
    }
    
}
