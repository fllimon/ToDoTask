using Domain.Interfaces;
using FluentValidation;
using System;
using ToDoApi.Models;

namespace ToDoApi.Validator
{
    class PutValidator : AbstractValidator<PutToDo>
    {
        private readonly IToDoCrud _crud;
        public PutValidator(IToDoCrud crud)
        {
            _crud = crud;

            RuleFor(todo => todo.Id).MustAsync(async (id, cansselation) =>
            {
                bool result = await _crud.IsIdExist(id);

                return result;
            }).WithMessage("ID does not exist");

            RuleFor(todo => todo.Description).NotEmpty().MinimumLength(5).WithMessage("{PropertyName} must greater then 5");
            RuleFor(todo => todo.Date).NotEmpty().GreaterThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must greater then now");
        }
    }
}
