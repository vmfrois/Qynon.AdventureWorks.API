using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Infrastructure.Data;
using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Qynon.AdventureWorks.Tests
{
    public class PistaCorridaCrudTest
    {
        private readonly IPistaCorridaDao _dao;
        public PistaCorridaCrudTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "QyonDB").Options;

            var db = new AppDbContext(options);
            _dao = new PistaCorridaDao(db);
        }

        [Fact]
        public async Task GetAllPistasCorrida()
        {
            var pistas = new List<PistaCorrida>()
            {
                new PistaCorrida
                {
                    Id = 1,
                    Descricao = "Corrida São Paulo"
                },
                new PistaCorrida
                {
                    Id = 2,
                    Descricao = "Corrida Rio de janeiro"
                },
                new PistaCorrida
                {
                    Id = 3,
                    Descricao = "Corrida Bahia"
                },
                new PistaCorrida
                {
                    Id = 4,
                    Descricao = "Corrida Jundiaí"
                },
            };

            foreach(var pista in pistas)
            {
                await _dao.Insert(pista);
            }

            var CurrentPistas =  await _dao.GetAllAsync();
            
            Assert.Equal(pistas, CurrentPistas);
            foreach (var p in pistas)
            {
                Assert.Contains(p, CurrentPistas);
            }

        }

        [Fact]
        public void TestGetById()
        {
            var pista = new PistaCorrida()
            {
                Id = 1,
                Descricao = "Corrida São Paulo"
            };

            _dao.Insert(pista);

            var CurrentPista = _dao.GetById(pista.Id);
            Assert.Equal(pista, CurrentPista.Result);
        }

        [Fact]
        public void TestInsertPistaCorrida()
        {
            var pista = new PistaCorrida()
            {
                Id = 1,
                Descricao = "Corrida São Paulo"
            };

            _dao.Insert(pista);

            Assert.True(pista.Id > 0);

        }

        [Fact]
        public void TestUpdatePistaCorrida()
        {
            var pista = new PistaCorrida()
            {
                Id = 1,
                Descricao = "Corrida São Paulo"
            };

            _dao.Insert(pista);

            pista.Descricao = "Corrida de Jundiaí até São paulo";

            _dao.Update(pista);

            var updatedPista = _dao.GetById(pista.Id);
            Assert.Equal(pista.Descricao,updatedPista.Result.Descricao);

        }

        [Fact]
        public async Task TestDeletePistaCorrida()
        {
            var pista = new PistaCorrida()
            {
                Id = 1,
                Descricao = "Corrida São Paulo"
            };

            await _dao.Insert(pista);
            
            await _dao.Delete(pista.Id);
            
            var pistaDeletada = await _dao.GetById(pista.Id);
            Assert.Null(pistaDeletada);
        }

    }
}
