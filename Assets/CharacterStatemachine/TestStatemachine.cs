using System;
using UnityEngine;
using StateMachineBehaviour = Bg.UniTaskStateMachine.StateMachineBehaviour;

namespace CharacterStatemachine {
    
    public class TestStatemachine : StateMachineBehaviour {
        
        private float _time;
        
        private void Update() {
            _time += Time.deltaTime;
        }
        
        public bool TestForSomeTransition() {
            return _time > 10f;
        }
        
    }
    
}
