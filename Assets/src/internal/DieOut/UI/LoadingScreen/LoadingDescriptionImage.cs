﻿using Afired.PartyGame.Sessions;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.LoadingScreen {
    
    [RequireComponent(typeof(Image), typeof(AspectRatioFitter))]
    public class LoadingDescriptionImage : MonoBehaviour {
        
        private void Awake() {
            if(!Session.HasCurrent || !Session.Current.IsRunning)
                return;
            
            Image image = GetComponent<Image>();
            image.sprite = Session.Current?.GameModeInstance?.GameMode.DescriptionSprite;
            GetComponent<AspectRatioFitter>().aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        }
        
    }
    
}
