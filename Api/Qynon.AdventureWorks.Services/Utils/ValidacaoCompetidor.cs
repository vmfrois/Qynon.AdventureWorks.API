using Qynon.AdventureWorks.Models;
using System;

namespace Qynon.AdventureWorks.Service.Utils
{
    public static class ValidacaoCompetidor
    {

        public static void ValidarPesoEAltura(Competidor model)
        {
            ValidarAltura(model);
            ValidarPeso(model);
        }

        public static void ValidarTemperaturaCorporal(Competidor model)
        {
            if (model.TemperaturaMediaCorpo <= 36.0 || model.TemperaturaMediaCorpo >= 38.0)
            {
                throw new Exception("A temperatua media do corpo da pessoa deve estar entre 36.0 e 38.0 graus");
            };
        }

        public static void ValidarTipoSexo(Competidor model)
        {
            if (model.Sexo != 'M' && model.Sexo != 'F' && model.Sexo != 'O')
            {
                throw new Exception("O sexo da pessoa deve ser 'M', 'F' ou 'O'");
            }
        }

        private static void ValidarPeso(Competidor model)
        {
            if (model.Peso < 0)
            {
                throw new Exception("O peso precisa ser um valor positivo.");
            }
        }

        private static void ValidarAltura(Competidor model)
        {
            if (model.Altura < 0)
            {
                throw new Exception("A altura precisa ser um valor positivo.");
            }
        }
    }
}
