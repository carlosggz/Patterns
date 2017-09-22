using System.Collections.Generic;

namespace Strategy
{
    public class FibonacciMemoization : FibonacciStrategy
    {
        private Dictionary<long, long> _values = new Dictionary<long, long>();

        public override long Calculate(long n)
        {
            _values.Clear(); //we can keep the values between calls to optimize the calculation
            return _Calculate(n);
        }

        private long _Calculate(long n)
        {
            if (n <= 1)
                return 1;

            if (_values.ContainsKey(n))
                return _values[n];

            return _values[n] = _Calculate(n - 1) + _Calculate(n - 2);
        }
    }
}
