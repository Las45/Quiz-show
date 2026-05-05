using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show
{
    public static class Logging
    {
        public static Serilog.Core.Logger logger {  get; private set; }
        public static void init()
        {
            logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("logging.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7).CreateLogger();
            logger.Information("=====New Start=====");
        }
    }
}
