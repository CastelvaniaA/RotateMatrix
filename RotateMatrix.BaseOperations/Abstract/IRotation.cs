using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix.BaseOperations.Abstract
{
    public interface IRotation
    {
        void Rotate90Left(int[,] inputMatrix);
        void Rotate90Right(int[,] inputMatrix);
    }
}
