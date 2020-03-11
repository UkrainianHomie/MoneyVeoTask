using System;

namespace ActionsWithMatrix.DTO
{
    public class MatrixDTO
    {
        public int[,] MatrixType{ get; set; }
        public int[] ToArray { get; set; }

        public static MatrixDTO ConversionArray(int[] arr)
        {
            var martix = new MatrixDTO();
            if (arr == null)
                return new MatrixDTO();
            var dim = (int)Math.Sqrt(arr.Length);
            var index = 0;
            martix.MatrixType = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    martix.MatrixType[i, j] = arr[index++];
                }
            }
            return martix;
        }
    }
}
