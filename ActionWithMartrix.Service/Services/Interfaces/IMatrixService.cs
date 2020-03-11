using ActionsWithMatrix.DTO;
using System.Threading.Tasks;

namespace ActionsWithMatrix.Services.Interfaces
{
    public interface IMatrixService
    {
        Task<MatrixDTO> Generate();
        Task<MatrixDTO> Rotate (MatrixDTO matrix);
    }
}
