using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
         private readonly IDbService service;
         public DoctorController(IDbService service)
         {
             this.service = service;
         }

         [HttpGet]
         public IActionResult GetDoctors()
         {
             return Ok(service.getDoctors());
         }
         [HttpPut]
         public IActionResult AddDoctor(Doctor doctor)
         {
             service.addDoctor(doctor);
             return Ok("Dodano doktora");
         }
         [HttpPut("edit")]
         public IActionResult EditDoctor(Doctor doctor)
         {
            var result = service.editDoctor(doctor);
            return Ok(result);
        }


         [HttpDelete("delete")]
         public IActionResult DeleteDoctor(Doctor doctor)
         {
            var result = service.deleteDoctor(doctor);
            if (result == null) return BadRequest("Nie ma takiego doktora");
            return Ok("Doktor usuniety");
        }
    }
}
