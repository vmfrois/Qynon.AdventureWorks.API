using Qynon.AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qynon.AdventureWorks.Service.Utils
{
    public static class ValidacaoCorrida
    {
        public static void ValidaDataNoFuturo(HistoricoCorrida historico)
        {
            if(historico.DataCorrida > DateTime.Now)
            {
                throw new Exception("Não é permitido atualizar uma corrida com data futura.");
            }
        }
    }
}
