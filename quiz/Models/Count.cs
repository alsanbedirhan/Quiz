using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quiz.Models
{
    public class Count
    {
        [Key]
        public int CountID { get; set; }
        public int TrueCount { get; set; }
       // public int NullCount { get; set; }
        //public virtual int tryagain { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
