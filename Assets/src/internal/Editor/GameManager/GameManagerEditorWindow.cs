using System.Collections.Generic;
using System.Linq;
using Afired.GameManagement.Characters;
using Afired.GameManagement.GameModes;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    internal class GameManagerEditorWindow : OdinMenuEditorWindow {
        
        private int _currentTabIndex = 0;
        private IGameManagerTab CurrentTab => _tabs.ElementAtOrDefault(_currentTabIndex);
        
        private readonly List<IGameManagerTab> _tabs = new List<IGameManagerTab>() {
            new DrawScriptableObjectTree<GameMode>("Game Modes"),
            new DrawScriptableObjectTree<Character>("Characters"),
            new DrawScriptableObject<SessionSettings>("Session Settings"),
        };
        
        private bool _menuTreeIsDirty = false;
        private int _headerIndex;
        
        [MenuItem("Afired/Game Manager")]
        public static void OpenWindow() {
            GetWindow<GameManagerEditorWindow>("Game Manager").Show();
        }
        
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
