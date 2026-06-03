using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        return Created();
    }
}
