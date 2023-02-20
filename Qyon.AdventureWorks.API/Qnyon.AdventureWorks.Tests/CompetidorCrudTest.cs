using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Infrastructure.Data;
using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Qynon.AdventureWorks.Tests
{
    public class CompetidorCrudTest
    {
        private readonly CompetidorDao _dao;

        public CompetidorCrudTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "qynon").Options;

            var db = new AppDbContext(options);
            _dao = new CompetidorDao(db);

        }

        [Fact]
        public async Task Insert_newCompetidor()
        {
            var comepetidor = new Competidor
            {
                Nome = "Lucas da Silva Freitas",
                Sexo = 'M',
                Altura = 1.78,
                Peso = 65.0,
                TemperaturaMediaCorpo = 37
            };
            await _dao.Insert(comepetidor);

            Assert.True(comepetidor.Id > 0);
        }

        [Fact]
        public async Task Update_Competidor()
        {
            var competidora = new Competidor
            {
                Nome = "Maria Quaker",
                Sexo = 'F',
                Altura = 1.65,
                Peso = 48.50,
                TemperaturaMediaCorpo = 36.5
            };

            await _dao.Insert(competidora);

            competidora.Nome = "Maria Silva do Santos";
            await _dao.Update(competidora);

            var updatedCompetidora = _dao.GetById(competidora.Id);
            
            Assert.Equal(competidora.Nome, updatedCompetidora.Result.Nome);

        }

        [Fact]
        public async Task Delete_Competidor()
        {
            var competidor = new Competidor
            {
                Nome = "Paulo Miranda",
                Sexo = 'M',
                Altura = 1.8,
                Peso = 90.5,
                TemperaturaMediaCorpo = 36.5
            };

            await _dao.Insert(competidor);

            await _dao.Delete(competidor.Id);

            var competidorDeletado = await _dao.GetById(competidor.Id);

            Assert.Null(competidorDeletado);
        }

        [Fact]
        public async Task GetAllCompetidores()
        {
            var competidores = new List<Competidor>
            {
                new Competidor
                {
                    Nome = "Ana maria Bento",
                    Sexo = 'F',
                    TemperaturaMediaCorpo = 36.5,
                    Peso = 65.5,
                    Altura = 1.60
                },
                new Competidor
                {
                    Nome = "Paula da Silva Guedes",
                    Sexo = 'F',
                    TemperaturaMediaCorpo = 36.7,
                    Peso = 65.5,
                    Altura = 1.7
                },
                new Competidor
                {
                    Nome = "José dos Santos Perreira",
                    Sexo = 'M',
                    TemperaturaMediaCorpo = 36.2,
                    Peso = 85.5,
                    Altura = 1.9
                }
            };

            foreach(var competidor in competidores)
            {
                await _dao.Insert(competidor);
            }

            var list = await _dao.GetAllAsync();

            Assert.Equal(competidores, list);
            
            foreach (var competidor in competidores)
            {
                Assert.Contains(competidor, list);
            }
        
        }

        [Fact]
        public async Task GetById()
        {
            var competidor = new Competidor
            {
                Nome = "Vinicius da Silva Santos",
                Sexo = 'M',
                TemperaturaMediaCorpo = 36.24,
                Peso = 70,
                Altura = 1.73
            };

            await _dao.Insert(competidor);

            var retrievedCompetidor = _dao.GetById(competidor.Id);

            Assert.Equal(competidor, retrievedCompetidor.Result);
        }

    }
}
