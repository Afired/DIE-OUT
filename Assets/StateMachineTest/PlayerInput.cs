using Afired.Utils.StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace StateMachineTest {
    
    [RequireComponent(typeof(Animator))]
    public class PlayerInput : MonoBehaviour {
        
        [SerializeField] private bool _isController;
        private InputTable _inputTable;
        private Animator _animator;
        
        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.devices = new InputDevice[] { _isController ? Gamepad.current as InputDevice : Keyboard.current as InputDevice };
            _animator = GetComponent<Animator>();
            _inputTable.CharacterControls.Jump.performed += (_) => _animator.SetBool("input.jump", true);
            _inputTable.CharacterControls.Jump.canceled += (_) => _animator.SetBool("input.jump", false);
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
