using API_Ferramenta_test.Models;
using API_Ferramenta_test.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel;

namespace API_Ferramenta_test.Controllers
{
    [ApiController]
    [Route("api/reparti")]
    public class RepartoController : Controller
    {
        private readonly RepartoRepo _services;

        public RepartoController(RepartoRepo services)
        {
            _services = services;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("{varCodice}")]
        public ActionResult<Reparto?> FindByCod(string varCodice)
        {
            if (string.IsNullOrEmpty(varCodice))
                return BadRequest();

            Reparto? risultato = _services.GetByCodice(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        // Spostare sopra per ordine
        [HttpGet]
        public ActionResult<List<Reparto>> FindAll()
        {
            return Ok(_services.GetAll().ToList());
        }

        [HttpDelete("eliminazione")]
        public IActionResult DelByCod(string varCod)
        {
            if (string.IsNullOrEmpty(varCod))
                return BadRequest();

            _services.Delete(varCod);
            return Ok();

        }
        [HttpPost("creazione")]
        public IActionResult CreRepa(Reparto oRep)
        {
            if (oRep.Nome == null || oRep.Fila is null) // Bla bla bla, dovrei aggiungere tutto bene
                return BadRequest();                    // Non lo faccio solo per testare la versione senza DTO

            if (_services.Create(oRep))
                return Ok(oRep);

            return NotFound();
        }

        [HttpPut("aggiornamento")]
        public IActionResult UpdRepa(Reparto oRDTO) // Vorrei mi mostrasse il json del codice che gli passo
        {
            if (oRDTO.Nome == null || oRDTO.Fila is null || oRDTO.RepartoCOD is null)
                return BadRequest();
            
            if (_services.Update(oRDTO))
                return Ok();

            return NotFound();
        }
    }
    
 }
