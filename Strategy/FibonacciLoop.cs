namespace Strategy
{
    public class FibonacciLoop : FibonacciStrategy
    {
        public override long Calculate(long n)
        {
            long a = 1;
            long b = 0;
            long temp = 0;

            while (n >= 0)
            {
                temp = a;
                a = a + b;
                b = temp;
                n--;
            }

            return b;
        }
    }
}
