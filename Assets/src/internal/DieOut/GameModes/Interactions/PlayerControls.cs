﻿using System.Collections;
using Afired.PartyGame.Characters;
using Afired.PartyGame.GameModes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(Movable))]
    public class PlayerControls : MonoBehaviour, IDeviceReceiver, IAnimatorReceiver {

        private Animator _animator;
        
        public bool HasControl = true;
        [Header("Settings")]
        [SerializeField] private float _cameraAngle = 45f;
        [SerializeField] [Range(0f, 10f)] public float _movementSpeed = 5f;
        [SerializeField] public float _jumpForce = 15f;
        [SerializeField] private float _jumpInputBufferTime = 0.1f;
        
        private Vector2 _moveInput;
        private bool _jumpInputBuffer;
        private IEnumerator _clearJumpInputBuffer;
        private Movable _movable;

        //references
        private Camera _mainCamera;
        private InputTable _inputTable;

        public Quaternion _direction;


        private void Awake() {
            _mainCamera = Camera.main;
            _movable = GetComponent<Movable>();

            _inputTable = new InputTable();
            _inputTable.CharacterControls.Jump.performed += OnJumpInput;
        }
        
        public void ReceiveDevices(InputDevice[] devices) {
            _inputTable.devices = devices;
        }
        
        public void ReceiveAnimator(Animator animator) {
            _animator = animator;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnJumpInput(InputAction.CallbackContext ctx) {
            if(!HasControl)
                return;
            
            _jumpInputBuffer = true;
    
            if(_clearJumpInputBuffer != null)
                StopCoroutine(_clearJumpInputBuffer);
    
            _clearJumpInputBuffer = ClearJumpInputBuffer();
            
            StartCoroutine(_clearJumpInputBuffer);
        }

        private IEnumerator ClearJumpInputBuffer() {
            yield return new WaitForSeconds(_jumpInputBufferTime);
            _jumpInputBuffer = false;
        }

        private void Update() {
            UpdateInputs();
            UpdateMovable();
            UpdateRotation();
            UpdateJump();
            _animator.SetBool(AnimatorStringHashes.IsGrounded, _movable.IsGrounded);
        }

        private void UpdateJump() {
            if(_jumpInputBuffer && _movable.IsGrounded) {
                _animator.SetTrigger(AnimatorStringHashes.TriggerJump);
                _movable.AddVelocity(new Vector3(0, _jumpForce, 0));
                if(_clearJumpInputBuffer != null)
                    StopCoroutine(_clearJumpInputBuffer);
                _jumpInputBuffer = false;
            }
        }

        private void UpdateInputs() {
            _cameraAngle = _mainCamera.transform.rotation.eulerAngles.y;
            _moveInput = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
        }

        private void UpdateMovable() {
            if(!HasControl) {
                _animator.SetFloat(AnimatorStringHashes.WalkingSpeed, 0f);
                return;
            }
            _movable.Move(Quaternion.Euler(0, _cameraAngle, 0) * new Vector3(_moveInput.x, 0, _moveInput.y) * _movementSpeed * Time.deltaTime);
            _animator.SetFloat(AnimatorStringHashes.WalkingSpeed, _moveInput.magnitude* _movementSpeed);
        }

        private void UpdateRotation() {
            if(!HasControl)
                return;
            if (_moveInput.magnitude != 0) {
                _direction = Quaternion.LookRotation(Quaternion.Euler(0, _cameraAngle, 0) *
                                                     new Vector3(_moveInput.x, 0, _moveInput.y));
                transform.SetPositionAndRotation(transform.position, _direction);
            }
        }
        
    }
    
}
