using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace CarRentalApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        AppContext ac = new AppContext();
        List<Client> list = new List<Client>();

        [HttpGet]
        public IResult Get()
        {

            list = ac.Clients.ToList();
            return Results.Json(list);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            list = ac.Clients.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdClient == id) { index = i; }
            }
            return Results.Json(list[index]);
        }


        [HttpPost]
        public void Post(string fio, string phone, string address)
        {
            Client c = new Client { Fio = fio, Address=address, Phone=phone };
            ac.Clients.Add(c);
            ac.SaveChanges();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, string fio, string phone, string address)
        {

            list = ac.Clients.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdClient == id)
                {
                    list[i].Fio = fio;
                    list[i].Phone = phone;
                    list[i].Address = address;
                    ac.SaveChanges();
                }
            }
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ac.Clients.Where(u => u.IdClient == id).ExecuteDelete();
            ac.SaveChanges();
        }
    }
}
