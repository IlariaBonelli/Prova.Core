using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Core.BusinessLayer;
using Prova.Core.EF.Repos;
using Prova.Core.Interfacce;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        private IMainBusinessLayer businessLayer;

        public OrdineController()
        {
            var clienteRepo = new EFClienteRepos();
            var ordineRepo = new EFOrdineRepos();
            this.businessLayer = new MainBusinessLayer(clienteRepo, ordineRepo);
        }

        //GET api/<OrdineController>/2
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");
            var Ordine = this.businessLayer.FetchOrdineById(id);

            if (Ordine == null)
                return NotFound($"Order with ID = {id} is missing");

            return Ok(Ordine);
        }

        //POST api/<OrdineController>/
        [HttpPost]
        public ActionResult Post([FromBody] Ordine newOrdine)
        {
            if (newOrdine == null)
                return BadRequest("Invalid Order data. ");
            this.businessLayer.CreateOrdine(newOrdine);
            return Created($"/ordine/{newOrdine.Id}", newOrdine);
        }

        //PUT api/<OrdineController>/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return BadRequest("Invalid Order data. ");
            if (id != editedOrdine.Id)
                return BadRequest("Order ID's dont' match. ");
            this.businessLayer.EditOrdine(editedOrdine);
            return Ok();
        }

        //DELETE api/<OrdineController>/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID. ");
            var OrdineToBeDeleted = this.businessLayer.FetchOrdineById(id);

            if (OrdineToBeDeleted != null)
                this.businessLayer.DeleteOrdine(OrdineToBeDeleted);
            return Ok();
        }
    }   
}
