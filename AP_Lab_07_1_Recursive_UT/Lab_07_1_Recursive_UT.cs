/* Lab_07_1_Recursive_UT.cs
 * якубовський ¬ладислав
 * Unit-test до програми Lab_07_1_Recursive.cs */
namespace AP_Lab_07_1_Recursive_UT
{
    [TestClass]
    public class Lab_07_1_Recursive_UT
    {
        [TestMethod]
        public void TestOutFromCalcMatrix()
        {
            int[,] matrix = { { 12, 26, 13, 5 }, { 16, 8, 4, 1 }, { 9, 13, 39, 4 }, { 1, 5, 3, 7 } };

            int count = 0, sum = 0;

            Lab_07_1_Recursive.CalcMatrix(ref matrix, 4, 4, ref count, ref sum);

            Assert.AreEqual(7, count);
            Assert.AreEqual(31, sum);
        }
    }
}
