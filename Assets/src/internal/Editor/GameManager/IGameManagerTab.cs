using Sirenix.OdinInspector.Editor;

namespace DieOut.Editor.GameManager {
    
    public interface IGameManagerTab {
        
        public string TabName { get; }
        public void OnInitialize();
        public bool ShouldDrawEditor { get; }
        public void SetSelected(object item);
        public bool ShouldDrawBaseMenu { get; }
        public OdinMenuTree BuildMenuTree();

    }
    
}
