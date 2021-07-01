using Microsoft.AspNetCore.Mvc;
using api.Data;
using MongoDB.Driver;
using api.Data.Collections;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class infectadosController : ControllerBase
    {
        MongoDbClass _mongoDB; 
        IMongoCollection<Infectados> _InfectadosCollction;
        public infectadosController(MongoDbClass mongoDB)
        {
            _mongoDB = mongoDB;
            _InfectadosCollction = _mongoDB.DB.GetCollection<Infectados>(typeof(Infectados).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadosView infectadosView)
        {
            var infectado = new Infectados(infectadosView.dataNascimento, infectadosView.sexo, infectadosView.latitude, infectadosView.longitude);
            _InfectadosCollction.InsertOne(infectado);
            return StatusCode(201, "Infectado Adicionado com sucesso");
        }
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _InfectadosCollction.Find(Builders<Infectados>.Filter.Empty).ToList();
            return Ok(infectados);
        }
    }
}