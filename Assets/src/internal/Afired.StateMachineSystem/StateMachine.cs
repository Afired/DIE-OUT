using System;
using System.Collections.Generic;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class StateMachine : MonoBehaviour {

        private ICollection<IState> _states;
        private Dictionary<IState, IList<(Func<bool> condition, IState endState)>> _hashedTransitions;
        private TransitionLookup _transitionLookup;
        
        private IState _currentState;
        
        private void Awake() {
            Init(out _states, out ICollection<ITransition<IState, IState>> transitions, out IState startingState);

            _currentState = startingState ?? throw new ArgumentNullException();

            BuildTransitionLookup(transitions);
        }
        
        private void Update() {
            if(TryToTransition(out IState nextState)) {
                _currentState.OnStateExit();
                _currentState = nextState;
                _currentState.OnStateEnter();
            }
            _currentState.OnStateUpdate();
        }
        
        private void BuildTransitionLookup(IEnumerable<ITransition<IState, IState>> transitions) {
            _transitionLookup = new TransitionLookup();
            foreach(ITransition<IState,IState> transition in transitions) {
                
                foreach(Type interfaceType in transition.GetType().GetInterfaces()) {
                    if(!interfaceType.IsGenericType || interfaceType.GetGenericTypeDefinition() != typeof(ITransition<,>))
                        continue;
                    
                    Type fistStateType = interfaceType.GetGenericArguments()[0];
                    Type secondStateType = interfaceType.GetGenericArguments()[1];

                    if(TryToGetStateOfType(fistStateType, out IState firstState) && TryToGetStateOfType(secondStateType, out IState secondState))
                        _transitionLookup.Add(firstState, new RuntimeTransition(transition.TestCondition, secondState));
                    else
                        throw new Exception("invalid generic state type parameter of transition: can't transition from or to a state that is not contained in the state machine");
                    
                    break;
                }
            }
        }

        private bool TryToTransition(out IState nextState) {
            foreach(RuntimeTransition runtimeTransition in _transitionLookup.GetTransitionsFor(_currentState)) {
                if(runtimeTransition.Condition.Invoke()) {
                    nextState = runtimeTransition.NextState;
                    return true;
                }
            }
            nextState = default;
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
        
        protected abstract void Init(out ICollection<IState> states, out ICollection<ITransition<IState, IState>> transitions, out IState startingState);
        
    }
    
}
