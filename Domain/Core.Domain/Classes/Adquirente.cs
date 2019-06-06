using Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Classes
{
    public class Adquirente
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<TaxasAdquirente> Taxas { get; set; }

        public Adquirente()
        {
            
        }

        public Adquirente(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }
    }

    public class TaxasAdquirente
    {
        public BandeiraEnum Bandeira { get; set; }
        public TipoTransacaoEnum TipoTransacao { get; set; }
        public float Taxa { get; set; }

        public TaxasAdquirente()
        {

        }

        public TaxasAdquirente(BandeiraEnum Bandeira, TipoTransacaoEnum Tipotransacao, float Taxa)
        {
            this.Bandeira = Bandeira;
            this.TipoTransacao = TipoTransacao;
            this.Taxa = Taxa;
        }
    }
}
