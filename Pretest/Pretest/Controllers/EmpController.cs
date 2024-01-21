using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretest.IRepository;
using Pretest.Models;
using System.Net.WebSockets;

namespace Pretest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeRepo repo;
        public EmpController(IEmployeRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("checklogin/{id}/{password}")]
        public async Task<IActionResult> ProcessLogin(string id, string password)
        {
            try
            {
                var emp = await repo.checkLogin(id, password);
                if (emp == true)
                {
                    return Ok(emp);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("minMaxSalary/{minSalary}/{maxSalary}")]
        public async Task<IActionResult> minMaxSalary(float minSalary, float maxSalary)
        {
            try
            {
                var emp = await repo.FindAll(minSalary, maxSalary);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editsalary/{empID}/{salary}")]
        public async Task<IActionResult> EditSalary(string empID, float salary)
        {
            try
            {
                var empUpdateSalary = await repo.UpdateSalary(empID, salary);
                return Ok(empUpdateSalary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listemp")]
        public async Task<IActionResult> ListEmp()
        {
            try
            {
                return Ok(await repo.FindAllEmp());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("postemp")]
        public async Task<IActionResult> PostNewEmp(tblEmp emp)
        {
            try
            {
                return Ok(await repo.AddnewEmp(emp));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveEmp(string id)
        {
            try
            {
                return Ok(await repo.DeleteEmp(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getone/{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            try
            {
                return Ok(await repo.GetOneEmp(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
