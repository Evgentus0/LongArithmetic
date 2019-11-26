using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long_Arithmetic_BL
{
    public class Number : IComparable<Number>
    {
        private const int BASE = 1000000000;
        //private const int BASE = 10;

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
            AlignRanks(sum);
            return new Number(sum, '+');
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

        private static void AlignRanks(List<ulong> sum)
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
                AlignRanks(result);
            }
            // MultiplyByRef(factor1, factor2);
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
                AlignRanks(mulitply[i]);
            }
            return mulitply;
        }

        public static (Number result, Number rest) Divide(Number a, Number b)
        {
            if (b == new Number(0))
            {
                throw new DivideByZeroException("Incorrect input data!");
            }

            if (a < b)
            {
                return (new Number(0), a);
            }
            else if (a == b)
            {
                return (new Number(1), new Number(0));
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

                for (int i = 0; i < indexOfUsedRank; i++)
                {
                    result.Insert(0, 0);
                }

                var resultOfDivide = new Number(result, '+');

                var rest = Subtract(beginDividend, Multiply(b, resultOfDivide));

                return (resultOfDivide, rest);
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

        private static ulong GetQuotient(List<ulong> dividende, List<ulong> divider, ulong leftBorder, ulong rightBorder)
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

        public static Number Exponent(Number a, Number n)
        {
            if (n.ToString() == "0" || a.ToString() == "1")
            {
                return new Number(1);
            }
            else if (a.ToString() == "0")
            {
                return new Number(0);
            }
            else
            {
                var num1 = new Number(new List<ulong>(a.Value), '+');
                var num2 = new Number(new List<ulong>(n.Value), '+');
                return new Number(DoExponent(num1.Value, num2.Value), '+');
            }
        }

        private static List<ulong> DoExponent(List<ulong> a, List<ulong> b)
        {
            //var result = new List<ulong>(a);

            //while (!(b.Count == 1 && b.First() < 2))
            //{
            //    MultiplyByRef(result, result);

            //    if (b.First() % 2 != 0)
            //    {
            //        MultiplyByRef(result, a);
            //    }
            //    DivideByTwo(b);
            //}

            //return new Number(result, '+');

            if (b.Count == 1 && b.First() < 2)
            {
                return a;
            }

            else
            {
                var x = DoExponent(a, Divide(new Number(b, '+'), new Number(2)).result.Value);
                if (b.First() % 2 == 0)
                {
                    return Multiply(new Number(x, '+'), new Number(x, '+')).Value;
                }
                else
                {
                    return Multiply(new Number(x, '+'), Multiply(new Number(x, '+'), new Number(a, '+'))).Value;
                }
            }
        }

        private static void MultiplyByRef(List<ulong> result, List<ulong> a)
        {
            var current = new List<ulong>(result);
            var factor2 = new List<ulong>(a);
            //первый проход, для задания значений
            for (int j = 0; j < current.Count; j++)
            {
                result[j] = factor2[0] * current[j];
            }
            AlignRanks(result);

            //все остальные проходы

            for (int i = 1; i < factor2.Count; i++)
            {
                for (int j = 0; j < current.Count; j++)
                {
                    if (result.Count <= i + j)
                    {
                        result.Insert(result.Count, factor2[i] * current[j]);
                    }
                    else
                    {
                        result[j + i] += factor2[i] * current[j];
                    }
                }
                AlignRanks(result);
            }
        }

        private static void DivideByTwo(List<ulong> dividend)
        {
            ulong current;
            for (int i = dividend.Count - 1; i >= 0; i--)
            {
                current = dividend[i];
                if (current == 0)
                {
                    continue;
                }
                else if (current == 1)
                {
                    dividend[i] = 0;
                    i--;
                    if (i < 0)
                    {
                        break;
                    }
                    current += BASE + dividend[i];
                    dividend[i] = current / 2;
                    continue;
                }
                else
                {
                    dividend[i] = current / 2;
                }
            }
            if (dividend[dividend.Count - 1] == 0)
            {
                dividend.RemoveAt(dividend.Count - 1);
            }
        }

        public static Number Module(Number a, Number b)
        {
            return Divide(a, b).rest;
        }

        public static Number ExponentWithModule(Number a, Number b, Number module)
        {
            if (module.ToString() == "1" || a.ToString() == "1" || a.ToString() == "0" || b.ToString() == "0")
            {
                if (a.ToString() == "0")
                {
                    return new Number(0);
                }
                else
                {
                    return new Number(1);
                }
            }
            else
            {
                return new Number(DoExponentWithModule(a.Value, b.Value, module), '+');
            }
        }

        private static List<ulong> DoExponentWithModule(List<ulong> a, List<ulong> b, Number module)
        {
            //var result = new List<ulong>(a);

            //while (!(b.Count == 1 && b.First() < 2))
            //{
            //    MultiplyByRef(result, result);

            //    if (b.First() % 2 != 0)
            //    {
            //        MultiplyByRef(result, a);
            //    }
            //    result = Module(new Number(result, '+'), module).Value;

            //    DivideByTwo(b);
            //}

            //return new Number(result, '+');

            if (b.Count == 1 && b.First() < 2)
            {
                return Module(new Number(a, '+'), module).Value;
            }

            else
            {
                var x = DoExponentWithModule(a, Divide(new Number(b, '+'), new Number(2)).result.Value, module);
                if (b.First() % 2 == 0)
                {
                    return Module(Multiply(new Number(x, '+'), new Number(x, '+')), module).Value;
                }
                else
                {
                    return Module(Multiply(new Number(x, '+'), Multiply(new Number(x, '+'), new Number(a, '+'))), module).Value;
                }
            }
        }

        public static Number Sqrt(Number x)
        {
            if (!x.IsPositive)
            {
                throw new ArgumentException("Expr under sqrt can not be negative!");
            }
            return DoSqrt(x, new Number(0), new Number(x.Value, '+'));

        }

        private static Number DoSqrt(Number x, Number a, Number b)
        {
            if(Add(a, new Number(1)) == b){
                if (Multiply(b, b) <= x)
                {
                    return b;
                }
                else
                {
                    return a;
                }
            }
            else
            {
                Number middle = Add(a, b);
                DivideByTwo(middle.Value);
                if(Multiply(middle, middle) < x)
                {
                    return DoSqrt(x, middle, b);
                }
                else
                {
                    return DoSqrt(x, a, middle);
                }
            }
        }

        #region Async Method
        public static async Task<Number> AddAsync(Number a, Number b)
        {
            return await Task.Run(() => Add(a, b));
        }

        public static async Task<Number> SubtractAsync(Number a, Number b)
        {
            return await Task.Run(() => Subtract(a, b));
        }

        public static async Task<Number> MultiplyAsync(Number a, Number b)
        {
            return await Task.Run(() => Multiply(a, b));
        }

        public static async Task<(Number result, Number rest)> DivideAsync(Number a, Number b)
        {
            return await Task.Run(() => Divide(a, b));
        }

        public static async Task<Number> ExponentAsync(Number a, Number b)
        {
            return await Task.Run(() => Exponent(a, b));
        }

        public static async Task<Number> ModuleAsync(Number a, Number b)
        {
            return await Task.Run(() => Module(a, b));
        }

        public static async Task<Number> ExponentWithModuleAsync(Number a, Number b, Number module)
        {
            return await Task.Run(() => ExponentWithModule(a, b, module));
        }

        public static async Task<Number> SqrtAsync(Number a)
        {
            return await Task.Run(() => Sqrt(a));
        }
        #endregion


    }
}

