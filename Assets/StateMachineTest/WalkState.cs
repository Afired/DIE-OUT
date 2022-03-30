using Afired.Utils.StateMachine;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace StateMachineTest {
    
    [RequireComponent(typeof(Movable))]
    public class WalkState : State {

        [SerializeField] private float _speed = 10f;
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override void OnStateUpdate() {
            Vector2 horizontal = Animator.GetVector2("input.horizontal");
            _movable.Move(new Vector3(horizontal.x, 0, horizontal.y) * Time.deltaTime * _speed);
        }
        
    }
    
}
