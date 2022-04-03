using System;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [Serializable]
    public class CharacterParameter : IStateMachineParameter {
        
        public Vector2 HorizontalInput;
        public bool JumpInput;
        public bool IsGrounded;
        
    }
    
}
