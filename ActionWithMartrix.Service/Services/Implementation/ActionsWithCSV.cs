using System;
using System.Threading.Tasks;
using System.IO;
using ActionsWithMatrix.Services.Interfaces;
using ActionsWithMatrix.DTO;

namespace ActionsWithMatrix.Services.Implementation
{
    public class ActionsWithCSV : IActionsWithCSV
    {
        public async Task<MatrixDTO> GetArrayFromCSV()
        {
            string[] data = { ";", "\r", "\n" };
            using (StreamReader rd = new StreamReader(new FileStream("Matrix.csv", FileMode.Open)))
            {
                await Task.FromResult(data = rd.ReadToEnd().Split(data, StringSplitOptions.RemoveEmptyEntries));
            }
            int size = (int)Math.Sqrt(data.Length);
            var arr = new int[size, size];
            int row = 0, column = 0;
            foreach (string curr in data)
            {
                int.TryParse(curr, out arr[row, column]);
                column++;
                if (column == size)
                {
                    row++;
                    column = 0;
                }
            }
            return new MatrixDTO { MatrixType = arr };
        }
    }
}
