using UnityEngine;

namespace Afired.Utils.StatemachineExtensions {
    
    public abstract class StateMachineMonoBehaviour : MonoBehaviour {
        
        public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        
    }
    
}
