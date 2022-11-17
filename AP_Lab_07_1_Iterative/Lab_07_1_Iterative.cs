/* Lab_07_1_Iterative.cs
 * Якубовський Владислав
 * Лабораторна робота № 7.1
 * Пошук заданих елементів та впорядкування рядків / стовпчиків матриці (ітераційний спосіб)
 * Варіант 24 */
namespace AP_Lab_07_1_Iterative
{
    public class Lab_07_1_Iterative
    {
        readonly static Random random = new();

        public static void CalcMatrix(ref int[,] matrix, out int count, out int sum)
        {
            count = 0; sum = 0;

            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            for (int ii = 0; ii < rows; ii++)
                for (int jj = 0; jj < cols; jj++)
                    if (!(matrix[ii, jj] % 2 == 0 || matrix[ii, jj] % 13 == 0))
                    {
                        count++;
                        sum += matrix[ii, jj];

                        matrix[ii, jj] = 0;
                    }
        }

        static void SortMatrix(ref int[,] matrix)
        {
            int rows = matrix.GetLength(0);

            for (int ii = 0; ii < rows - 1; ii++)
                for (int jj = 0; jj < rows - ii - 1; jj++)
                    if ((matrix[jj, 0] < matrix[jj + 1, 0]) ||
                        (matrix[jj, 0] == matrix[jj + 1, 0] && matrix[jj, 1] < matrix[jj + 1, 1]) ||
                        (matrix[jj, 0] == matrix[jj + 1, 0] && matrix[jj, 1] == matrix[jj + 1, 1] && matrix[jj, 3] < matrix[jj + 1, 3]))
                        ChangeRows(ref matrix, jj, jj + 1);
        }

        static void ChangeRows(ref int[,] matrix, int firstRow, int secondRow)
        {
            int cols = matrix.GetLength(1);

            for (int ii = 0; ii < cols; ii++)
                (matrix[firstRow, ii], matrix[secondRow, ii]) = (matrix[secondRow, ii], matrix[firstRow, ii]);
        }

        static int[,] GenerateMatrix(int rows, int cols)
        {
            int[,] generatedMatrix = new int[rows, cols];

            for (int ii = 0; ii < rows; ii++)
                for (int jj = 0; jj < cols; jj++)
                    generatedMatrix[ii, jj] = random.Next(5, 68);

            return generatedMatrix;
        }

        static void DisplayMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            for (int ii = 0; ii < rows; ii++)
                for (int jj = 0; jj < cols; jj++)
                    Console.Write((jj == 0 ? "||" : "") + $" {matrix[ii, jj]} ".PadRight(6) + (jj == cols - 1 ? "||\n" : ""));
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            const int ROWS = 9,
                COLS = 5;

            int[,] A = GenerateMatrix(ROWS, COLS);

            Console.WriteLine("Згенерована матриця: "); DisplayMatrix(A);

            Console.WriteLine("\nСортована матриця: "); SortMatrix(ref A); DisplayMatrix(A);

            Console.WriteLine("\nОбчислена матриця: "); CalcMatrix(ref A, out int count, out int sum); DisplayMatrix(A);
            Console.WriteLine($"\nЗнайдена к-сть:\t{count}\n" +
                $"Знайдена сума:\t{sum}");
        }
    }
}
