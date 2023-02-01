using ColizeumDaily.Models;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    public UserModel UserGet(string Username)
    {
        using (ApplicationContext applicationContext = new ApplicationContext())
        {
            var users = applicationContext.Users.ToList();

            return users.Find(u => u.Username.Contains(Username)) ?? throw new InvalidOperationException();
        }
    }

    public void UserVisitCheck(string Username)
    {
        using (ApplicationContext applicationContext = new ApplicationContext())
        {
            var user = UserGet(Username);
            user.DaysStreak++;
        }
    }

    public void UserReg(string Username, string TelegramUsername)
    {
        using (ApplicationContext applicationContext = new ApplicationContext())
        {
            UserModel user = new UserModel { Username = Username, TelegramUsername = TelegramUsername};
            applicationContext.Users.Add(user);
            applicationContext.SaveChanges();
        }
    }
}