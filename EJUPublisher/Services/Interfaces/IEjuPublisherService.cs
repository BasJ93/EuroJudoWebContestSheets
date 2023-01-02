using System;
using EuroJudoProtocols.ShowFights.Models;

namespace EJUPublisher.Services.Interfaces
{
    /// <summary>
    /// Class to handle publishing the of data received from EuroJudo to the web service.
    /// </summary>
    public interface IEjuPublisherService
    {
        /// <summary>
        /// Event triggered when a logline for a new received message is generated
        /// </summary>
        EventHandler<string> DataReceivedLogEvent { get; set; }

        /// <summary>
        /// Start the listener
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the listener
        /// </summary>
        void Stop();

        /// <summary>
        /// Rebuild the listener using a new configuration
        /// </summary>
        void RefreshConfiguration();
        
        /// <summary>
        /// Rebuild the listener using a new configuration
        /// </summary>
        void RefreshConfiguration(ShowFightsConfiguration showFightsConfiguration);
    }
}
