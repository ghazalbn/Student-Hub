using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProj.Shared.Data;
using MyProj.Server.Repositories;

namespace MyProj.Server.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TeacherController : ControllerBase
    {
        private Repository _rpContext;
        public TeacherController(Repository rpContext)
        {
            _rpContext = rpContext;
        }

        [HttpGet("schools")]
        public async Task<IEnumerable<string>> GetSchools()
        => await _rpContext.AllSchools();

        [HttpGet("{school}/teachers")]
        public async Task<IEnumerable<Professor>> GetTeachers(string school)
        => await _rpContext.Teachers(school);
        [HttpGet("{school}/{name}")]
        public async Task<Professor> GetTeacher(string school ,string name)
        => await _rpContext.FindTeacher(name, school);
        
        [HttpPut("{id}/rate")]
        public async Task<ActionResult<Professor>> UpdateTeacher(long id, Rate rate)
        {
            await _rpContext.RateTeacher(id, rate);
            return Ok();
        }
    }
}