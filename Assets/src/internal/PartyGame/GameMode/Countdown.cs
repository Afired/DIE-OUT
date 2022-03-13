using System.Threading.Tasks;
using Afired.PartyGame.Sessions;
using UnityAsync;
using UnityEngine;

namespace Afired.PartyGame.GameModes {
    
    [RequireComponent(typeof(Animation))]
    public class Countdown : MonoBehaviour {
        
        private Animation _animation;

        private void Awake() {
            _animation = GetComponent<Animation>();
            Session.Current.GameModeInstance.OnGameModePrepare += Run;
        }
        
        private async Task Run() {
            if(_animation.clip != null) {
                _animation.Play();
                await Await.Seconds(_animation.clip.length);
            }
        }
        
    }
    
}
