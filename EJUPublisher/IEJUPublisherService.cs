using System;

namespace EJUPublisher
{
    public interface IEJUPublisherService
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
    }
}
