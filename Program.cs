using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie
{
    class MyTools
    {
        public string CharInversion(string word_to_reverse)
        {
            // preparation of auxiliary variables
            string reversed_word = "";
            int word_to_reverse_size = word_to_reverse.Length;

            // inverting loop
            for (int i = 0; i < word_to_reverse_size; i++ )
            {
                reversed_word += word_to_reverse[word_to_reverse_size - 1 - i];
            }

            // change in case of letters
            char[] letters = reversed_word.ToCharArray();
            letters[word_to_reverse_size-1] = char.ToLower(letters[word_to_reverse_size - 1]);
            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

        public int[,] MatrixCalculate(int[,] matrix)
        {
            // get the length of the matrix
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            // preparation of the target matrix
            int[,] outputMatrix = new int[2, 2];

            // rewriting values from matrix NxN to 2x2
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {

                    if (j > i && j < rowLength - 1 - i)
                        outputMatrix[0, 0] += matrix[i, j];

                    if (i < j && i > rowLength - 1 - j)
                        outputMatrix[0, 1] += matrix[i, j];

                    if (j < i && j > rowLength - 1 - i)
                        outputMatrix[1, 0] += matrix[i, j];

                    if (i > j && i < rowLength - 1 - j)
                        outputMatrix[1, 1] += matrix[i, j];
                }
            }

            return outputMatrix;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTools myTool = new MyTools();

            // ex 1 result
            String result = myTool.CharInversion("Bumbershoot"); /// <-------   METHOD 1
            Console.WriteLine(result);

            // ex 2 result
            Console.WriteLine("");

            int[,] matrix = new int[5, 5] // example matrix for simple check correct
                {
                    { 1, 10, 10, 10, 1 },
                    { 10000, 1, 10, 1, 100 },
                    { 10000, 10000, 1, 100, 100 },
                    { 10000, 1, 1000, 1, 100 },
                    { 1, 1000, 1000, 1000, 1 }
                };
            
            int[,] outputMatrix = myTool.MatrixCalculate(matrix); /// <-------   METHOD 2

            int rowLength = outputMatrix.GetLength(0);
            int colLength = outputMatrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", outputMatrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
