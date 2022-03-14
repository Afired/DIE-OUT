using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

namespace Afired.Utils.Triggers {
    
    public abstract class Trigger : MonoBehaviour {
        
        [SerializeField] private TriggerData _triggerData;
        private GameObject _linkedGameObject;
        private PositionConstraint _linkedPositionConstraint;
        private Rigidbody _linkedRigidbody;
        private TriggerHook _linkedTriggerHook;
        private Collider _linkedCollider;
        
        public void SetColliderType(ColliderType colliderType) {
            _triggerData.ColliderType = colliderType;
            UpdateColliderType();
        }

        protected virtual void OnTriggerEnterCallback(Collider other) { }
        protected virtual void OnTriggerStayCallback(Collider other) { }
        protected virtual void OnTriggerExitCallback(Collider other) { }
        
        private void Awake() {
            _linkedGameObject = new GameObject(gameObject.name + " (Trigger Object)");
            _linkedGameObject.transform.position = transform.position;
            _linkedGameObject.hideFlags = HideFlags.NotEditable | HideFlags.DontSave | HideFlags.HideInHierarchy | HideFlags.HideInInspector;
            
            _linkedPositionConstraint = _linkedGameObject.AddComponent<PositionConstraint>();
            _linkedPositionConstraint.SetSources(new List<ConstraintSource>() { new ConstraintSource() { sourceTransform = gameObject.transform, weight = 1 } });
            _linkedPositionConstraint.constraintActive = true;
            
            _linkedRigidbody = _linkedGameObject.AddComponent<Rigidbody>();
            _linkedRigidbody.useGravity = false;
            
            _linkedTriggerHook = _linkedGameObject.AddComponent<TriggerHook>();
            _linkedTriggerHook.OnTriggerEnterCallback += OnTriggerEnterCallback;
            _linkedTriggerHook.OnTriggerStayCallback += OnTriggerStayCallback;
            _linkedTriggerHook.OnTriggerExitCallback += OnTriggerExitCallback;
            
            UpdateColliderType();
        }
        
        private void Update() {
            #if UNITY_EDITOR
            if(_triggerData.ColliderTypeIsDirty)
                UpdateColliderType();
            else if(_triggerData.ColliderValuesAreDirty)
                UpdateColliderValues();
            #endif
        }
        
        private void UpdateColliderType() {
            if(_linkedCollider != null)
                Destroy(_linkedCollider);
            
            switch(_triggerData.ColliderType) {
                case ColliderType.Box:
                    _linkedCollider = _linkedGameObject.AddComponent<BoxCollider>();
                    break;
                case ColliderType.Capsule:
                    _linkedCollider = _linkedGameObject.AddComponent<CapsuleCollider>();
                    break;
                case ColliderType.Sphere:
                    _linkedCollider = _linkedGameObject.AddComponent<SphereCollider>();
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            
            _linkedCollider.isTrigger = true;
            #if UNITY_EDITOR
            _triggerData.ColliderTypeIsDirty = false;
            #endif
            UpdateColliderValues();
        }

        private void UpdateColliderValues() {
            switch(_triggerData.ColliderType) {
                case ColliderType.Box:
                    BoxCollider boxCollider = _linkedCollider as BoxCollider;
                    boxCollider!.center = _triggerData.Center;
                    boxCollider!.size = _triggerData.Size;
                    break;
                case ColliderType.Capsule:
                    CapsuleCollider capsuleCollider = _linkedCollider as CapsuleCollider;
                    capsuleCollider!.center = _triggerData.Center;
                    capsuleCollider!.height = _triggerData.Height;
                    capsuleCollider!.direction = (int) _triggerData.Direction;
                    capsuleCollider!.radius = _triggerData.Radius;
                    break;
                case ColliderType.Sphere:
                    SphereCollider sphereCollider = _linkedCollider as SphereCollider;
                    sphereCollider!.center = _triggerData.Center;
                    sphereCollider!.radius = _triggerData.Radius;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            #if UNITY_EDITOR
            _triggerData.ColliderValuesAreDirty = false;
            #endif
        }
        
        private void OnEnable() {
            _linkedGameObject.SetActive(true);
        }
        
        private void OnDisable() {
            if(_linkedGameObject != null)
                _linkedGameObject.SetActive(false);
        }
        
        private void OnDestroy() {
            if(_linkedGameObject != null)
                Destroy(_linkedGameObject);
        }
        
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            switch(_triggerData.ColliderType) {
                case ColliderType.Box:
                    Gizmos.DrawWireCube(transform.position + _triggerData.Center, _triggerData.Size);
                    break;
                case ColliderType.Capsule:
                    break;
                case ColliderType.Sphere:
                    Gizmos.DrawWireSphere(transform.position + _triggerData.Center, _triggerData.Radius);
                    break;
            }
        }
        
    }
    
}
