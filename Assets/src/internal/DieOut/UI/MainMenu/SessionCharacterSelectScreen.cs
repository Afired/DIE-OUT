﻿using System;
using Afired.PartyGame.Sessions;
using Afired.UI;
using DieOut.UI.CharacterSelect;
using UnityEngine;
using UnityEngine.InputSystem;
using Screen = Afired.UI.Screen;

namespace DieOut.UI.MainMenu {
    
    public class SessionCharacterSelectScreen : MonoBehaviour {

        [SerializeField] private SessionSettingsScreen _sessionSettingsScreen;
        [SerializeField] private CharacterSelectCardManager _characterSelectCardManager;
        private InputTable _inputTable;
        
        
        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.Navigation.SessionStart.performed += TryToStartSession;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnDestroy() {
            _inputTable.Dispose();
        }

        private void TryToStartSession(InputAction.CallbackContext _) {
            SessionBuilder sessionBuilder = _sessionSettingsScreen.SessionBuilder;
            sessionBuilder.Players = _characterSelectCardManager.CreatePlayers();
            
            Session newSession = sessionBuilder.Create();
            if(newSession == null)
                return;
            
            Session.SetNew(newSession);
            #pragma warning disable CS4014
            Session.Current.Start();
            #pragma warning restore CS4014
        }
        
    }
    
}
