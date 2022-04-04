using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    [DefaultExecutionOrder(-50)]
    public /*abstract*/ class StateMachine<TStateMachine> : MonoBehaviour, IStateMachine where TStateMachine : StateMachine<TStateMachine>, new() {
        
        [field: SerializeField] public State<TStateMachine> StartingState { get; private set; }
        private ICollection<IState<TStateMachine>> _states;
        private ICollection<ITransition<TStateMachine>> _transitions;
        private IState<TStateMachine> _currentState;
        
        private void Awake() {
            
            _states = GetComponents<IState<TStateMachine>>();
            _transitions = GetComponents<ITransition<TStateMachine>>();
            
            _currentState = StartingState;
            _currentState.OnStateEnter(this as TStateMachine);
        }
        
        private void Update() {
            if(TryToTransition(out IState<TStateMachine> nextState)) {
                _currentState.OnStateExit(this as TStateMachine);
                _currentState = nextState;
                _currentState.OnStateEnter(this as TStateMachine);
            }
            _currentState.OnStateUpdate(this as TStateMachine);
        }
        
        private bool TryToTransition(out IState<TStateMachine> nextState) {
            
            foreach(ITransition<TStateMachine> transition in _transitions.Where(x => x.GetInState() == _currentState.GetType())) {
                if(!TryToGetStateOfType(transition.GetOutState(), out nextState))
                    throw new Exception();
                if(transition.ShouldTransition(_currentState, nextState, this as TStateMachine))
                    return true;
            }
            nextState = null;
            return false;
        }
        
        private bool TryToGetStateOfType(Type type, out IState<TStateMachine> result) {
            foreach(IState<TStateMachine> state in _states) {
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
