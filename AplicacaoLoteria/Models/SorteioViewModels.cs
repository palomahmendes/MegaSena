using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoLoteria.Models
{
    public class SorteioViewModels
    {
        public List<int> NumerosSorteados { get; set; }
        public List<MegaSenaViewModel> Apostas { get; set; }
    }
}