using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service
{
    public interface IPistaCorridaService
    {
        Task<IEnumerable<PistaCorrida>> GetListPistasCorridas();
        Task<IEnumerable<PistaCorrida>> GetPistasUtilizadas();
        Task<PistaCorrida> GetPistaCorrida(int id);
        Task InsertPistaCorrida(PistaCorrida model);
        Task UpdatePistaCorrida(int id, PistaCorrida model);
        Task DeletePistaCorrida(int id);
    }
}
