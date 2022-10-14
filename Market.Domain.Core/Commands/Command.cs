using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Events;

namespace Market.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        protected Command()
        {
            this.Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();


    }
}
