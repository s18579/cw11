using cw11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public interface IDbService
    {
        public List<Doctor> getDoctors();
        public void addDoctor(Doctor doc);
        public Doctor editDoctor(Doctor doc);
        public Doctor deleteDoctor(Doctor doc);
    }
}
