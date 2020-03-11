using System.Threading.Tasks;
using ActionsWithMatrix.DTO;
using ActionsWithMatrix.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActionsWithMatrix.Controllers
{
    public class MatrixController : Controller
    {
        private readonly IActionsWithCSV _actionsWithCSV;
        private readonly IMatrixService _actionsWithMatrix;

        public MatrixController(IActionsWithCSV actionsWithCSV, IMatrixService actionsWithMatrix)
        {
            _actionsWithCSV = actionsWithCSV;
            _actionsWithMatrix = actionsWithMatrix;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _actionsWithCSV.GetArrayFromCSV());
        }

        [HttpGet]
        public async Task<JsonResult> GetMatrixFromCsv()
        {
            return Json(new { matrix = await _actionsWithCSV.GetArrayFromCSV() });
        }


        [HttpGet]
        public async Task<JsonResult> GenerateMatrix()
        {
            return Json(new { matrix = await _actionsWithMatrix.Generate() });
        }

        [HttpPost]
        public async Task<JsonResult> GetRotatedMatrix(MatrixDTO matrix)
        {
            return Json(new { matrix = await _actionsWithMatrix.Rotate(MatrixDTO.ConversionArray(matrix.ToArray)) });
        }
    }
}
