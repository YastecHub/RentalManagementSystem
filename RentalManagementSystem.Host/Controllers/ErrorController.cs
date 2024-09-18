
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Host.Models;

namespace RentalManagementSystem.Host.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View();

        /// <summary>
        /// 404
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        public IActionResult NotFound(string errorId)
        {
            if (errorId is null) throw new ArgumentNullException(nameof(errorId));
            ViewBag.ErrorMessage = "Not Found error.";
            return View();
        }

        /// <summary>
        /// 500
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        public IActionResult InternalServerError(string errorId)
        {
            if (errorId is null) throw new ArgumentNullException(nameof(errorId));
            ViewBag.ErrorMessage = "Internal server error.";
            return View();
        }


        /// <summary>
        /// 504
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        public IActionResult GatewayTimeout(string errorId)
        {
            if (errorId is null) throw new ArgumentNullException(nameof(errorId));
            ViewBag.ErrorMessage = "Gateway Timeout error.";
            return View(); // Assuming you have a NotFound action
        }

        /// <summary>
        /// 503
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        public IActionResult ServiceUnavailable(string errorId)
        {
            if (errorId is null) throw new ArgumentNullException(nameof(errorId));
            ViewBag.ErrorMessage = "Service unavailable error.";
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string errorId, string statusCode) => int.Parse(statusCode) switch
        {
            400 or 401 or 403 or 404 or 405 or 409 or 410 or 429 =>
                RedirectToAction("NotFound", "Error", new CustomeErrorViewModel { ErrorId = errorId }),
            500 or 501 or 502 or 505 =>
                RedirectToAction("InternalServerError", "Error", new CustomeErrorViewModel { ErrorId = errorId }),
            503 or 504 =>
                RedirectToAction("ServiceUnavailable", "Error", new CustomeErrorViewModel { ErrorId = errorId }),
            _ =>
                RedirectToAction("InternalServerError", "Error", new CustomeErrorViewModel { ErrorId = errorId }),
        };

    }
}
