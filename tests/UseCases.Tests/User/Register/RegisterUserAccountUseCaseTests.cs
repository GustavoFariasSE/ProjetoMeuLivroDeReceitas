using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Security;
using MyRecipeBook.Application.UseCases.User.Register;
using Shouldly;

namespace UseCases.Tests.User.Register;
public class RegisterUserAccountUseCaseTests
{
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.TokensJson.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        result.TokensJson.AccessToken.ShouldBeNullOrEmpty();
        result.TokensJson.RefreshToken.ShouldBeNullOrEmpty();
    }

    private RegisterUserAccountUseCase CreateUseCase()
    {
        var unitOfWork = IUnityOfWorkBuilder.Build();
        var userWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder().Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();

        return new RegisterUserAccountUseCase(passwordHasher, userWriteOnlyRepository, 
            unitOfWork, userReadOnlyRepository);
    }
}
