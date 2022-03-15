using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    public class CharacterStatemachine : SerializedMonoBehaviour {
        
        [LabelText("@\"Current State: \" + _currentState?.StateName ?? \"null\"")]
        [SerializeField] private CharacterState _currentState;
        [OdinSerialize] private Dictionary<string, float> _floatParameters = new Dictionary<string, float>();
        [SerializeField] private Transition[] _transitions;

        public float GetParameterByName(string parameterName) {
            if(!_floatParameters.TryGetValue(parameterName, out float value))
                throw new Exception($"couldn't find parameter '{parameterName}'");
            return value;
        }
        
        public void SetParameter(string parameterName, float value) {
            if(!_floatParameters.ContainsKey(parameterName))
                throw new Exception($"couldn't find parameter '{parameterName}'");
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
