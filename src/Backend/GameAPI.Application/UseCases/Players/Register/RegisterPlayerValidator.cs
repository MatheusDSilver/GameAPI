using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.Register
{
    public class RegisterPlayerValidator
    {
        public bool IsValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            return true;
        }
    }
}
