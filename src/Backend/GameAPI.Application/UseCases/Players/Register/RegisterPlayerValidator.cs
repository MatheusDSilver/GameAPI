using GameAPI.Communication.Requests;
using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.Register
{
    public class RegisterPlayerValidator
    {
        public bool IsValid(RequestRegisterPlayerJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name)) return false;

            return true;
        }
    }
}
