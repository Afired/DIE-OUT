using System.Collections.Generic;
using Afired.PartyGame.Characters;
using Afired.PartyGame.GameModes;
using Afired.PartyGame.Sessions;
using Afired.Utils.Editor.GameManager;
using UnityEditor;

namespace Afired.PartyGame.Editor {
    
    public class PartyGameAssetManagerWindow : GameManagerEditorWindow {
        
        [MenuItem("DieOut/Game Manager")]
        public static void OpenWindow() {
            GetWindow<PartyGameAssetManagerWindow>("Game Manager").Show();
        }
        
        protected override void Init(out IEnumerable<IGameManagerTab> gameManagerTabs) {

            gameManagerTabs = new IGameManagerTab[] {
                new DrawScriptableObjectTree<GameMode>("Game Modes"),
                new DrawScriptableObjectTree<Character>("Characters"),
                new DrawScriptableObject<SessionSettings>("Session Settings"),
            };

        }
        
    }
    
}
