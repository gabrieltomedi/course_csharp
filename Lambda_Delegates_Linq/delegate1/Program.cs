using delegate1.Services;

namespace delegate1
{
    internal class Program
    {
        delegate double BinaryNumericOperation(double n1, double n2);

        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op =  CalculationService.Sum;
            // BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);

            double result = CalculationService.Sum(a, b);
            Console.WriteLine(result);


            //result = op.Invoke(a, b);
            result = op(a, b);
            Console.WriteLine(result);
        }
    }
}