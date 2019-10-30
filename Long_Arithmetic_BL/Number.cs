using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Long_Arithmetic_BL
{
    public class Number : IComparable<Number>
    {
        private const int BASE = 1000000000;

        private List<ulong> _number;
        private bool _isPositive;


        public List<ulong> Value
        {
            get
            {
                return _number;
            }
        }

        public bool IsPositive
        {
            get
            {
                return _isPositive;
            }
        }

        public Number()
        {
            _number = new List<ulong>();
        }

        private Number(List<ulong> number, char sign)
        {
            _number = number;
            if (sign == '+')
            {
                _isPositive = true;
            }
            else if (sign == '-')
            {
                _isPositive = false;
            }
            else
            {
                throw new ArgumentException("Invalid sign!");
            }
        }

        public Number(long number)
        {
            _number = new List<ulong>();
            if (number >= 0)
            {
                _isPositive = true;
            }
            else
            {
                _isPositive = false;
            }
            FromStringNumberToList(Math.Abs(number).ToString());
        }

        public Number(string number)
        {
            _number = new List<ulong>();
            if (number[0] == '-')
            {
                _isPositive = false;
                number = number.Substring(1);
            }
            else
            {
                _isPositive = true;
                if (number[0] == '+')
                {
                    number = number.Substring(1);
                }
            }
            if (!Char.IsDigit(number[0]))
            {
                throw new ArgumentException("Incorrect input!");

            }

            FromStringNumberToList(number);
        }

        private void FromStringNumberToList(string number)
        {
            var arrayOfNumeral = number.ToCharArray();
            while (arrayOfNumeral.Length > BASE.ToString().Length - 1)
            {
                char[] oneRank = new char[BASE.ToString().Length - 1];
                Array.Copy(arrayOfNumeral, (arrayOfNumeral.Length - (BASE.ToString().Length - 1)),
                    oneRank, 0, BASE.ToString().Length - 1);
                var partForDelete = new string(arrayOfNumeral);
                partForDelete = partForDelete.Remove(arrayOfNumeral.Length - (BASE.ToString().Length - 1));
                arrayOfNumeral = partForDelete.ToCharArray();
                _number.Add(ulong.Parse(new string(oneRank)));
            }
            _number.Add(ulong.Parse(new string(arrayOfNumeral)));
        }

        public override string ToString()
        {
            StringBuilder resultReverse = new StringBuilder();
            //foreach(var num in _number)
            //{
            //    StringBuilder oneRank = new StringBuilder(num.ToString());

            //    if (num != _number.Last())
            //    {
            //        while (oneRank.Length < (BASE.ToString().Length - 1))
            //        {
            //            oneRank.Insert(0, "0");
            //        }
            //    }

            //    resultReverse.Insert(0, oneRank);
            //}
            for (int i = 0; i < _number.Count; i++)
            {
                StringBuilder oneRank = new StringBuilder(_number[i].ToString());

                if (i != _number.Count - 1)
                {
                    while (oneRank.Length < (BASE.ToString().Length - 1))
                    {
                        oneRank.Insert(0, "0");
                    }
                }

                resultReverse.Insert(0, oneRank);
            }
            if (!_isPositive)
            {
                resultReverse.Insert(0, "-");
            }

            return resultReverse.ToString();
        }

        public int CompareTo(Number obj)
        {
            if (obj is null)
            {
                throw new ArgumentException("Argument is null!");
            }

            int result = ToCompare(this.Value, obj.Value);
            return result;
        }

        private int ToCompare(List<ulong> value1, List<ulong> value2)
        {
            if (value1.Count > value2.Count)
            {
                return 1;
            }
            else if (value1.Count < value2.Count)
            {
                return -1;
            }
            else
            {
                for (int i = value1.Count - 1; i >= 0; i--)
                {
                    if (value1[i] > value2[i])
                    {
                        return 1;
                    }
                    else if (value1[i] < value2[i])
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }

        public static bool operator >(Number a, Number b)
        {
            return a.CompareTo(b) == 1;
        }

        public static bool operator <(Number a, Number b)
        {
            return a.CompareTo(b) == -1;
        }

        public static bool operator >=(Number a, Number b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator <=(Number a, Number b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator ==(Number a, Number b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Number a, Number b)
        {
            return a.CompareTo(b) != 0;
        }

        //Calculator
        public static Number Add(Number firstExpr, Number secondExpr)
        {
            var sum = AddRelevantElements(firstExpr.Value, secondExpr.Value);
            var result = AlignRanks(sum);
            return new Number(result, '+');
        }

        private static List<ulong> AddRelevantElements(List<ulong> first, List<ulong> second)
        {
            var length = Math.Min(first.Count, second.Count);
            var sum = new List<ulong>();

            for (int i = 0; i < length; i++)
            {
                sum.Add(first[i] + second[i]);
            }
            if (first.Count > second.Count)
            {
                for (int i = length; i < first.Count; i++)
                {
                    sum.Add(first[i]);
                }
            }
            else
            {
                for (int i = length; i < second.Count; i++)
                {
                    sum.Add(second[i]);
                }
            }
            return sum;
        }

        private static List<ulong> AlignRanks(List<ulong> sum)
        {
            for (int i = 0; i < sum.Count - 1; i++)
            {
                if (sum[i] >= BASE)
                {
                    sum[i + 1] += sum[i] / BASE;
                    sum[i] = sum[i] % BASE;
                }
            }
            if (sum[sum.Count - 1] >= BASE)
            {
                sum.Insert(sum.Count, sum[sum.Count - 1] / BASE);
                sum[sum.Count - 2] = sum[sum.Count - 2] % BASE;
            }
            return sum;
        }

        public static Number Subtract(Number a, Number b)
        {
            char sign;
            List<ulong> minued;
            List<ulong> subtrahend;
            if (a >= b)
            {
                minued = new List<ulong>(a.Value);
                subtrahend = new List<ulong>(b.Value);
                sign = '+';
            }
            else
            {
                minued = new List<ulong>(b.Value);
                subtrahend = new List<ulong>(a.Value);
                sign = '-';
            }

            var result = SubractRelevantElements(minued, subtrahend);

            return new Number(result, sign);
        }

        private static List<ulong> SubractRelevantElements(List<ulong> minued, List<ulong> subtrahed)
        {
            int length = Math.Min(minued.Count, subtrahed.Count);
            List<ulong> subtract = new List<ulong>();
            for (int i = 0; i < length; i++)
            {
                if (minued[i] < subtrahed[i])
                {
                    subtract.Add(minued[i] + BASE - subtrahed[i]);
                    minued = GetRanksFromGreater(minued, i);
                }
                else
                {
                    subtract.Add(minued[i] - subtrahed[i]);
                }
            }

            for (int i = length; i < minued.Count; i++)
            {
                subtract.Add(minued[i]);
            }
            for (int i = subtract.Count - 1; i > 0; i--)
            {
                if (subtract[i] == 0)
                {
                    subtract.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            return subtract;
        }

        private static List<ulong> GetRanksFromGreater(List<ulong> expr, int index)
        {
            if (expr[index + 1] == 0)
            {
                expr[index + 1] = BASE - 1;
                return GetRanksFromGreater(expr, index + 1);
            }
            else
            {
                expr[index + 1] -= 1;
                return expr;
            }
        }

        public static Number Multiply(Number a, Number b)
        {
            var factor1 = a.Value;
            var factor2 = b.Value;

            List<List<ulong>> mulitply = GetAllArraysOfElements(factor1, factor2);

            var result = new List<ulong>();
            foreach (var mul in mulitply)
            {
                result = AddRelevantElements(result, mul);
                result = AlignRanks(result);
            }
            return new Number(result, '+');
        }

        private static List<List<ulong>> GetAllArraysOfElements(List<ulong> factor1, List<ulong> factor2)
        {
            List<List<ulong>> mulitply = new List<List<ulong>>();

            for (int i = 0; i < factor2.Count; i++)
            {
                mulitply.Add(new List<ulong>());
                int k;
                for (k = 0; k < i; k++)
                {
                    mulitply[i].Add(0);
                }
                for (int j = 0; j < factor1.Count; j++)
                {
                    mulitply[i].Add(factor2[i] * factor1[j]);
                }
                mulitply[i] = AlignRanks(mulitply[i]);
            }
            return mulitply;
        }

        public static Number Divide(Number a, Number b, out Number rest)
        {
            if (a < b)
            {
                rest = a;
                return new Number(0);
            }
            else if (a == b)
            {
                rest = new Number(0);
                return new Number(1);
            }
            else
            {
                var beginDividend = new Number(a.Value, '+');

                List<ulong> result = new List<ulong>();

                int indexOfUsedRank = 0;

                while (a >= b)
                {
                    if (a.Value.Count > 0 && a.Value[a.Value.Count - 1] == 0)
                    {
                        result.Insert(0, 0);
                        indexOfUsedRank = a.Value.Count - 1;
                        a.Value.RemoveAt(a.Value.Count - 1);
                    }
                    else
                    {
                        result.Insert(0, GetQuotientAndDecreseDividend(ref a, b, out indexOfUsedRank));
                     }
                }

                //if (a == new Number(0))
                //{
                //    result.Insert(0, 0);
                //}

                for(int i = 0; i < indexOfUsedRank; i++)
                {
                    result.Insert(0, 0);
                }

                var resultOfDivide = new Number(result, '+');

                rest = Subtract(beginDividend, Multiply(b, resultOfDivide));

                return resultOfDivide;
            }
        }

        private static ulong GetQuotientAndDecreseDividend(ref Number dividend, Number divider, out int indexOfLastUsedRank)
        {
            List<ulong> currentDividendValue = new List<ulong>();
            Number currentDividend = new Number(currentDividendValue, '+');
            int indexOfNewDividend = 0;
            for (int i = dividend.Value.Count - 1; i >= 0; i--)
            {
                currentDividendValue.Insert(0, dividend.Value[i]);
                if (currentDividend >= divider)
                {
                    indexOfNewDividend = i;
                    break;
                }
            }
            ulong result = GetQuotient(currentDividend.Value, divider.Value, 0, BASE);

            Number rest = Subtract(currentDividend, Multiply(new Number((long)result), divider));

            List<ulong> newDividend = new List<ulong>();

            //нужон допистаь разряд
            for (int i = 0; i < indexOfNewDividend; i++)
            {
                newDividend.Add(dividend.Value[i]);
            }

            //не нужно дописывать еще один разряд
            if (rest != new Number(0))
            {
                foreach (var element in rest.Value)
                {
                    newDividend.Add(element);
                }
            }

            dividend = new Number(newDividend, '+');
            indexOfLastUsedRank = indexOfNewDividend;
            return (ulong)result;
        }

        public static ulong GetQuotient(List<ulong> dividende, List<ulong> divider, ulong leftBorder, ulong rightBorder)
        {
            ulong currentQuotient = (leftBorder + rightBorder) / 2;
            var currentDividende = new Number(dividende, '+');
            var currentDivider = new Number(divider, '+');

            var current = Number.Multiply(currentDivider, new Number((long)currentQuotient));
            int flag = current.CompareTo(Number.Subtract(currentDividende, currentDivider));
            int flag2 = current.CompareTo(currentDividende);
            if (flag > 0)
            {
                if (flag2 <= 0)
                {
                    return currentQuotient;
                }
                else
                {
                    return GetQuotient(dividende, divider, leftBorder, currentQuotient);
                }
            }
            return GetQuotient(dividende, divider, currentQuotient, rightBorder);
        }

        public static Number Exponent(Number a, Number b)
        {
            throw new NotImplementedException();
        }
    }
}
