﻿using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingState : State {

        [SerializeField] private Movable _movable;
        
        public override void OnStateEnter() {
            _movable.SetVelocity(new Vector3(0, 10, 0));
        }
        
    }
    
}
