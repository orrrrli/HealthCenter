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
    }
}
        