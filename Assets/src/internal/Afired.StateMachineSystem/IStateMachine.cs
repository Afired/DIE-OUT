using System.Collections.Generic;

namespace Afired.StateMachineSystem {
    
    public interface IStateMachine {
        
        IList<ITransition<IState>> _transitions { get; set; }
        
    }
    
}
