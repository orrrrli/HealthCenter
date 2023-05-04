using Business.Contracts;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("sheet")]
    public class SheetController : ApiController
    {
        private readonly ISheetService _sheetService;
        public SheetController(ISheetService sheetService)
        {

            _sheetService = sheetService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Sheet sheet)
        {
            if (sheet == null) return BadRequest("Request is null");
            int id = _sheetService.Add(sheet);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Sheet sheet = _sheetService.Get(id);
            if (sheet == null) return NotFound();
            return Ok(sheet);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Sheet sheet)
        {
            if (sheet == null) return BadRequest("Request is null");
            sheet.Id = id;
            bool updated = _sheetService.Update(sheet);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(sheet);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _sheetService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
