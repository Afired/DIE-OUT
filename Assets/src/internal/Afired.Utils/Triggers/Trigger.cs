using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

namespace Afired.Utils.Triggers {
    
    public abstract class Trigger : MonoBehaviour {
        
        [Header("Collider")]
        [SerializeField] private ColliderType _colliderType;
        [SerializeField] private Vector3 _center = Vector3.zero;
        [SerializeField] private Vector3 _size = Vector3.one;
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private float _height = 1f;
        [SerializeField] private Axis _direction = Axis.Y;
        
        private GameObject _linkedGameObject;
        private PositionConstraint _linkedPositionConstraint;
        private Rigidbody _linkedRigidbody;
        private TriggerHook _linkedTriggerHook;
        private Collider _linkedCollider;
        #if UNITY_EDITOR
        [SerializeField] private bool _colliderTypeIsDirty;
        [SerializeField] private bool _colliderValuesAreDirty;
        #endif
        
        public void SetColliderType(ColliderType colliderType) {
            _colliderType = colliderType;
            UpdateColliderType();
        }

        protected virtual void OnTriggerEnterCallback(Collider other) { }
        protected virtual void OnTriggerStayCallback(Collider other) { }
        protected virtual void OnTriggerExitCallback(Collider other) { }
        
        private void Awake() {
            _linkedGameObject = new GameObject(gameObject.name + " (Trigger Object)");
            _linkedGameObject.transform.position = transform.position;
            
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
            if(_colliderTypeIsDirty)
                UpdateColliderType();
            else if(_colliderValuesAreDirty)
                UpdateColliderValues();
            #endif
        }
        
        private void UpdateColliderType() {
            if(_linkedCollider != null)
                Destroy(_linkedCollider);
            
            switch(_colliderType) {
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
            _colliderTypeIsDirty = false;
            #endif
            UpdateColliderValues();
        }

        private void UpdateColliderValues() {
            switch(_colliderType) {
                case ColliderType.Box:
                    BoxCollider boxCollider = _linkedCollider as BoxCollider;
                    boxCollider!.center = _center;
                    boxCollider!.size = _size;
                    break;
                case ColliderType.Capsule:
                    CapsuleCollider capsuleCollider = _linkedCollider as CapsuleCollider;
                    capsuleCollider!.center = _center;
                    capsuleCollider!.height = _height;
                    capsuleCollider!.direction = (int) _direction;
                    capsuleCollider!.radius = _radius;
                    break;
                case ColliderType.Sphere:
                    SphereCollider sphereCollider = _linkedCollider as SphereCollider;
                    sphereCollider!.center = _center;
                    sphereCollider!.radius = _radius;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            #if UNITY_EDITOR
            _colliderValuesAreDirty = false;
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
            switch(_colliderType) {
                case ColliderType.Box:
                    Gizmos.DrawWireCube(transform.position + _center, _size);
                    break;
                case ColliderType.Capsule:
                    break;
                case ColliderType.Sphere:
                    Gizmos.DrawWireSphere(transform.position + _center, _radius);
                    break;
            }
        }
        
    }
    
}
