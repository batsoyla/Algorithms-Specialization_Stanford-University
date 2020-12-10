using System;
using System.Collections.Generic;
using System.Text;

namespace _2Sum
{
    class twoSum
    {
        public HashSet<long> TwoSum(List<String> numbers, long Target1, long Target2)
        {
            HashSet<long> values = new HashSet<long>();
            HashSet<long> result = new HashSet<long>();
            foreach (String num in numbers)
            {
                long value = Int64.Parse(num);
                for(long i=Target1; i<= Target2; i++)
                {
                    long target = i - value ;
                    if(values.Contains(target))
                    {
                        result.Add(i);
                    }
                    values.Add(value);

                }

            }
            return result;
        }
    }
}
