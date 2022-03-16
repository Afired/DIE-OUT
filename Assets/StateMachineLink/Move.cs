using Afired.Utils.StatemachineExtensions;
using UnityEngine;

public class Move : StateMachineMonoBehaviour {
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Move");
    }
    
}
