using model.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess
{
    public class UserService
    {
        private readonly MyDbContext context;

        public UserService(MyDbContext context)
        {
            this.context = context;
        }

        public Users getuser()
        {
            // Считываем JSON-строку из файла
            string json = File.ReadAllText("Data.json");

            // Десериализуем JSON-строку в объект JObject
            JObject js = JObject.Parse(json);

            // Читаем значение элемента "login"
            string login = (string)js["login"];

            Users user = context.users.Where(u => u.login == login).FirstOrDefault();
            // Вернуть список объектов
            return user;
        }
    }
}