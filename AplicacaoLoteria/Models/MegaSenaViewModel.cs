using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoLoteria.Models
{
    public class MegaSenaViewModel
    {
        public int IdColuna { get; set; }
        public DateTime DataHora { get; set; }
        public List<int> ListaNumerosEscolhidos { get; set; }                
        public int ValorAcertos { get; set; }              
    }

}

