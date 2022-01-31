using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using DbFirst_one_to_many_crud.Data;
using DbFirst_one_to_many_crud.Models;

namespace DbFirst_one_to_many_crud.CustomFilter
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(System.Web.Http.ExceptionHandling.ExceptionContext filterContext)
        {
                /*ErrorLog logger = new ErrorLog()
                {
                   Message = filterContext.Exception.Message,
                   StackTrace = filterContext.Exception.StackTrace,
                   LoggedOn = DateTime.Now
                };

                AppDbContext ctx = new AppDbContext();
                ctx.ErrorLog.Add(logger);
                ctx.SaveChanges();*/
        }

        public void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
