using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Data;
using Microsoft.EntityFrameworkCore;

namespace DbFirst_one_to_many_crud
{
    public class Logger
    {
        public Logger(AppDbContext context)
        {
        }

        public static void Log(Exception exception)
        {
            StringBuilder sbExceptioMessage = new StringBuilder();
            do
            {
                sbExceptioMessage.Append("Exception type" + Environment.NewLine);
                sbExceptioMessage.Append(exception.GetType().Name);
                sbExceptioMessage.Append(Environment.NewLine + Environment.NewLine);
                sbExceptioMessage.Append($"Dhananjay error message {Environment.NewLine}");
                sbExceptioMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                sbExceptioMessage.Append("Stack Trace " + Environment.NewLine);
                sbExceptioMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);
                exception = exception.InnerException;
            }
            while (exception != null);
            var context = new AppDbContext();
            /* ctx.sbExceptioMessage.Add(exception);
             ctx.SaveChanges();*/
            context.ErrorLog.FromSqlRaw("spInsertLog").ToListAsync();
        }
    }
}
