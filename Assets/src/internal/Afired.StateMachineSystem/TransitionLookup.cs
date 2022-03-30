using System.Collections.Generic;
using System.Linq;

namespace Afired.StateMachineSystem {
    
    public class TransitionLookup {
        
        private Dictionary<IState, List<RuntimeTransition>> _hashedTransitions;
        
        internal TransitionLookup() {
            _hashedTransitions = new Dictionary<IState, List<RuntimeTransition>>();
        }
        
        internal void Add(IState state, RuntimeTransition runtimeTransition) {
            //if entry doesnt exit create one
            if(!_hashedTransitions.TryGetValue(state, out List<RuntimeTransition> transitions)) {
                transitions = new List<RuntimeTransition>();
                _hashedTransitions.Add(state, transitions);
            }
            
            transitions.Add(runtimeTransition);
        }

        public IEnumerable<RuntimeTransition> GetTransitionsFor(IState state) {
            return !_hashedTransitions.TryGetValue(state, out List<RuntimeTransition> transitions) ? Enumerable.Empty<RuntimeTransition>() : transitions;
        }

    }
    
}
