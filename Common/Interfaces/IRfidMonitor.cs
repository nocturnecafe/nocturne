using System;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service to manage RFID card events.
    /// </summary>
    public interface IRfidMonitor
    {
        event EventHandler<RfidEventArgs> Selected;

        void StartMonitoring();
        void StopMonitoring();
    }
}