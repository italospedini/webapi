using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ViewModels
{
    public class TransactionResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public float ValorLiquido { get; set; }
    }
}
