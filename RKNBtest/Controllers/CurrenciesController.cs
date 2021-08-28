using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RKNBtest.Models;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RKNBtest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : Controller
    {
        private ApplicationContext db;
        public CurrenciesController(ApplicationContext context)
        {
            db = context;
        }
        
        //получение списка валют       
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1)
        {            
            WebClient client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");           
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            foreach (XElement valute in xdoc.Element("ValCurs").Elements("Valute"))
            {
                XAttribute ValuteId = valute.FirstAttribute;
                XElement CharC = valute.Element("CharCode");
                XElement NameV = valute.Element("Name");
                XElement ValueV = valute.Element("Value");
                if (ValuteId != null && ValueV != null && NameV != null)
                {
                    var re = db.Currencies.Where(x => x.Name == NameV.Value && x.CharCode == CharC.Value && x.ContactDate == DateTime.Today.Date).ToList();
                    if (re.Count == 0)
                    {
                        db.Currencies.Add(new Models.Currency
                        {
                            Valute_ID = ValuteId.Value,
                            CharCode = CharC.Value,
                            Name = NameV.Value,
                            Value = ValueV.Value,
                            ContactDate = DateTime.Today.Date
                        });
                        db.SaveChanges();
                        re = null;
                    }
                }
            }
            int pageSize = 3;
            IQueryable<Models.Currency> source = db.Currencies;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Currencies = items
            };
            return View(viewModel);
        }
    }
}
