using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quiz.Models
{
    public class User
    {
        [Key]
        public int AdminID { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public IList<Count> Counts { get; set; }
    }
}
