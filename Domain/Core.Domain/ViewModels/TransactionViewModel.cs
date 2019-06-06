using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ViewModels
{
    public class TransactionViewModel
    {
        public float Valor { get; set; }
        public string Adquirente { get; set; }
        public string Bandeira { get; set; }
        public string Tipo { get; set; }
    }
}
