using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Settings
{
    public class RabbitMQSettings
    {
        public string Host { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Virtual_host { get; init; }
    }
}
