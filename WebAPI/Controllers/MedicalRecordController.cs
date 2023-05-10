using Business.Contracts;
using Business.Implementation;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [RoutePrefix("record")]
    public class MedicalRecordController : ApiController
    {
        private readonly IMedicalRecordService _medicalrecordService;
        public MedicalRecordController(IMedicalRecordService medicalrecordService)
        {

            _medicalrecordService = medicalrecordService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] MedicalRecord medicalRecord)
        {
            if (medicalRecord == null) return BadRequest("Request is null");
            int id = _medicalrecordService.Add(medicalRecord);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            MedicalRecord medicalrecord = _medicalrecordService.Get(id);
            if (medicalrecord == null) return NotFound();
            return Ok(medicalrecord);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] MedicalRecord medicalRecord)
        {
            if (medicalRecord == null) return BadRequest("Request is null");
            medicalRecord.Id = id;
            bool updated = _medicalrecordService.Update(medicalRecord);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(medicalRecord);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _medicalrecordService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }

  

        [Route("{idMedicalRecord}/sheet/{idSheet}")]
        [HttpPost]
        public IHttpActionResult RelateSheet([FromUri] int idMedicalRecord, [FromUri] int idSheet)
        {
            if (idMedicalRecord <= 0) return BadRequest();
            if (idSheet <= 0) return BadRequest();
            return Ok(_medicalrecordService.RelateSheet(idMedicalRecord,idSheet));
        }


        //Relate Role Methods
        [Route("sheet/{idSheet}")]
        public IHttpActionResult GetRole([FromUri] int id)
        {
            if (id < 0) return BadRequest();
            List<Sheet> sheetList = _medicalrecordService.GetSheet(id).ToList();
            return Ok(sheetList);
        }
    }
}
        