using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(Movable))]
    public class WalkingState : State<CharacterStateMachine> {
        
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateUpdate(CharacterStateMachine characterStateMachine) {
            Vector2 horizontalMovement = characterStateMachine.Parameter.HorizontalInput * Time.deltaTime * 10f;
            _movable.Move(new Vector3(horizontalMovement.x, -5f * Time.deltaTime, horizontalMovement.y));
            _movable.SetVelocity(new Vector3(0, 0, 0));
        }
        
    }
    
}
