using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [DefaultExecutionOrder(-60)]
    public class PlayerInput : MonoBehaviour {
        
        [SerializeField] private CharacterStateMachine _csm;
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
        
        private void Update() {
            UpdateParameters();
        }
        
        private void UpdateParameters() {
            _csm.Parameter.HorizontalInput = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
            _csm.Parameter.JumpInput = _inputTable.CharacterControls.Jump.ReadValue<float>() != 0;
        }
        
        private void OnDestroy() {
            _inputTable.Dispose();
        }
        
    }
    
}
