using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess;
public class AutorizationService
{

    private readonly MyDbContext context;

    public AutorizationService(MyDbContext context)
    {
        this.context = context;
    }

    public bool LoginAndPassword(string login, string password)
    {
        var user = context.users.Where(u => u.login == login).FirstOrDefault();
        string pass = null;
        bool isValidPassword = false;

        if (user != null)
        {
            pass = context.users.Where(u => u.login == login).FirstOrDefault().password;
        }
        // Хеширование пароля
        //string password1 = "1234";
        //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password1);

        string enteredPassword = password;
        if (pass != null)
        {
            isValidPassword = BCrypt.Net.BCrypt.Verify(enteredPassword, pass);
        }


        if (user != null && isValidPassword != false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string CheckUserCredentials()
    {
        string result = "";
        try
        {
            var users = context.Clock.ToList();
            result = "Подключение к базе данных установлено.";
        }
        catch (Exception ex)
        {
            result = "Ошибка при подключении к базе данных: " + ex.Message;
        }
        return result;
    }
}
