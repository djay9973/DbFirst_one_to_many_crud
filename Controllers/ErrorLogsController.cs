using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst_one_to_many_crud.Data;
using DbFirst_one_to_many_crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DbFirst_one_to_many_crud.Controllers
{
    public class ErrorLogsController : Controller
    {
        private readonly ILogger<ErrorLogsController> logger;
        private readonly AppDbContext _context;

        public ErrorLogsController(AppDbContext context, ILogger<ErrorLogsController> logger)
        {
            _context = context;
            this.logger = logger;
        }
        [Route("Error /{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry , the resource could not found";
                    //ViewBag.Path = statusCodeResult.OriginalPath;
                    break;
            }
            return View("NotFound");
        }
        [Route("500")]
        [AllowAnonymous]
        public async Task<IActionResult> Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var errorLog = new ErrorLog
            {
                ErrorId = Guid.NewGuid(),
                Message = $"Dhanajay Type: {exceptionDetails.Error.GetType()} Message: {exceptionDetails.Error.Message}",
                LoggedOn = DateTime.Now,
                StackTrace = $"Stack trace {exceptionDetails.Error.StackTrace}"
            };

            _context.Add(errorLog);
            await _context.SaveChangesAsync();
            ViewBag.ErrorId = errorLog.ErrorId;
            ViewBag.Message = errorLog.Message;
            ViewBag.StackTrace = errorLog.StackTrace;
            return View();

        }
    }
}
