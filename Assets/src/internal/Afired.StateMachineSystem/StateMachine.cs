using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    [InfoBox("@InfoMessage")]
    public abstract class StateMachine : MonoBehaviour {
        
        [SerializeField] private State _startingState;
        private ICollection<State> _states;
        private ICollection<ITransition> _transitions;
        private State _currentState;
        
        private void Awake() {
            _states = GetComponents<State>();
            _transitions = GetComponents<ITransition>();
            _currentState = _startingState;
            _startingState.OnStateEnter();
        }

        private string InfoMessage => $"{gameObject.GetComponents<State>().Length} States | {gameObject.GetComponents<ITransition>().Length} Transitions";
        
        private void Update() {
            if(TryToTransition(out State nextState)) {
                _currentState.OnStateExit();
                _currentState = nextState;
                _currentState.OnStateEnter();
            }
            _currentState.OnStateUpdate();
        }
        
        private bool TryToTransition(out State nextState) {
            
            foreach(ITransition transition in _transitions.Where(x => x.GetInState() == _currentState.GetType() && x.TestCondition())) {
                if(!TryToGetStateOfType(transition.GetOutState(), out nextState))
                    throw new Exception();
                
                return true;
            }
            
            nextState = null;
            return false;
        }
        
        private bool TryToGetStateOfType(Type type, out State result) {
            foreach(State state in _states) {
                if(state.GetType() == type) {
                    result = state;
                    return true;
                }
            }
            result = null;
            return false;
        }
        
    }
    
}
