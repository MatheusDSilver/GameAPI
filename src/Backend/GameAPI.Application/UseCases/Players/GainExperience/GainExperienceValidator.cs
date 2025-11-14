using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.GainExperience
{
    public class GainExperienceValidator
    {
        public static void Validator(int xp)
        {
            if (xp < 1) throw new ErrorOnValidationException("Need to add more than 0 experience");
        }
    }
}
