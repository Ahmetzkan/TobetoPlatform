﻿using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountSessionRequestValidator : AbstractValidator<CreateAccountSessionRequest>
    {
        public CreateAccountSessionRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.SessionId).NotEmpty();
            RuleFor(a => a.Status).NotEmpty();
        }
    }
}