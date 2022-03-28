using System;
using System.Collections.Generic;
using System.Text;

namespace TaskStudent.exception
{
    public class NotAvaiable : Exception
    {
        public NotAvaiable(string message) : base(message) { }
    }

}
