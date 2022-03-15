using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    public sealed class CharacterState : MonoBehaviour {
        
        public string StateName => _stateName;
        
        [SerializeField] private string _stateName;
        [ListDrawerSettings(DraggableItems = false, Expanded = true, ShowItemCount = false)] [LabelText("@_stateName + \" Behaviours\"")]
        [SerializeField] private CharacterBehaviour[] _characterBehaviours;
        
        public void OnStateEnter(CharacterStatemachine characterStatemachine) {
            foreach(CharacterBehaviour characterBehaviour in _characterBehaviours) {
                characterBehaviour.OnEnterState(characterStatemachine);
            }
            Debug.Log("entered state " + _stateName);
        }
        
        public void OnStateUpdate(CharacterStatemachine characterStatemachine) {
            foreach(CharacterBehaviour characterBehaviour in _characterBehaviours) {
                characterBehaviour.OnUpdateState(characterStatemachine);
            }
        }
        
        public void OnStateExit(CharacterStatemachine characterStatemachine) {
            foreach(CharacterBehaviour characterBehaviour in _characterBehaviours) {
                characterBehaviour.OnExitState(characterStatemachine);
            }
            Debug.Log("exited state " + _stateName);
        }
        
    }
    
}
