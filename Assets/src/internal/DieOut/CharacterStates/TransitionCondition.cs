using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.CharacterSystem {
    
    [Serializable]
    public sealed class TransitionCondition {
        
        [HorizontalGroup("Horizontal", Width = 0.5f)] [LabelWidth(100)]
        [SerializeField] private string _parameterName;
        [HorizontalGroup("Horizontal", Width = 0.2f)] [HideLabel]
        [SerializeField] private ComparisonType _comparisonType;
        [HorizontalGroup("Horizontal", Width = 0.2f)] [LabelWidth(50)]
        [SerializeField] private float _value;
        
        public bool IsTrue(CharacterStatemachine _characterStatemachine) {
            float value = _characterStatemachine.GetParameterByName(_parameterName);
            return _comparisonType switch {
                ComparisonType.Smaller => value < _value,
                ComparisonType.Greater => value > _value,
                _ => throw new InvalidEnumArgumentException()
            };
        }
        
    }
    
}
