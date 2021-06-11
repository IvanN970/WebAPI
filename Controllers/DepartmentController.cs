using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var result = repo.getDepartments();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var result = repo.getDepartment(id);
            if(result!=null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody]DepartmentModel model)
        {
            var result = await repo.Post(model);
            if(result==1)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await repo.Delete(id);
            if(result==1)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Edit(int id,DepartmentModel model)
        {
            var result = await repo.Edit(id, model);
            if(result==1)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
