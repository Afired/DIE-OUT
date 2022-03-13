﻿using Afired.Utils.Helper;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Afired.PartyGame.Sessions {
    
    public class SessionSettings : SerializedScriptableObject {
        
        [OdinSerialize] [LabelWidth(150)] public MinMaxDefault<int> MaxRounds { get; private set; }
        [OdinSerialize] [LabelWidth(150)] public MinMaxDefault<int> WinningScore { get; private set; }
        
    }
    
}
