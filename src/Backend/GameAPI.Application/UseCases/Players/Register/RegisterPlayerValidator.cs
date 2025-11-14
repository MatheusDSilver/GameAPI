using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.Register
{
    public class RegisterPlayerValidator
    {
        public static void Validator(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ErrorOnValidationException("Name cannot be empty");
        }
    }
}
