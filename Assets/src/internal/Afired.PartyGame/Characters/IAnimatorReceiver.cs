using UnityEngine;

namespace Afired.PartyGame.Characters {
    
    /// <summary>
    /// interface for custom injection of animator component
    /// </summary>
    public interface IAnimatorReceiver {
        
        public void ReceiveAnimator(Animator animator);
        
    }
    
}
