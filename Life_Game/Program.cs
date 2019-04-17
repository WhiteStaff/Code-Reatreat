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
        public static bool[,] GetEmptyField(int n, int m, int prob)
        {
            bool[,] empty = new bool[n,m];

            Random gen = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    empty[i, j] = (gen.Next(100)<=prob);

            return empty;
        }

        static void Main(string[] args)
        {
            //Field field = new Field(GetEmptyField(30, 90, 3));
            bool[,] f = new bool[,]
            {
                {false, false, false, false},
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false},
            };
            Field field = new Field(f);
            
            while (true)
            {
                field.Update();
                field.Display();
                Thread.Sleep(500);
            }
        }
    }

    class Field
    {
        private bool[,] field;
        public Field(bool[,] field)
        {
            this.field = field;
        }

        public void Update()
        {
            for (int i = 1; i < field.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < field.GetLength(1) - 1; j++)
                {
                    int count = CountNeighbours(i, j);

                    UpdateCell(i, j, count);
                }
            }
        }

        private void UpdateCell(int i, int j, int count)
        {
            if (count < 2)
                field[i,j] = false;
            if (count == 3)
                field[i,j] = true;
            if (count > 3)
                field[i,j] = false;
        }

        private int CountNeighbours(int i, int j)
        {
            int count = 0;
            for (int k = -1; k < 2; k++)
            {
                for (int l = -1; l < 2; l++)
                {
                    if (field[i + k,j + l] && k!=0 && l!=0)
                        count++;
                }
            }

            return count;
        }


        public void Display()
        {
            Console.Clear();
            for (int i = 1; i < field.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < field.GetLength(1) - 1; j++)
                {
                    if (field[i, j] == false) Console.Write(" ");
                    else Console.Write("#");
                }

                Console.WriteLine();
            }
        }
    }
}
