using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingState : State {

        [SerializeField] private CharacterStateMachine _csm;
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        public override void OnStateUpdate() {
            Vector2 horizontalMovement = _csm.Parameter.HorizontalInput * Time.deltaTime * 10f;
            _movable.Move(new Vector3(horizontalMovement.x, -5f * Time.deltaTime, horizontalMovement.y));
            _movable.SetVelocity(new Vector3(0, 0, 0));
        }
        
    }
    
}
