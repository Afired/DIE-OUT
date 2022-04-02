﻿using System;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingState : State {

        [SerializeField] private Movable _movable;
        private InputTable _inputTable;
        
        private void Awake() {
            _inputTable = new InputTable();
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }
        
        private void OnDisable() {
            _inputTable.Disable();
        }
        
        public override void OnStateUpdate() {
            Vector2 _horizontalMovement = _inputTable.CharacterControls.Move.ReadValue<Vector2>() * Time.deltaTime * 10f;
            _movable.Move(new Vector3(_horizontalMovement.x, 0, _horizontalMovement.y));
        }
        
    }
    
}
