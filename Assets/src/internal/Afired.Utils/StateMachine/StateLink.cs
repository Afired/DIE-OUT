using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Afired.Utils.StateMachine {
    
    public class StateLink : SerializedStateMachineBehaviour {
        
        //[TypeFilter()]
        [OdinSerialize] private Type _linkedType;
        private State _linkedState;

        private void Init(Animator animator) {
            _linkedState = (animator.GetComponent(_linkedType) as State)!;
            if(_linkedState == null)
                throw new Exception($"Couldn't find linked state '{_linkedType.FullName}' on object '{animator.gameObject.name}'");
        }
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            Init(animator);
            _linkedState.InvokeStateEnter(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if(!animator.gameObject.activeSelf)
                return;
            
            _linkedState.InvokeStateUpdate(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            _linkedState.InvokeStateExit(animator, stateInfo, layerIndex);
        }
        
    }
    
//    public class StateLink : SerializedStateMachineBehaviour {
//        
//        //[TypeFilter()]
//        [OdinSerialize] private Type _linkedType;
//        private State _linked;
//        private bool _firstFrameHappened;
//        private bool _lastFrameHappened;
//
//        private void Init(Animator animator) {
//            _linked = (animator.GetComponent(_linkedType) as State)!;
//        }
//        
//        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//            Init(animator);
//            
//            _firstFrameHappened = false;
//            _linked.InvokeStateEnterTransition(animator, stateInfo, layerIndex);
//        }
//        
//        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//            
//            if(!animator.gameObject.activeSelf)
//                return;
//            
//            if(animator.IsInTransition(layerIndex) && animator.GetNextAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash)
//                _linked.InvokeStateEnterTransitionUpdate(animator, stateInfo, layerIndex);
//            
//            if(!animator.IsInTransition(layerIndex) && _firstFrameHappened)
//                _linked.InvokeStateUpdate(animator, stateInfo, layerIndex);
//            
//            if(animator.IsInTransition(layerIndex) && !_lastFrameHappened && _firstFrameHappened) {
//                _lastFrameHappened = true;
//                _linked.InvokeStateExit(animator, stateInfo, layerIndex);
//            }
//            
//            if(!animator.IsInTransition(layerIndex) && !_firstFrameHappened) {
//                _firstFrameHappened = true;
//                _linked.InvokeStateEnter(animator, stateInfo, layerIndex);
//            }
//            
//            if(animator.IsInTransition(layerIndex) && animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash)
//                _linked.InvokeStateExitTransitionUpdate(animator, stateInfo, layerIndex);
//        }
//        
//        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//            _lastFrameHappened = false;
//            _linked.InvokeStateExitTransition(animator, stateInfo, layerIndex);
//        }
//        
//    }
    
}
