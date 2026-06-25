using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterUserAccountJson request,
        [FromServices] IValidator<RequestRegisterUserAccountJson> validator, 
        [FromServices] IRegisterUserAccountUseCase useCase)
    {

        useCase.Execute(request);

        return Created();
    }
}
