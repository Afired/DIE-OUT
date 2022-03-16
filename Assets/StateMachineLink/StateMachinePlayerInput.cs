using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateMachinePlayerInput : MonoBehaviour {

    private InputTable _inputTable;
    private Animator _animator;
    
    private void Awake() {
        _inputTable = new InputTable();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        _inputTable.Enable();
    }

    private void OnDisable() {
        _inputTable.Disable();
    }

    private void Update() {
        _animator.SetFloat("input_horizontal", _inputTable.CharacterControls.Move.ReadValue<Vector2>().x);
    }
    
}
