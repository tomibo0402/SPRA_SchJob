
using SPRA_SchJob.Log;
using SPRA_SchJob.Models;
using SPRA_SchJob.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Services
{
    public class EmailService<SPRA_SCHContext> : IEmailService<SPRA_SCHContext>
    {
        private readonly IMISUnitOfWork<SPRA_SCHContext> __misunitofwork;
        public EmailService(IMISUnitOfWork<SPRA_SCHContext> unitOfWork)
        {
            __misunitofwork = unitOfWork;
        }
        public List<EmailRecord> TriggerSendEmail()
        {
            IQueryable<EmailRecord> query = null;

            query = from email in __misunitofwork.GetRepository<EmailRecord>().GetEntity().Where(e => e.IsSent == "N")
                    select email;
            return query.ToList();
        }
    }
}
