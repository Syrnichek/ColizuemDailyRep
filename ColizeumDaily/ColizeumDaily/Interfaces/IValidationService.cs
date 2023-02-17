namespace ColizeumDaily.Interfaces;

public interface IValidationService
{
    public void ValidateUserNumber(string UserNumber);

    public void ValidateTelegramUserName(string TelegramUserName);
}