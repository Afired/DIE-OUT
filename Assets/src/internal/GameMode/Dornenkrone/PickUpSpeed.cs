using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace DieOut.GameMode.Dornenkrone {
    public class PickUpSpeed : MonoBehaviour {
    
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;

        private List<SpeedPickUp> _speedPickUps;
        private SpeedPickUp _speedPickUp;

        [SerializeField] private float _speedDuration = 5;
        private int _amountOfCollectedSpeedPickUps = 0;

        private void Awake() {
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;

            _speedPickUps = new List<SpeedPickUp>();
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            _speedPickUp = other.GetComponent<SpeedPickUp>();
            
            if (_speedPickUp != null) {
                _speedPickUps.Add(_speedPickUp);
            }
        }
        
        private void OnTriggerExit(Collider other) {
            _speedPickUp = other.GetComponent<SpeedPickUp>();
            
            if (_speedPickUp != null) {
                _speedPickUps.Remove(_speedPickUp);
            }
        }

        private IEnumerator SpeedDuration() {
            GetComponent<PlayerControls>()._movementSpeed = 10;
            yield return new WaitForSeconds(_speedDuration);
            _amountOfCollectedSpeedPickUps -= 1;
            
            if (_amountOfCollectedSpeedPickUps == 0) {
                GetComponent<PlayerControls>()._movementSpeed -= 4;
            }
        }
        
        private void OnPickUp(InputAction.CallbackContext _) {

            if (_speedPickUps.Count == 0) {
                return;
            }
            
            SpeedPickUp _targetSpeedPickUp = _speedPickUps
                .OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).First();

            _speedPickUps.Remove(_targetSpeedPickUp);
            _amountOfCollectedSpeedPickUps += 1;
            StartCoroutine(SpeedDuration());

            Destroy(_targetSpeedPickUp.gameObject);
        }
    }
}
