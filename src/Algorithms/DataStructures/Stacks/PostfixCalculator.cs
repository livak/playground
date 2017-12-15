using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class PostfixCalculator
    {
        public static int Calculate(IEnumerable<string> tokens)
        {
            var stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out var item))
                {
                    stack.Push(item);
                }
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    var dic = new Dictionary<string, Func<int>>()
                    {
                        ["+"] = () => left + right,
                        ["-"] = () => left - right,
                        ["*"] = () => left * right,
                        ["/"] = () => left / right
                    };

                    if (dic.TryGetValue(token, out var v))
                    {
                        stack.Push(v());
                    }
                    else
                    {
                        throw new ArgumentException($"Unrecognized token: {token}");
                    }
                }
            }

            return stack.Pop();
        }
    }
}
