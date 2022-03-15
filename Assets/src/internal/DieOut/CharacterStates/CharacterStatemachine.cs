using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    public class CharacterStatemachine : SerializedMonoBehaviour {
        
        [OdinSerialize] private Dictionary<string, float> _floatParameters = new Dictionary<string, float>();
        [SerializeField] private CharacterState _currentState;
        [SerializeField] private Transition[] _transitions;

        public float GetParameterByName(string parameterName) {
            return _floatParameters[parameterName];
        }
        
        public void SetParameter(string parameterName, float value) {
            _floatParameters[parameterName] = value;
        }
        
        private void Update() {
            TestForTransition();
            _currentState.OnStateUpdate(this);
        }
        
        private void TestForTransition() {
            foreach(Transition transition in _transitions) {
                if(transition.CharacterStateIn != _currentState)
                    continue;
                if(transition.IsTrue(this)) {
                    TransitionTo(transition.CharacterStateOut);
                    return;
                }
            }
        }

        private void TransitionTo(CharacterState newCharacterState) {
            _currentState.OnStateExit(this);
            _currentState = newCharacterState;
            _currentState.OnStateEnter(this);
        }
        
    }
    
}
