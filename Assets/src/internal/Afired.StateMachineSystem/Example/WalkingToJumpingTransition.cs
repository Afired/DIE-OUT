using System;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingToJumpingTransition : Transition<WalkingState, JumpingState> {
        
        private InputTable _inputTable;
        
        private void Awake() {
            _inputTable = new InputTable();
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }
        
        private void OnDisable() {
            _inputTable.Disable();
        }
        
        public override bool TestCondition() {
            return _inputTable.CharacterControls.Jump.ReadValue<float>() != 0;
        }
        
    }
    
}
