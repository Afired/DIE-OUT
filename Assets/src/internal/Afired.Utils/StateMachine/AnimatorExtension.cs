using UnityEngine;

namespace Afired.Utils.StateMachine {
    
    public static class AnimatorExtension {
        
        public static void SetVector2(this Animator animator, string parameterName, Vector2 vector2) {
            animator.SetFloat(parameterName + ".x", vector2.x);
            animator.SetFloat(parameterName + ".y", vector2.y);
            animator.SetFloat(parameterName, vector2.magnitude);
        }
        
        public static Vector2 GetVector2(this Animator animator, string parameterName) {
            float x = animator.GetFloat(parameterName + ".x");
            float y = animator.GetFloat(parameterName + ".y");
            return new Vector2(x, y);
        }
        
    }
    
}
