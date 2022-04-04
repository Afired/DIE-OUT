using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(Movable))]
    public class JumpingState : State<CharacterStateMachine> {
        
        private Movable _movable;
        private Vector2 _horizontalDirection;
        public float TimeInJump { get; private set; }
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateEnter(CharacterStateMachine characterStateMachine) {
            _horizontalDirection = characterStateMachine.Parameter.HorizontalInput;
            _movable.SetVelocity(new Vector3(0, 10f, 0));
            TimeInJump = 0f;
        }
        
        protected override void OnStateUpdate(CharacterStateMachine characterStateMachine) {
            Vector2 horizontalMovement = _horizontalDirection * Time.deltaTime * 10f * 1.5f;
            _movable.Move(new Vector3(horizontalMovement.x, 0, horizontalMovement.y));
            TimeInJump += Time.deltaTime;
        }
        
    }
    
}
