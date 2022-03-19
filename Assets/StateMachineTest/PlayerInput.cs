using Afired.Utils.StateMachine;
using UnityEngine;

namespace StateMachineTest {
    
    [RequireComponent(typeof(Animator))]
    public class PlayerInput : MonoBehaviour {
        
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
            _animator.SetVector2("input.horizontal", _inputTable.CharacterControls.Move.ReadValue<Vector2>());
        }
        
    }
    
}
