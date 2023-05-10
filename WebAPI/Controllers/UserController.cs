using Business.Contracts;
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

    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] User user)
        {
            if (user == null) return BadRequest("Request is null");
            int id = _userService.Add(user);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            User user = _userService.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] User user)
        {
            if (user == null) return BadRequest("Request is null");
            user.Id = id;
            bool updated = _userService.Update(user);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(user);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            bool u = _userService.Delete(id);
            if (u) return BadRequest();
            return Ok(u);
        }
        [Route("record/{id}")]

        public IHttpActionResult GetMedicalRecord([FromUri] int id)
        {
            if (id <= 0) return BadRequest();
            List<MedicalRecord> medicalRecordList = _userService.GetMedicalRecords(id).ToList();
            return Ok(medicalRecordList);
        }

        [Route("{idUser}/record/{idMedicalRecord}")]
        [HttpPost]
        public IHttpActionResult RelateMedicalRecords([FromUri] int idUser, [FromUri] int idMedicalRecord)
        {
            if (idUser <= 0) return BadRequest();
            if (idMedicalRecord <= 0) return BadRequest();
            return Ok(_userService.RelateMedicalRecords(idUser, idMedicalRecord));
        }



        [Route("login")]
        [HttpPost]
        public IHttpActionResult LoginUser([FromBody] UserDTO user)
        {
            if (user.Email == null) return BadRequest();
            if (user.Password == null) return BadRequest();
            return Ok(_userService.Login(user.Email, user.Password));
        }
    }
}


