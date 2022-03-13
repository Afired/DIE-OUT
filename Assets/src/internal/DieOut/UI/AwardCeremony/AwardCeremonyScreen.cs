using Afired.PartyGame.Sessions;
using Afired.SceneManagement;
using UnityEngine;

namespace DieOut.UI.AwardCeremony {
    
    public class AwardCeremonyScreen : MonoBehaviour {

        public void BackToMainMenu() {
            SceneManager.LoadScenesAsync(SceneRegister.MainMenu);
        }
        
    }
    
}
