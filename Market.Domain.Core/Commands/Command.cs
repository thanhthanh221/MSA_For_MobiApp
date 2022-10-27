using System;
using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;

namespace Market.Domain.Core.Commands
{
    public abstract class Command :IRequest<bool>
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
