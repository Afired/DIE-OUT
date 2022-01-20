using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine;

namespace DieOut.GameMode.Interactions {
    
    [RequireComponent(typeof(Collider))]
    public class Tackle : MonoBehaviour {
        
        [SerializeField] private DeviceTypes _deviceTypes;
        [SerializeField] private List<Tackleable> _tackleablesToIgnore;
        [SerializeField] private float _cooldown = 2f;
        [SerializeField] private float _stunDuration = 1f;
        [SerializeField] private float _immunity = 2f;
        private bool _onCooldown;
        private List<Tackleable> _otherPlayers = new List<Tackleable>();
        private InputTable _inputTable;
        
        
        private void Awake() {
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Tackle.performed += OnTackle;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            Tackleable tackleableComponent = other.gameObject.GetComponent<Tackleable>();
            
            if(tackleableComponent != null && !_tackleablesToIgnore.Contains(tackleableComponent)) {
                _otherPlayers.Add(tackleableComponent);
            }
        }

        private void OnTriggerExit(Collider other) {
            Tackleable tackleableComponent = other.gameObject.GetComponent<Tackleable>();
            
            if(tackleableComponent != null && !_tackleablesToIgnore.Contains(tackleableComponent)) {
                _otherPlayers.Remove(tackleableComponent);
            }
        }

        private IEnumerator TackleCooldown() {
            yield return new WaitForSeconds(_cooldown);
            Debug.Log("cooldown finished");
            _onCooldown = false;
        }

        private IEnumerator TackleStunDuration(Tackleable target) {
            yield return new WaitForSeconds(_stunDuration);
            Debug.Log("tackle stopped");
            target.GetComponent<PlayerController>()._movementSpeed = 5;
            target.GetComponent<PlayerController>()._jumpForce = 15;
        }

        private IEnumerator TackleImmunity(Tackleable target) {
            yield return new WaitForSeconds(_stunDuration + _immunity);
            Debug.Log("tackle immunity OFF");
            target.GetComponent<Tackleable>().tackleImmunity = false;
        }
        
        private void OnTackle(InputAction.CallbackContext _) {
            
            // dont do anything if tackle is on cooldown
            if(_onCooldown) {
                Debug.Log("tackle has cooldown");
                return;
            }
            
            // sort list according to distance from Player, exclude the once that have tackle immunity and then take first element in List
            Tackleable target = _otherPlayers
                .OrderBy(x => Vector2.Distance(this.transform.parent.position, x.transform.position)).
                FirstOrDefault(tackleable => !tackleable.tackleImmunity);
            
            // dont do anything if there is no target to tackle
            if(target == null) {
                Debug.Log("no target is in tackle range");
                return;
            }
            
            Debug.Log("tackling");
            transform.parent.position = target.transform.position;
            
            target.GetComponent<PlayerController>()._movementSpeed = 0;
            target.GetComponent<PlayerController>()._jumpForce = 0;
            
            _onCooldown = true;
            StartCoroutine(TackleCooldown());
            target.GetComponent<Tackleable>().tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity(target));
            StartCoroutine(TackleStunDuration(target));
        }
        
    }
    
}
