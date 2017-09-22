namespace Strategy
{
    public class FibonacciRecursive : FibonacciStrategy
    {
        public override long Calculate(long  n)
        {
            return (n <= 1)
                ? 1
                : Calculate(n - 1) + Calculate(n - 2);
        }
    }
}
