﻿#if UNITY_EDITOR
using System;
using Afired.PartyGame.Characters;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

[assembly: RegisterValidator(typeof(NeedsComponentInChildrenValidator))]
namespace Afired.PartyGame.Characters {
    
    public class NeedsComponentInChildrenValidator : AttributeValidator<NeedsComponentInChildren, GameObject> {
        
        protected override void Validate(ValidationResult result) {
            if(ValueEntry.SmartValue == null)
                return;

            foreach(Type type in Attribute.Types) {
                
                if(ValueEntry.SmartValue.GetComponentInChildren(type) == null) {
                    result.ResultType = ValidationResultType.Error;
                    result.Message = $"'{type.Name}' component is required";
                }
                
            }
            
        }
        
    }
    
}
#endif
