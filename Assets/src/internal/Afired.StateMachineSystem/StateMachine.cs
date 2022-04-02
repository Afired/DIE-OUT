using System;
using System.Collections.Generic;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class StateMachine : MonoBehaviour {
        
        private ICollection<IState> _states;
        private IState _currentState;
        
        protected abstract void Init(out ICollection<IState> states, out ICollection<ITransition<IState>> transitions, out IState startingState);
        
        private void Awake() {
            Init(out _states, out ICollection<ITransition<IState>> transitions, out IState startingState);
            _currentState = startingState ?? throw new ArgumentNullException();
        }
        
        private void Update() {
            if(TryToTransition(out IState nextState)) {
                _currentState.OnStateExit();
                _currentState = nextState;
                _currentState.OnStateEnter();
            }
            _currentState.OnStateUpdate();
        }
        
        private bool TryToTransition(out IState nextState) {
            if(_currentState.TryToTransition(out Type nextStateType)) {
                if(TryToGetStateOfType(nextStateType, out IState state)) {
                    nextState = state;
                    return true;
                }
            }
            nextState = null;
            return false;
        }
        
        private bool TryToGetStateOfType(Type type, out IState result) {
            foreach(IState state in _states) {
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
