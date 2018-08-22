using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix.BaseOperations.Abstract
{
    public interface IMatrixOperations
    {
        int[,] Generate();
        void Rotate(int[,] matrix, RotateDirection rotateDirection);
        void Import(int[,] matrix, Stream file);
        byte[] Export(int[,] matrix);
    }
}
