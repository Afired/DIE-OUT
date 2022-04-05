using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(Movable))]
    public class FallingState : State<CharacterStateMachine> {

        [SerializeField] private float _fallingSpeed = -1f;
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateUpdate(CharacterStateMachine stateMachine) {
            Vector2 horizontalMovement = stateMachine.Parameter.HorizontalInput * Time.deltaTime * 10f;
            _movable.Move(new Vector3(horizontalMovement.x, 0, horizontalMovement.y));
            _movable.AddVelocity(new Vector3(0, _fallingSpeed * Time.deltaTime, 0));
        }
        
    }
    
}
