using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.GainExperience
{
    public class GainExperienceValidator
    {
        public bool IsValid(int xp)
        {
            if (xp < 1) return false;

            return true;
        }
    }
}
