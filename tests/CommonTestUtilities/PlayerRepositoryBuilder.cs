using GameAPI.Domain.Repositories;
using Moq;

namespace CommonTestUtilities
{
    public class PlayerRepositoryBuilder
    {
        public static IPlayerRepository Build()
        {
            var mock = new Mock<IPlayerRepository>();

            return mock.Object;
        }
    }
}
