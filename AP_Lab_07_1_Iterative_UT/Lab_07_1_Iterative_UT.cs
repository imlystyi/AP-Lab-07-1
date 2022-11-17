/* Lab_07_1_Iterative_UT.cs
 * якубовський ¬ладислав
 * Unit-test до програми Lab_07_1_Iterative.cs */
namespace AP_Lab_07_1_Iterative_UT
{
    [TestClass]
    public class Lab_07_1_Iterative_UT
    {
        [TestMethod]
        public void TestOutFromCalcMatrix()
        {
            int[,] matrix = { { 12, 26, 13, 5 }, { 16, 8, 4, 1 }, { 9, 13, 39, 4 }, { 1, 5, 3, 7 } };

            Lab_07_1_Iterative.CalcMatrix(ref matrix, out int count, out int sum);

            Assert.AreEqual(7, count);
            Assert.AreEqual(31, sum);           
        }
    }
}
