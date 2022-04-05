using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    [DefaultExecutionOrder(-50)]
    public abstract class StateMachine<TStateMachine> : MonoBehaviour, IStateMachine where TStateMachine : StateMachine<TStateMachine>, new() {
        
        [field: SerializeField] public State<TStateMachine> StartingState { get; private set; }
        private ICollection<IState<TStateMachine>> _states;
        private ICollection<ITransition<TStateMachine>> _transitions;
        protected IState<TStateMachine> CurrentState { get; private set; }
        
        private void Awake() {
            
            _states = GetComponents<IState<TStateMachine>>();
            _transitions = GetComponents<ITransition<TStateMachine>>();
            
            CurrentState = StartingState;
            CurrentState.OnStateEnter(this as TStateMachine);
        }
        
        private void Update() {
            if(TryToTransition(out IState<TStateMachine> nextState)) {
                CurrentState.OnStateExit(this as TStateMachine);
                CurrentState = nextState;
                CurrentState.OnStateEnter(this as TStateMachine);
            }
            CurrentState.OnStateUpdate(this as TStateMachine);
        }
        
        private bool TryToTransition(out IState<TStateMachine> nextState) {
            
            foreach(ITransition<TStateMachine> transition in _transitions.Where(x => x.GetInState() == CurrentState.GetType())) {
                if(!TryToGetStateOfType(transition.GetOutState(), out nextState))
                    throw new Exception();
                if(transition.ShouldTransition(CurrentState, nextState, this as TStateMachine))
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
