using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace RKNBtest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private ApplicationContext db;
        public CurrencyController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Currency()
        {
            return View();
        }

        //получение курса по id
        [HttpPost]
        [Route("getValute")]
        public IActionResult GetValute([FromForm] string idvalute)
        {
            string identity = GetValuteinfo(idvalute);
            return Ok(identity);
        }

        private string GetValuteinfo(string idvalute)
        {
            if (idvalute != null)
            {
                var pos = db.Currencies.Where(x => x.Valute_ID == idvalute && x.ContactDate == DateTime.Today.Date).FirstOrDefault();
                if (pos != null)
                {
                    string kurs = pos.Value.ToString();
                    string name = pos.Name.ToString();
                    return ("Курс " + name + " равен " + kurs);
                }
                else
                {
                    return "Not found";
                }
            }
            else
            {
                return "Not found";
            }

        }
    }
}
