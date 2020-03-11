using System;
using System.Threading.Tasks;
using ActionsWithMatrix.DTO;
using ActionsWithMatrix.Services.Interfaces;

namespace ActionsWithMatrix.Services.Implementation
{
    public class MatrixService : IMatrixService
    {
        public async Task<MatrixDTO> Generate()
        {
            var rand = new Random();
            int size = rand.Next(3, 7);
            var arr = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = rand.Next(1,50);
                }
            }
            return await Task.FromResult(new MatrixDTO { MatrixType = arr });
        }

        public async Task<MatrixDTO> Rotate (MatrixDTO matrix)
        {
            var array = matrix.MatrixType;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i; j < array.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        array[i, j] ^= array[j, i];
                        array[j, i] ^= array[i, j];
                        array[i, j] ^= array[j, i];
                    }
                }
            }

            for (int i = 0; i < (array.GetLength(0)) / 2; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[j, i] ^= array[j, array.GetLength(0) - 1 - i];
                    array[j, array.GetLength(0) - 1 - i] ^= array[j, i];
                    array[j, i] ^= array[j, array.GetLength(0) - 1 - i];
                }
            }
            return await Task.FromResult(matrix);
        }
    }
}
