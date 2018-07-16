using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MyNextHotel.Common
{
    public class ProjectLogger:ILogger
    {
        private Logger _logger;

        public ProjectLogger()
        {
            _logger = LogManager.GetLogger("Nlogger");
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception ex)
        {
            _logger.Error(ex);
        }

    }
}
