using System;
using FFImageLoading.Helpers;
using Serilog;

namespace ZShoppe.Client.Droid
{
    public partial class MainActivity
    {
        private class ImageServiceLogger : IMiniLogger
        {
            private readonly ILogger _logger;

            public ImageServiceLogger(ILogger logger)
            {
                _logger = logger.ForContext<ImageServiceLogger>();
            }

            public void Debug(string message)
            {
                _logger.Debug(message);
            }

            public void Error(string errorMessage)
            {
                _logger.Error(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                _logger.Error(ex, errorMessage);
            }
        }
    }
}