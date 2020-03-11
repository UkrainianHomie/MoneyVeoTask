using ActionsWithMatrix.Services.Interfaces;
using ActionsWithMatrix.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ActionsWithMatrix.DTO;

namespace ActionsWithMatrix.Service.Tests
{
    [TestClass]
    public class MatrixServiceTest
    {
        private IActionsWithCSV _actionsWithCSV;
        private readonly IMatrixService _matrixService;

        public MatrixServiceTest()
        {
            _actionsWithCSV = new ActionsWithCSV();
            _matrixService = new MatrixService();
        }

        [TestMethod]
        public async Task GetGenerateMatrix()
        {
            var result = await _matrixService.Generate();

            Assert.IsTrue(result.MatrixType.Length != 0);
        }

        [TestMethod]
        public async Task GetRotateMatrix()
        {
            var matrixDto = new MatrixDTO
            {
                MatrixType = new int[,]
                {
                    { 10, 15, 20 },
                    { 30, 50, 70 },
                    { 40, 65, 90 }
                }
            };

            Assert.AreEqual(matrixDto.MatrixType[1, 1], 50);
            Assert.AreEqual(matrixDto.MatrixType[0, 0], 10);
            var result = await _matrixService.Rotate(matrixDto);

            Assert.IsTrue(result.MatrixType.Length > 0);
            Assert.AreEqual(matrixDto.MatrixType[1, 1], 50);
            Assert.AreNotEqual(matrixDto.MatrixType[0, 0], 10);
            Assert.AreEqual(matrixDto.MatrixType[0, 0], 40);
            Assert.AreEqual(matrixDto.MatrixType[2, 1], 70);
        }

    }
}
