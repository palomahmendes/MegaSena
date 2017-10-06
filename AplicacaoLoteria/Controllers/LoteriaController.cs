using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacaoLoteria.Models;
using System.Net;

namespace AplicacaoLoteria.Controllers
{
    public class LoteriaController : Controller
    {
        // GET: Loteria
        public static SorteioViewModels Sorteio { get; set; }
        public ActionResult Index()
        {
            if (Sorteio == null)
            {
                Sorteio = new SorteioViewModels();
                Sorteio.Apostas = new List<MegaSenaViewModel>();
                Sorteio.NumerosSorteados = new List<int>();
            }                        
            return View(Sorteio);
        }

     //
        //APRESENTA A SURPRESINHA
        public ActionResult Surpresinha()
        {
            MegaSenaViewModel aposta = new MegaSenaViewModel();
            aposta.ListaNumerosEscolhidos = new List<int>();
            
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                aposta.ListaNumerosEscolhidos.Add(r.Next(61) + 1);
            }
            aposta.IdColuna = Sorteio.Apostas.Count() + 1;
            aposta.DataHora = DateTime.Now;
            Sorteio.Apostas.Add(aposta);
            return PartialView("Apostas", Sorteio);
        }



        //APRESENTA A SURPRESINHA
        public ActionResult CadastrarAposta(int n1, int n2, int n3, int n4, int n5, int n6)
        {
            if( n1 <1 || n1 > 60  || n2 < 1 || n2 > 60 || n3 < 1 || n3 > 60 || n4 <1 || n4 > 60 || n5<1 || n5 > 60 || n6 < 1 || n6 > 60 )
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Entre com os Valores em 1 a 60."); }
             
            MegaSenaViewModel aposta = new MegaSenaViewModel();
            aposta.ListaNumerosEscolhidos = new List<int>();
            aposta.ListaNumerosEscolhidos.Add(n1);
            aposta.ListaNumerosEscolhidos.Add(n2);
            aposta.ListaNumerosEscolhidos.Add(n3);
            aposta.ListaNumerosEscolhidos.Add(n4);
            aposta.ListaNumerosEscolhidos.Add(n5);
            aposta.ListaNumerosEscolhidos.Add(n6);
            aposta.IdColuna = Sorteio.Apostas.Count() + 1;
            aposta.DataHora = DateTime.Now;
            Sorteio.Apostas.Add(aposta);
            return PartialView("Apostas", Sorteio);
           
            
        }

    /// <summary>
    /// Realiza os sorteios
    /// </summary>
    /// <returns></returns>
        public ActionResult Sorteios()
        {
            Sorteio.NumerosSorteados.Clear();           
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                Sorteio.NumerosSorteados.Add(r.Next(61) + 1);
            }
            foreach (var aposta in Sorteio.Apostas)
            {
                var acertos = 0;
                foreach (var numero in aposta.ListaNumerosEscolhidos)
                {
                    if (Sorteio.NumerosSorteados.Where(x => x == numero).ToList().Count() > 0)
                        acertos++;
                }
                aposta.ValorAcertos = acertos;
            }            
            return PartialView("Apostas", Sorteio);
            
        }

        public ActionResult LimparApostas()
        {
            Sorteio.Apostas.Clear();
            return PartialView("Apostas", Sorteio);
        }


    }
}
