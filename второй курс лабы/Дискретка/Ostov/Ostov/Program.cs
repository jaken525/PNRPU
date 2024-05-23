using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ostov
{
    internal class Program
    {
        static int[,] ReadMatrix()
        {
            string[] lines = File.ReadAllLines(@"graf.txt");
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
            Console.Write("\t");
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
                Console.Write("\t");
            }
            Console.Write("\n");
        }

        static List<Edges> KruskalsAlgorithm(List<Edges> edges, List<int> peacks)
        {
            List<Edges> result = new List<Edges>();

            var sortedEdge = edges.OrderBy(x => x.EdgeWeight).ToList(); // сортируем ребра по возрастанию

            /*Console.WriteLine("Сортировка ребер по весу:");
            foreach (var ed in sortedEdge)
            {
                Console.WriteLine($"{ed.Vertex1} --- {ed.Vertex2} --- {ed.EdgeWeight}");
            }*/

            Set set = new Set(100);

            foreach (int vertex in peacks)
                set.MakeSet(vertex);

            foreach (Edges edge in sortedEdge)
            {
                if (set.FindSet(edge.Vertex1) != set.FindSet(edge.Vertex2)) // если два ребра из разных множеств   
                {
                    result.Add(edge);
                    set.Union(edge.Vertex1, edge.Vertex2);//то они объединяются в одно
                }
            }
            return result;
        }
        public static int MinKey(int[] key, bool[] set, int verticesCount) // ребро мин веса
        {
            int min = int.MaxValue, minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (set[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public static void PrimsAlgorithm(int[,] matrix, int verticesCount)
        {
            int[] parent = new int[verticesCount];
            int[] key = new int[verticesCount];
            bool[] mstSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < verticesCount; ++count)
            {
                int u = MinKey(key, mstSet, verticesCount); // находи минимальную смежную и включаем в дерево
                mstSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (Convert.ToBoolean(matrix[u, v]) && mstSet[v] == false && matrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = matrix[u, v];
                    }
                }
            }
            int result = 0;

            for (int i = 1; i < verticesCount; ++i)
            {
                result += matrix[i, parent[i]];
                Console.WriteLine($"Из вершины {parent[i] + 1}  в вершину {i + 1}, вес ребра = {matrix[i, parent[i]]}");
            }

            Console.WriteLine($"\nСуммарная длина остова {result}\n");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("   Матрица смежности:\n");
            int[,] matrix;
            matrix = ReadMatrix();
            PrintMatrix(matrix);

            List<Edges> edges = new List<Edges>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        edges.Add(new Edges { Vertex1 = i, Vertex2 = j, EdgeWeight = matrix[i, j] });
                    }
                }
            }
 
            List<int> peaks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 7, 9 };

            List<Edges> MinimumOstovTree = KruskalsAlgorithm(edges, peaks);

            int resultroute = 0;

            Console.WriteLine("\n\nОстовной граф (АЛГОРИТМ КРАСКАЛА):");

            foreach (Edges edge in MinimumOstovTree)
            {
                resultroute += edge.EdgeWeight;
                Console.WriteLine($"Из вершины {edge.Vertex1 + 1} в вершину {edge.Vertex2 + 1}, вес ребра = {edge.EdgeWeight}");
            }
            Console.WriteLine($"\nСуммарная длина остова {resultroute}\n");


            Console.WriteLine("\n\nОстовной граф (АЛГОРИТМ ПРИМА):");
            PrimsAlgorithm(matrix, matrix.GetLength(1));
        }
    }
}