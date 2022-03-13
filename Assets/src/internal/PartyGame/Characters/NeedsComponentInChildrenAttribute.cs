using System;

namespace Afired.PartyGame.Characters {
    
    [AttributeUsage(AttributeTargets.Field)]
    public class NeedsComponentInChildren : Attribute {
        
        public Type[] Types;
        
        public NeedsComponentInChildren(params Type[] type) {
            Types = type;
        }
        
    }
    
}
