using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;

namespace ResourceServer.SharedKernel.ServiceHealth
{
    public class ServiceHealthStatusEventStore
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IList<ServiceHealthEvent> _serviceHealthEvents;

        public ServiceHealthStatusEventStore()
        {
            _serviceHealthEvents = new List<ServiceHealthEvent>();
        }

        public IEnumerable<ServiceHealthEvent> ServiceHealthEvents
        {
            get { return _serviceHealthEvents; }
        }

        public void SetFaultyStatus(string errorMessage)
        {
            var healthEvent = new ServiceHealthEvent(HealthStatus.Faulty, errorMessage);
            _serviceHealthEvents.Add(healthEvent);
            _logger.ErrorFormat(
                "Service health status = {0}. Recorderd at {1}. Message={2}",
                Enum.GetName(typeof(HealthStatus), healthEvent.HealthStatus),
                healthEvent.TimestampUtc.ToLocalTime(),
                healthEvent.LogMessage);
        }

        public void SetOkStatus()
        {
            var healthEvent = new ServiceHealthEvent(HealthStatus.Ok, string.Empty);
            _serviceHealthEvents.Add(healthEvent);
            _logger.InfoFormat(
                "Service health status = {0}. Recorderd at {1}. Message={2}",
                Enum.GetName(typeof(HealthStatus), healthEvent.HealthStatus),
                healthEvent.TimestampUtc.ToLocalTime(),
                healthEvent.LogMessage);
        }

        public ServiceHealthEvent GetCurrentStatus()
        {
            return _serviceHealthEvents.Last();
        }
    }
}
