using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Core.Domain.Classes;
using Core.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {

        // GET api/app
        [HttpGet]
        public ActionResult<ICollection<MDRViewModel>> mdr()
        {
            AdquirenteService adquirenteService = new AdquirenteService();
            var MDR = adquirenteService.getMDR().ToList();

            return MDR;
        }

        // GET api/app/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return id.ToString();
        //}

        // POST api/app
        [HttpPost]
        public ActionResult<object> transaction(string input)
        {
            TransactionViewModel transactionViewModel;

            try
            {
                transactionViewModel = JsonConvert.DeserializeObject<TransactionViewModel>(input);
            }
            catch (Exception ex)
            {
                return $"Erro ao converter entrada. {ex.Message}";
            }

            TransactionService transactionService = new TransactionService();

            TransactionResultViewModel result = transactionService.calculaValorLiquido(transactionViewModel);

            if (result.Success)
                return new ValorLiquidoViewModel()
                {
                    ValorLiquido = result.ValorLiquido
                };
            else
                return result.Message;
        }

        // PUT api/app/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/app/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
