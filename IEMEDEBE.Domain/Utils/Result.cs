using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Domain.Utils
{
    public class Result <T> where T : class
    {
        public T ResultObject { get; set; }
        public string Message { get; set; }
        public Result() { }
    }
}
