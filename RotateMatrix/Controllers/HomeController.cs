using RotateMatrix.BaseOperations.Abstract;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RotateMatrix.Controllers
{
    public class HomeController : Controller
    {
        private IMatrixOperations matrixOp;

        public HomeController(IMatrixOperations matrixOperations)
        {
            matrixOp = matrixOperations;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            var matrix = new int[,] { };

            if (postedFile != null)
            {
                try
                {
                    matrixOp.Import(matrix, postedFile.InputStream);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View();
                }      
            }

            Session["matrix"] = matrix;
            return View(matrix);
        }

        [HttpGet]
        public ActionResult Generate()
        {
            int[,] matrix = matrixOp.Generate();
            Session["matrix"] = matrix;

            return View("Index",matrix);
        }

        [HttpGet]
        public ActionResult RotateRight()
        {
            var matrix = (int[,])Session["matrix"] as int[,];
            matrixOp.Rotate(matrix, BaseOperations.RotateDirection.Right);
            Session["matrix"] = matrix;

            return View("Index", matrix);
        }
  
        [HttpGet]
        public ActionResult RotateLeft()
        {
            var matrix = (int[,])Session["matrix"] as int[,];
            matrixOp.Rotate(matrix, BaseOperations.RotateDirection.Left);
            Session["matrix"] = matrix;

            return View("Index", matrix);
        }

        [HttpGet]
        public ActionResult Export()
        {
            var matrix = (int[,])Session["matrix"] as int[,];
            var fileBytes = matrixOp.Export(matrix);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "export.csv",
                Inline = false
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}
