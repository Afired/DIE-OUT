﻿using Afired.Utils.Helper;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    public class GameModeRegister : MonoBehaviour {
        
        private static SingletonInstance<GameModeRegister> _instance;
        public static GameMode[] GameModes => _instance.Get()._gameModes;
        [SerializeField] private GameMode[] _gameModes;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
