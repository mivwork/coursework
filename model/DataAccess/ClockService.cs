using model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess
{
    public class ClockService
    {
        private readonly MyDbContext context;

        public ClockService(MyDbContext context)
        {
            this.context = context;
        }

        public List<Clock> getDataClock()
        {
            List<Clock> data = context.clock.ToList();
            // Вернуть список объектов
            return data;
        }

        public List<Clock> getDataClockShop(Shop shop)
        {
            List<Clock> data;
            if (shop != null && shop.name != "Все")
            {
               data = context.clock.Where(u => u.shop == shop.name).ToList();
            } else
            {
               data = context.clock.ToList();
            }
            // Вернуть список объектов
            return data;
        }

        public List<Shop> getDataShop()
        {
            List<Shop> data = context.shop.ToList();
            // Вернуть список объектов
            return data;
        }
    }
}
