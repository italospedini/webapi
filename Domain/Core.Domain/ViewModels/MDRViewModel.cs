using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ViewModels
{
    public class MDRViewModel
    {
        public string Adquirente { get; set; }
        public ICollection<TaxasViewModel> Taxas { get; set; }
    }
}
