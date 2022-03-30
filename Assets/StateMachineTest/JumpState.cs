using Afired.Utils.StateMachine;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace StateMachineTest {
    
    [RequireComponent(typeof(Movable))]
    public class JumpState : State {
        
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateEnter() {
            _movable.AddVelocity(new Vector3(0, 10, 0));
        }
        
    }
    
}
