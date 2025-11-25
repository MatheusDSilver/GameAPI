using GameAPI.Communication.Requests;
using GameAPI.Domain;
using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;
using System.Net.Http.Headers;

namespace GameAPI.Application.UseCases.Players.Register
{
    public class RegisterPlayerUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnityOfWork _unityOfWork;
        public RegisterPlayerUseCase(IPlayerRepository playerRepository, IUnityOfWork unityOfWork)
        {
            _playerRepository = playerRepository;
            _unityOfWork = unityOfWork;
        }
        public async Task<Player> Execute(RequestRegisterPlayerJson request)
        {
            //Validation
            Validate(request);

            //Mapping
            var player = new Player(request.Name);

            //Saving date
            await _playerRepository.AddPlayerAsync(player);

            //Persist the data
            await _unityOfWork.Commit();

            return player;
        }

        private void Validate(RequestRegisterPlayerJson request)
        {
            var validator = new RegisterPlayerValidator();
            var result = validator.IsValid(request);

            if (result == false) throw new ErrorOnValidationException("Name cannot be empty");
        }
    }
}
