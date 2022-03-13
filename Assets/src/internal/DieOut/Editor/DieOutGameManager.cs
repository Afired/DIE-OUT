using System.Collections.Generic;
using Afired.PartyGame.Characters;
using Afired.PartyGame.GameModes;
using Afired.PartyGame.Sessions;
using Afired.Utils.Editor.GameManager;
using UnityEditor;

namespace DieOut.DieOut.Editor {
    
    public class DieOutGameManager : GameManagerEditorWindow {
        
        [MenuItem("DieOut/Game Manager")]
        public static void OpenWindow() {
            GetWindow<DieOutGameManager>("Game Manager").Show();
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
