using Core.Domain.Classes;
using Core.Domain.Enum;
using Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class AdquirenteService
    {
        public AdquirenteService()
        {

        }

        public ICollection<Adquirente> GetAll()
        {
            Adquirente adquirenteA = new Adquirente("A", "Adquirente A");
            Adquirente adquirenteB = new Adquirente("C", "Adquirente B");
            Adquirente adquirenteC = new Adquirente("C", "Adquirente C");

            adquirenteA.Taxas = GetTaxasAdquirenteA();
            adquirenteB.Taxas = GetTaxasAdquirenteB();
            adquirenteC.Taxas = GetTaxasAdquirenteC();

            List<Adquirente> lstAdquirentes = new List<Adquirente>();
            lstAdquirentes.Add(adquirenteA);
            lstAdquirentes.Add(adquirenteB);
            lstAdquirentes.Add(adquirenteC);

            return lstAdquirentes;
        }

        public Adquirente GetByid(TransactionViewModel transactionViewModel)
        {
            return this.GetAll().Where(x => x.Code.Equals(transactionViewModel.Adquirente)).FirstOrDefault();
        }

        public ICollection<MDRViewModel> getMDR()
        {
            return MapToMDRViewModel(GetAll());
        }




        private List<TaxasAdquirente> GetTaxasAdquirenteA()
        {
            var taxasAdquirenteA = new List<TaxasAdquirente>();
            taxasAdquirenteA.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 2f
            });
            taxasAdquirenteA.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 2.25f
            });
            taxasAdquirenteA.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 1.98f
            });
            taxasAdquirenteA.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 2.35f
            });

            return taxasAdquirenteA;
        }

        private List<TaxasAdquirente> GetTaxasAdquirenteB()
        {
            var taxasAdquirenteB = new List<TaxasAdquirente>();
            taxasAdquirenteB.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 2.08f
            });
            taxasAdquirenteB.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 2.5f
            });
            taxasAdquirenteB.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 1.75f
            });
            taxasAdquirenteB.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 2.65f
            });

            return taxasAdquirenteB;
        }

        private List<TaxasAdquirente> GetTaxasAdquirenteC()
        {
            var taxasAdquirenteC = new List<TaxasAdquirente>();
            taxasAdquirenteC.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 2.16f
            });
            taxasAdquirenteC.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.visa,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 2.75f
            });
            taxasAdquirenteC.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.debito,
                Taxa = 1.58f
            });
            taxasAdquirenteC.Add(new TaxasAdquirente()
            {
                Bandeira = BandeiraEnum.mastercard,
                TipoTransacao = TipoTransacaoEnum.credito,
                Taxa = 3.1f
            });

            return taxasAdquirenteC;
        }

        private ICollection<MDRViewModel> MapToMDRViewModel(ICollection<Adquirente> Adquirentes)
        {
            List<MDRViewModel> lstViewModel = new List<MDRViewModel>();
            foreach (Adquirente adquirente in Adquirentes)
            {
                MDRViewModel viewModel = new MDRViewModel();
                viewModel.Adquirente = adquirente.Name;
                viewModel.Taxas = new List<TaxasViewModel>();

                for (int i = 0; i < Enum.GetValues(typeof(BandeiraEnum)).Length; i++)
                {
                    var bandeira = Enum.GetValues(typeof(BandeiraEnum)).GetValue(i);
                    var bandeiraName = Enum.GetNames(typeof(BandeiraEnum))[i];
                    viewModel.Taxas.Add(new TaxasViewModel()
                    {
                        Bandeira = bandeiraName,
                        Credito = adquirente.Taxas.Where(x => x.Bandeira.Equals(bandeira)
                                                                && x.TipoTransacao.Equals(TipoTransacaoEnum.credito))
                                                                .FirstOrDefault()?.Taxa.ToString("0.00"),
                        Debito = adquirente.Taxas.Where(x => x.Bandeira.Equals(bandeira)
                                                                && x.TipoTransacao.Equals(TipoTransacaoEnum.debito))
                                                                .FirstOrDefault()?.Taxa.ToString("0.00")

                    });
                }

                lstViewModel.Add(viewModel);
            }

            return lstViewModel;
        }
    }
}
