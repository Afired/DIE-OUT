using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    [Serializable]
    public class Transition {

        public CharacterState CharacterStateIn => _characterStateIn;
        public CharacterState CharacterStateOut => _characterStateOut;
        
        [HorizontalGroup("Horizontal")] [LabelText("@_characterStateIn?.StateName ?? \"...\"")] [LabelWidth(75)]
        [SerializeField] private CharacterState _characterStateIn;
        [HorizontalGroup("Horizontal")] [LabelText("@\"=> \" + (_characterStateOut?.StateName ?? \"...\")")] [LabelWidth(100)]
        [SerializeField] private CharacterState _characterStateOut;
        [LabelText("Conditions")]
        [SerializeField] private TransitionCondition[] _transitionConditions;

        public bool IsTrue(CharacterStatemachine characterStatemachine) {
            return _transitionConditions.All(transitionCondition => transitionCondition.IsTrue(characterStatemachine));
        }

    }
    
}
