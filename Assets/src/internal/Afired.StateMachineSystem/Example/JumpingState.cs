using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(Movable))]
    public class JumpingState : State {
        
        [SerializeField] private CharacterStateMachine _csm;
        private Movable _movable;
        private Vector2 _horizontalDirection;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        public override void OnStateEnter() {
            _horizontalDirection = _csm.Parameter.HorizontalInput;
            _movable.SetVelocity(new Vector3(0, 10f, 0));
        }
        
        public override void OnStateUpdate() {
            Vector2 horizontalMovement = _horizontalDirection * Time.deltaTime * 10f * 1.5f;
            _movable.Move(new Vector3(horizontalMovement.x, 0, horizontalMovement.y));
        }
        
    }
    
}
