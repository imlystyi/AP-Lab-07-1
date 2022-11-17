/* Lab_07_1_Recursive.cs
 * Якубовський Владислав
 * Лабораторна робота № 7.1
 * Пошук заданих елементів та впорядкування рядків / стовпчиків матриці (рекурсивний спосіб)
 * Варіант 24 */
namespace AP_Lab_07_1_Recursive
{
    public class Lab_07_1_Recursive
    {
        readonly static Random random = new();

        public static void CalcMatrix(ref int[,] matrix, int rows, int cols, ref int count, ref int sum, int ii = 0, int jj = 0)
        {
            if (ii < rows)
            {
                if (jj < cols)
                {
                    if (!(matrix[ii, jj] % 2 == 0 || matrix[ii, jj] % 13 == 0))
                    {
                        count++;
                        sum += matrix[ii, jj];

                        matrix[ii, jj] = 0;
                    }

                    CalcMatrix(ref matrix, rows, cols, ref count, ref sum, ii, ++jj);
                }

                else CalcMatrix(ref matrix, rows, cols, ref count, ref sum, ++ii, 0);
            }
        }

        static void SortMatrix(ref int[,] matrix, int rows, int cols, int ii = 0, int jj = 0)
        {
            if (ii < rows - 1)
            {
                if (jj < rows - ii - 1)
                {
                    if ((matrix[jj, 0] < matrix[jj + 1, 0]) ||
                        (matrix[jj, 0] == matrix[jj + 1, 0] && matrix[jj, 1] < matrix[jj + 1, 1]) ||
                        (matrix[jj, 0] == matrix[jj + 1, 0] && matrix[jj, 1] == matrix[jj + 1, 1] && matrix[jj, 3] < matrix[jj + 1, 3]))
                        ChangeRows(ref matrix, cols, jj, jj + 1); 

                    SortMatrix(ref matrix, rows, cols, ii, ++jj);
                }

                else SortMatrix(ref matrix, rows, cols, ++ii, 0);
            }
        }

        static void ChangeRows(ref int[,] matrix, int cols, int firstRow, int secondRow, int ii = 0)
        {
            if (ii < cols)
            {
                (matrix[firstRow, ii], matrix[secondRow, ii]) = (matrix[secondRow, ii], matrix[firstRow, ii]);

                ChangeRows(ref matrix, cols, firstRow, secondRow, ++ii);
            }                
        }

        static void GenerateMatrix(ref int[,] matrix, int rows, int cols, int ii = 0, int jj = 0)
        {
            if (ii < rows)
            {
                if (jj < cols)
                {
                    matrix[ii, jj] = random.Next(5, 68);
                    GenerateMatrix(ref matrix, rows, cols, ii, ++jj);
                }

                else GenerateMatrix(ref matrix, rows, cols, ++ii, 0);
            }
        }

        static void DisplayMatrix(int[,] matrix, int rows, int cols, int ii = 0, int jj = 0)
        {
            if (ii < rows)
            {
                if (jj < cols)
                {
                    Console.Write((jj == 0 ? "||" : "") + $" {matrix[ii, jj]} ".PadRight(6) + (jj == cols - 1 ? "||\n" : ""));

                    DisplayMatrix(matrix, rows, cols, ii, ++jj);
                }

                else DisplayMatrix(matrix, rows, cols, ++ii, 0);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            const int ROWS = 9,
                COLS = 5;

            int count = 0, sum = 0;

            int[,] A = new int[ROWS, COLS];
            
            GenerateMatrix(ref A, ROWS, COLS);

            Console.WriteLine("Згенерована матриця: "); DisplayMatrix(A, ROWS, COLS);

            Console.WriteLine("\nСортована матриця: "); SortMatrix(ref A, ROWS, COLS); DisplayMatrix(A, ROWS, COLS);

            Console.WriteLine("\nОбчислена матриця: "); CalcMatrix(ref A, ROWS, COLS, ref count, ref sum); DisplayMatrix(A, ROWS, COLS);
            Console.WriteLine($"\nЗнайдена к-сть:\t{count}\n" +
                $"Знайдена сума:\t{sum}");
        }
    }
}
