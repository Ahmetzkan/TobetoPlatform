﻿using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountAnswerRequestValidator : AbstractValidator<UpdateAccountAnswerRequest>
    {
        public UpdateAccountAnswerRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.QuestionId).NotEmpty();
            RuleFor(a => a.ExamId).NotEmpty();
            RuleFor(a => a.GivenAnswer).NotEmpty();
        }
    }
}