using System;
using System.Collections.Generic;

namespace Assignment
{
    public class Expression
    {
        static Dictionary<char, int> precedenceDictionary = new Dictionary<char, int>
            {
                {'+', 0},
                {'-', 0},
                {'*', 1},
                {'/', 1},

            };

        public static float Evaluate(string infix)
        {
            return ONPA(SYA(infix));
        }

        static float ONPA(Queue<char> postfix)
        {
            var result = new Stack<float>();
            foreach (var token in postfix)
            {
                if (char.IsDigit(token)) result.Push(Convert.ToInt32(token.ToString()));
                if (precedenceDictionary.ContainsKey(token))
                {
                    float v1 = result.Pop(), v2 = result.Pop();
                    switch (token)
                    {
                        case '+':
                            result.Push(v2 + v1);
                            break;
                        case '-':
                            result.Push(v2 - v1);
                            break;
                        case '*':
                            result.Push(v2 * v1);
                            break;
                        case '/':
                            result.Push(v2 / v1);
                            break;
                    }
                }
            }

            return result.Pop();
        }

        static Queue<char> SYA(string infix)
        {
            var outputQueue = new Queue<char>();
            var operatorStack = new Stack<char>();

            foreach (var token in infix)
            {
                if (char.IsDigit(token)) outputQueue.Enqueue(token);
                if (precedenceDictionary.ContainsKey(token))
                {
                    while (operatorStack.Count > 0 && precedenceDictionary[operatorStack.Peek()] >= precedenceDictionary[token])
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }
            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop());

            return outputQueue;
        }
    }
}
