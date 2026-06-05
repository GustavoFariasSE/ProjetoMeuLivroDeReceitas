using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterUserAccountJson request,
        [FromServices] IValidator<RequestRegisterUserAccountJson> validator)
    {
        try
        {
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var useCase = new RegisterUserAccountUseCase();

            useCase.Execute(request);

            return Created();
        }
        catch ()
        {

        }
    }
}
