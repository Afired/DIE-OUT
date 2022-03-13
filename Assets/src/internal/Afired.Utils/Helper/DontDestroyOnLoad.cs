using UnityEngine;

namespace Afired.Utils.Helper {
    
    public class DontDestroyOnLoad : MonoBehaviour {
        
        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    
}
