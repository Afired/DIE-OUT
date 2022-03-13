using UnityEngine.InputSystem;

namespace Afired.PartyGame.GameModes {
    
    /// <summary>
    /// interface for custom injection of input devices
    /// </summary>
    public interface IDeviceReceiver {
        
        public void ReceiveDevices(InputDevice[] devices);
        
    }
    
}
