using System;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [Serializable]
    public class JumpTransition : ITransition<JumpingState> {
        
        public bool TestCondition() {
            Debug.Log("Testing");
            return Input.GetKeyDown(KeyCode.Space);
        }
        
    }
    
}
