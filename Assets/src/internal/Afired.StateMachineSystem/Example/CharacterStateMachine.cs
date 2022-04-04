using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class CharacterStateMachine : StateMachine<CharacterStateMachine> {
        
        [field: SerializeField] public CharacterParameter Parameter { get; private set; }
        
    }
    
}
