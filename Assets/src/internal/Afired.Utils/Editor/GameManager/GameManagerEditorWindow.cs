using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Afired.Utils.Editor.GameManager {
    
    public abstract class GameManagerEditorWindow : OdinMenuEditorWindow {
        
        private int _currentTabIndex = 0;
        private IGameManagerTab CurrentTab => _tabs.ElementAtOrDefault(_currentTabIndex);

        private IGameManagerTab[] _tabs;
        
        private bool _menuTreeIsDirty = false;
        private int _headerIndex;
        
        protected void Awake() {
            Init(out IEnumerable<IGameManagerTab> gameManagerTabs);
            _tabs = gameManagerTabs.ToArray();
        }
        
        protected abstract void Init(out IEnumerable<IGameManagerTab> gameManagerTabs);
        
        protected override void Initialize() {
            CurrentTab.OnInitialize();
        }
        
        private void OnTabChange() {
            _menuTreeIsDirty = true;
            CurrentTab.OnInitialize();
        }
        
        protected override void OnGUI() {
            if(_menuTreeIsDirty && Event.current.type == EventType.Layout) {
                ForceMenuTreeRebuild();
                _menuTreeIsDirty = false;
            }
            
            SirenixEditorGUI.Title("Game Manager", CurrentTab.TabName, TextAlignment.Center, true);
            EditorGUILayout.Space();
            
            if(TabButtonGroup.Draw(ref _currentTabIndex, _tabs.Select(tab => tab.TabName).ToArray()))
                OnTabChange();
            
            if(CurrentTab.ShouldDrawEditor)
                DrawEditor(_headerIndex);
            
            base.OnGUI();
        }
        
        protected override void DrawEditors() {
            CurrentTab.SetSelected(MenuTree.Selection.SelectedValue);
            DrawEditor(_currentTabIndex);
        }
        
        protected override IEnumerable<object> GetTargets() {
            List<object> targets = new List<object>();
            
            targets.AddRange(_tabs);
            targets.Add(base.GetTarget());
            
            _headerIndex = targets.Count - 1;
            return targets;
        }
        
        protected override void DrawMenu() {
            if(CurrentTab.ShouldDrawBaseMenu)
                base.DrawMenu();
        }

        protected override OdinMenuTree BuildMenuTree() {
            return CurrentTab.BuildMenuTree();
        }
        
    }
    
}
