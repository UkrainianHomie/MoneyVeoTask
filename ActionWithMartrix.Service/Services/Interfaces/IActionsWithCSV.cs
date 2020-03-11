using System.Threading.Tasks;
using ActionsWithMatrix.DTO;

namespace ActionsWithMatrix.Services.Interfaces
{
    public interface IActionsWithCSV
    {
        Task<MatrixDTO> GetArrayFromCSV();
    }
}
