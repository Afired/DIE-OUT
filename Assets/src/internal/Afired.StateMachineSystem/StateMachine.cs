using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    [DefaultExecutionOrder(-50)]
    public abstract class StateMachine<T1> : MonoBehaviour where T1 : IStateMachineParameter, new() {
        
        [field: SerializeField] public State StartingState { get; private set; }
        [field: Space]
        [field: SerializeField] public T1 Parameter { get; private set; } = new T1();
        private ICollection<State> _states;
        private ICollection<ITransition> _transitions;
        private State _currentState;
        
        private void Awake() {
            _states = GetComponents<State>();
            _transitions = GetComponents<ITransition>();
            _currentState = StartingState;
            StartingState.OnStateEnter();
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
            
            foreach(ITransition transition in _transitions.Where(x => x.GetInState() == _currentState.GetType())) {
                if(!TryToGetStateOfType(transition.GetOutState(), out nextState))
                    throw new Exception();
                if(transition.ShouldTransition(_currentState, nextState))
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
