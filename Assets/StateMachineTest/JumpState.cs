using Afired.Utils.StateMachine;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace StateMachineTest {
    
    [RequireComponent(typeof(Movable))]
    public class JumpState : State {

        [SerializeField] private float _speed = 10f;
        private Movable _movable;
        private Vector2 _horizontal;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateEnter() {
            _horizontal = Animator.GetVector2("input.horizontal");
            _movable.AddVelocity(new Vector3(0, 10, 0));
        }
        
        protected override void OnStateUpdate() {
            _movable.Move(new Vector3(_horizontal.x, 0, _horizontal.y) * Time.deltaTime * _speed);
        }
        
    }
    
}
