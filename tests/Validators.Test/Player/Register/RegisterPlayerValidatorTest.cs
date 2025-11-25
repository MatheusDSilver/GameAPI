using CommonTestUtilities;
using CommonTestUtilities.Repositories;
using FluentAssertions;
using GameAPI.Application.UseCases.Players.Register;

namespace Validators.Test.Player.Register
{
    public class RegisterPlayerValidatorTest
    {
        [Fact]
        public async Task Sucess()
        {
            var useCase = CreateUseCase();

            var request = RequestRegisterPlayerJsonBuilder.Build();
            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Username.Should().Be(request.Name);
        }

        private static RegisterPlayerUseCase CreateUseCase()
        {
            var playerRepository = PlayerRepositoryBuilder.Build();
            var unityOfWork = UnityOfWorkBuilder.Build();

            return new RegisterPlayerUseCase(playerRepository, unityOfWork);
        }
    }
}
