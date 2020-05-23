using cw11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public class ClinicDbService : IDbService
    {
        private readonly CodeFirstContext context;
        public ClinicDbService(CodeFirstContext context)
        {
            this.context = context;
        }
        public List<Doctor> getDoctors()
        {
            return context.Doctor.ToList();
        }
        public void addDoctor(Doctor doc)
        {
            context.Doctor.Add(doc);
            context.SaveChanges();
        }

        public Doctor deleteDoctor(Doctor doc)
        {
            var doct = context.Doctor.FirstOrDefault(s => s.IdDoctor == doc.IdDoctor);
            if (doct == null) return null;
            context.Attach(doct);
            context.Remove(doct);
            context.SaveChanges();
            return doct;
        }

        public Doctor editDoctor(Doctor doc)
        {
            try
            {
                context.Attach(doc);
                context.Entry(doc).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return doc;
        }
    }
}
