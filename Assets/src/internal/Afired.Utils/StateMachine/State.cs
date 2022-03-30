using System;
using UnityEngine;

namespace Afired.Utils.StateMachine {
    
    public abstract class State : MonoBehaviour {
        
        protected Animator Animator { get; private set; }
        protected AnimatorStateInfo StateInfo { get; private set; }
        protected int LayerIndex { get; private set; }
        private bool _stateIsActive = false;
        
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
        
        internal void InvokeStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
            OnStateEnter();
            _stateIsActive = true;
        }
        
        internal void InvokeStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            UpdateData(animator, stateInfo, layerIndex);
        }
        
        private void Update() {
            if(_stateIsActive)
                OnStateUpdate();
        }
        
        internal void InvokeStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            _stateIsActive = false;
            UpdateData(animator, stateInfo, layerIndex);
            OnStateExit();
        }
        
        private void UpdateData(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            Animator = animator;
            StateInfo = stateInfo;
            LayerIndex = layerIndex;
        }
        
    }
    
}
