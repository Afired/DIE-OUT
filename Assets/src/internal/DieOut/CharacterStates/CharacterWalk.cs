using System;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    public class CharacterWalk : CharacterBehaviour {
        
        private InputTable _inputTable;
        
        private void Awake() {
            if(_inputTable == null)
                _inputTable = new InputTable();
            _inputTable.Enable();
        }

        public override void OnUpdateState(CharacterStatemachine characterStatemachine) {
            Vector2 inputAxis = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
            characterStatemachine.SetParameter("WalkingSpeed", inputAxis.magnitude);
        }
        
    }
    
}
