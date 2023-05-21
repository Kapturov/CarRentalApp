using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;


namespace CarRentalApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        AppContext ac = new AppContext();
        List<Order> list = new List<Order>();

        [HttpGet]
        public IResult Get()
        {

            list = ac.Orders.ToList();
            return Results.Json(list);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            list = ac.Orders.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdOrder == id) { index = i; }
            }
            return Results.Json(list[index]);
        }


        [HttpPost]
        public void Post(int IdCar, int IdClient, int hours, double summa)
        {
            Order o = new Order { IdClient = IdClient, IdCar=IdCar, Hours=hours, Summa=summa };
            ac.Orders.Add(o);
            ac.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, int IdCar, int IdClient, int hours, double summa)
        {
            list = ac.Orders.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdOrder == id)
                {
                    list[i].IdCar = IdCar;
                    list[i].Hours = hours;
                    list[i].Summa = summa;
                    list[i].IdClient=IdClient;
                    ac.SaveChanges();
                }
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ac.Orders.Where(u => u.IdOrder == id).ExecuteDelete();
            ac.SaveChanges();
        }
    }
}
