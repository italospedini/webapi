using Core.Domain.Classes;
using Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class TransactionService
    {
        private readonly AdquirenteService adquirenteService;
        public TransactionService()
        {
            this.adquirenteService = new AdquirenteService();
        }

        public TransactionResultViewModel calculaValorLiquido(TransactionViewModel transactionViewModel)
        {
            Adquirente adquirente = adquirenteService.GetByid(transactionViewModel);

            if (adquirente == null)
                return new TransactionResultViewModel() { Success = false, Message = "adquirente não encontrado" };

            var findTaxa = adquirente.Taxas.Where(x => x.Bandeira.ToString().Equals(transactionViewModel.Bandeira.ToLower()));

            if (!findTaxa.Any())
                return new TransactionResultViewModel() { Success = false, Message = "bandeira não encontrada" };

            findTaxa = findTaxa.Where(x => x.TipoTransacao.ToString().Equals(transactionViewModel.Tipo.ToLower()));

            if (!findTaxa.Any())
                return new TransactionResultViewModel() { Success = false, Message = "tipo operação não encontrado" };

            float taxa = findTaxa.First().Taxa;
            float ValorLiquido = transactionViewModel.Valor * (1 - (taxa / 100));
            return new TransactionResultViewModel()
            {
                Success = true,
                ValorLiquido = ValorLiquido
            };

        }
    }
}
