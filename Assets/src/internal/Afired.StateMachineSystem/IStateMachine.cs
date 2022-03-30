using System.Collections.Generic;

namespace Afired.StateMachineSystem {
    
    public interface IStateMachine {
        
        IList<ITransition<IState, IState>> _transitions { get; set; }
        
    }
    
}
