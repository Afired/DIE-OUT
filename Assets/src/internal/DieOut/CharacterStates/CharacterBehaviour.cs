using UnityEngine;

namespace DieOut.CharacterSystem {
    
    public abstract class CharacterBehaviour : MonoBehaviour {
        
        public virtual void OnEnterState(CharacterStatemachine characterStatemachine) { }
        public virtual void OnUpdateState(CharacterStatemachine characterStatemachine) { }
        public virtual void OnExitState(CharacterStatemachine characterStatemachine) { }
        
    }
    
}
