using Bogus;
using GameAPI.Communication.Requests;

namespace CommonTestUtilities
{
    public class RequestRegisterPlayerJsonBuilder
    {
        public static RequestRegisterPlayerJson Build()
        {
            return new Faker<RequestRegisterPlayerJson>()
                .RuleFor(player => player.Name, (f) => f.Internet.UserName());
        }
    }
}
