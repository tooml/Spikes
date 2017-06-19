using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpike
{
    [Table("Adressen")]
    public class Adresse
    {
        public int Id { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
    }
}
