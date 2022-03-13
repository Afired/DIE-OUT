﻿using System.Collections.Generic;
using Afired.PartyGame.GameModes;
using Afired.PartyGame.Sessions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.QuickPlay {
    
    public class QuickMapSelectButton : MonoBehaviour {

        [SerializeField] private TMP_Text _mapTitleTextElement;
        private GameMode _gameMode;
        private Map _map;
        
        public void Init(GameMode gameMode, Map map) {
            _gameMode = gameMode;
            _map = map;
            _mapTitleTextElement.text = _map.DisplayName;
        }

        public void Select() {
            SessionBuilder sessionBuilder = new SessionBuilder();
            sessionBuilder.ActivatedGameModes = new HashSet<GameMode>() { _gameMode };
            
            Session.SetNew(new Session(CreatePlayers(), new HashSet<GameMode>() { _gameMode }, 1, 1));
            Session.Current.LoadGameMode(_gameMode , _map);
        }
        
        //todo: limit to amount of possible players
        private Player[] CreatePlayers() {
            List<InputDevice> playerInputDevices = new List<InputDevice>();
            
            if(Keyboard.current != null)
                playerInputDevices.Add(Keyboard.current);
            
            for(int i = 0; i < Gamepad.all.Count; i++) {
                playerInputDevices.Add(Gamepad.all[i]);
            }
            
            Player[] players = new Player[playerInputDevices.Count];
            for(int i = 0; i < playerInputDevices.Count; i++) {
                if(playerInputDevices[i] is Keyboard)
                    players[i] = new Player(new InputDevice[] { playerInputDevices[i], Mouse.current }, CharacterRegister.Characters[i]);
                else
                    players[i] = new Player(new InputDevice[] { playerInputDevices[i] }, CharacterRegister.Characters[i]);
            }
            
            return players;
        }
        
    }
    
}
