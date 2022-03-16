using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Afired.Utils.StatemachineExtensions {
    
    public class StateMachineLink : SerializedStateMachineBehaviour {
        
        //[TypeFilter()]
        [OdinSerialize] private Type _linkedType;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            (animator.GetComponent(_linkedType) as StateMachineMonoBehaviour).OnStateEnter(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            (animator.GetComponent(_linkedType) as StateMachineMonoBehaviour).OnStateExit(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            (animator.GetComponent(_linkedType) as StateMachineMonoBehaviour).OnStateUpdate(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            (animator.GetComponent(_linkedType) as StateMachineMonoBehaviour).OnStateMove(animator, stateInfo, layerIndex);
        }
        
        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            (animator.GetComponent(_linkedType) as StateMachineMonoBehaviour).OnStateIK(animator, stateInfo, layerIndex);
        }
        
    }
    
}
