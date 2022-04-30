using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurentAndFood.Classes
{
    public class ErrorModel
    {
        public int LineNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string ErrorMessage { get; set; }
        public string FilePath { get; set; }
    }
}