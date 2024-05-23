using System;
using System.Collections.Generic;
using System.IO;


namespace Print_graf
{
    class Program
    {
        static int[,] matrix;
        static int[,] ReadMatrix()
        {
            string[] lines = File.ReadAllLines("matr.txt");
            int[,] matrix = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = Convert.ToInt32(temp[j]);
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matr)
        {
            Console.Write("\t  ");
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                Console.Write(i +1 + "|");
            }
            Console.WriteLine();
            Console.Write("\t");
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                Console.Write(i+1 +"|");
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
                Console.Write("\t");
            }
            Console.Write("\n");


        }
        static bool CheckColorGraph(List<int> colorGraph) //стоп если у всех есть цвета
        {
            bool fullColorGraph = true;
            for (int i = 0; i < colorGraph.Count; i++)
            {
                if (colorGraph[i] == 22) // еще не раскрашена
                {
                    fullColorGraph = false;
                }
            }
            return fullColorGraph;
        }
        

        static List<List<int>> colors = new List<List<int>>(); //список листов - вершины по цветам

        static void ColoringGraph(List<int> colorVertex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (colorVertex.Contains(i)) { continue; }
                List<int> newColor = new List<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        

                        if (!newColor.Contains(i) && colorVertex[i] == 22) { newColor.Add(i); } // еще не раскрашена 
                        if (!newColor.Contains(j) && colorVertex[j] == 22) { newColor.Add(j); }

                        colorVertex[i] = i;
                        colorVertex[j] = j;

                        SumIJinMatrix(i, j);
                        DeleteIJinMatrix(i, j);
                    }
                    
                }
                if (newColor.Count == 0) // если цвета не нашлось, до добавим новый
                {
                    if (!newColor.Contains(i) && colorVertex[i] == 22) { newColor.Add(i); }
                    colorVertex[i] = i;
                }
                
                colors.Add(newColor);
                if (CheckColorGraph(colorVertex)) { return; }
            }
           
        }
        static void UpdateMatrix(int[] sumStr, int iV) // обновлнение матрицы
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[iV, j] = sumStr[j];
            }
        }
        static void SumIJinMatrix(int iV, int jV)
        {
            int[] sumIJ = new int[matrix.GetLength(1)];
            for (int i = 0; i < sumIJ.Length; i++)
            {
                sumIJ[i] = matrix[iV, i] + matrix[jV, i]; //стягивание
            }
            UpdateMatrix(sumIJ, iV);
        }

        static void DeleteIJinMatrix(int iV, int jV)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[i, iV] = 5;
                matrix[i, jV] = 5;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("   Матрица смежности:\n");
            
            matrix = ReadMatrix();
            PrintMatrix(matrix);

            int countVertex = matrix.GetLength(0);
            

            List<int> coloring = new List<int>();
            
            for (int i = 0; i < countVertex; i++)
            {
                
                coloring.Add(22);
            }

            ColoringGraph(coloring);

            Console.WriteLine("\n   Раскраска графа:\n");

            for (int i = 0; i < colors.Count; i++)
            {
                Console.Write($"Цвет - {i}. Вершина(ы) -  ");
                for (int j = 0; j < colors[i].Count; j++)
                {
                    Console.Write(colors[i][j]+1  + "   ");
                }
                Console.WriteLine();
            }
            Console.Write("\n");
           
        }
    }
}