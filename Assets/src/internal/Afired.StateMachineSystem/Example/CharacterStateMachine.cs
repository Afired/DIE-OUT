using System.Collections.Generic;
using System.Linq;

namespace Afired.StateMachineSystem.Example {
    
    public class CharacterStateMachine : StateMachine {
        
        protected override void Init(out ICollection<IState> states, out ICollection<ITransition<IState, IState>> transitions, out IState startingState) {
            states = GetComponents<IState>();
            transitions = new ITransition<IState, IState>[] {
                new WalkingJumpingTransition(),
            };
            startingState = states.FirstOrDefault();
        }
        
    }
    
}
