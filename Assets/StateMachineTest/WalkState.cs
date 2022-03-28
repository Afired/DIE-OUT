using System;
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
        
        protected override void OnStateEnterTransitionUpdate() => Move();
        protected override void OnStateUpdate() => Move();
        
        private void Move() {
            Vector2 horizontal = Animator.GetVector2("input.horizontal");
            _movable.Move(horizontal * Time.deltaTime * _speed);
        }
        
    }
    
}
