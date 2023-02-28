using Qynon.AdventureWorks.Models;
using System;

namespace Qynon.AdventureWorks.Service.Utils
{
    public static class ValidacaoCorrida
    {
        public static void ValidaDataEstaFuturo(HistoricoCorrida historico)
        {
            if (historico.DataCorrida > DateTime.Now)
                {
                    throw new Exception("Não é permitido atualizar uma corrida com data futura.");
                }

        }
    }
}
