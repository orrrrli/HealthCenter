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
    [RoutePrefix("role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {

            _roleService = roleService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Role role)
        {
            if (role == null) return BadRequest("Request is null");
            int id = _roleService.Add(role);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Role role = _roleService.Get(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Role role)
        {
            if (role == null) return BadRequest("Request is null");
            role.Id = id;
            bool updated = _roleService.Update(role);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(role);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _roleService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
