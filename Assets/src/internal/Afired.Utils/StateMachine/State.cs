using UnityEngine;

namespace Afired.Utils.StateMachine {
    
    public abstract class State : MonoBehaviour {
        
        protected Animator Animator { get; private set; }
        protected AnimatorStateInfo StateInfo { get; private set; }
        protected int LayerIndex { get; private set; }
        
        /// <summary>
        /// Called before Updates when execution of the state first starts (on transition to the state).
        /// </summary>
        protected virtual void OnStateEnterTransition() { }
        
        /// <summary>
        /// Called after OnStateEnter every frame during transition to the state.
        /// </summary>
        protected virtual void OnStateEnterTransitionUpdate() { }
        
        /// <summary>
        /// Called on the first frame after the transition to the state has finished.
        /// </summary>
        protected virtual void OnStateEnter() { }
        
        /// <summary>
        /// Called every frame after PostEnter when the state is not being transitioned to or from.
        /// </summary>
        protected virtual void OnStateUpdate() { }
        
        /// <summary>
        /// Called on the first frame after the transition from the state has started.  Note that if the transition has a duration of less than a frame, this will not be called.
        /// </summary>
        protected virtual void OnStateExit() { }
        
        /// <summary>
        /// Called after OnStatePreExit every frame during transition to the state.
        /// </summary>
        protected virtual void OnStateExitTransitionUpdate() { }
        
        /// <summary>
        /// Called after Updates when execution of the state first finishes (after transition from the state).
        /// </summary>
        protected virtual void OnStateExitTransition() { }
        
        internal void InvokeStateEnterTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateEnterTransition();
        }
        
        internal void InvokeStateEnterTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateEnterTransitionUpdate();
        }
        
        internal void InvokeStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateEnter();
        }
        
        internal void InvokeStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateUpdate();
        }
        
        internal void InvokeStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateExit();
        }
        
        internal void InvokeStateExitTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateExitTransitionUpdate();
        }
        
        internal void InvokeStateExitTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateExitTransition();
        }
        
        private void UpdateData(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            Animator = animator;
            StateInfo = stateInfo;
            LayerIndex = layerIndex;
        }
        
    }
    
}
