using Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using ToDoApi.Models;

namespace ToDoApi.Validator
{
    class PostValidator : AbstractValidator<PostToDo>
    {
        private readonly IToDoCrud _crud;

        public PostValidator(IToDoCrud crud)
        {
            _crud = crud;

            RuleFor(todo => todo.Description).NotEmpty().MinimumLength(5).WithMessage("{PropertyName} must greater then 5");
            RuleFor(todo => todo.Date).NotEmpty().GreaterThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must greater then now");
        }
    }
}
