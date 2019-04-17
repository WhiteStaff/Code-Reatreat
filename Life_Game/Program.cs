using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Life_Game
{
    class Program
    { 
        static void Main(string[] args)
        {
            bool[,] field = new bool[3, 3] { { false, true, false }, { false, true, false }, { false, true, false } };
            

            field = NewArr(field);
        }

        public static bool[,] NewArr(bool[,] field)
        {
            bool[,] newfield = new bool[field.GetLength(0) + 2, field.GetLength(1) + 2];
            for (int i = 1; i < newfield.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < newfield.GetLength(1) - 1; j++)
                {
                    newfield[i, j] = field[i - 1, j - 1];
                }
            }

            return newfield;
        }

        public static bool[,] CorrectArray(bool[,] field)
        {
            return new bool[1,1];
        }

        public static int GetNeighbours(int x, int y, bool[,] field)
        {
            int counter = 0;
            for (int i = -1; i < 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (field[x + 1 + i, y + 1 + i] && ((i != 0) || (j != 0)))
                        counter++;
                }
            }

            return counter;
        }
    }
    
    
}
