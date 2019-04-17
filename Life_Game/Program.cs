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
        static bool[,] field = new bool[10, 10];
        private static bool[,] newfield {get; set; } = new bool[field.GetLength(0), field.GetLength(1)];
        static void Main(string[] args)
        {
            
            field[0, 0] = true;
            field[2, 0] = true;
            field[1, 1] = true;
            field[2, 1] = true;
            field[1, 2] = true;
            
            while (true)
            {
                Console.CursorVisible = false;
                Display();
                Thread.Sleep(50);
                Update();

            }
        }

        public static void Update()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    newfield[i, j] = IsCellAlive(GetCount(i, j), field[i, j]);
                }
            }

            Rewrite();
        }

        public static void Rewrite()
        {
            field = newfield;
        }

        public static bool IsCellAlive(int count, bool prevStatus)
        {
            if (count < 2 || count > 3) return false;
            if (count == 2) return prevStatus;
            return true;
        }

        private static int GetCount(int x, int y)
        {
            var count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }


                    var dx = x + i;
                    var dy = y + j;

                    if (dx == -1) dx = field.GetLength(0) - 1;

                    if (dx == field.GetLength(0)) dx = 0;

                    if (dy == -1) dy = field.GetLength(1) - 1;

                    if (dy == field.GetLength(1)) dy = 0;

                    if (field[dx, dy]) count++;
                }
            }

            return count;
        }

        private static void Display()
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(newfield[i, j] ? "#" : " " + (j == field.GetLength(1) - 1 ? "\n":""));
                }
            }

        }
    }
    
    
}
