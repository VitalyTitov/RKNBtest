using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RKNBtest.Models
{
    public class Currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Valute_ID { get; set; }
        public string CharCode { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
