using System;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// This is implicit/explicit casting. Useful for when we want to use a value
            /// as the same value in a different datatype. Overflow issues can occur.
            /// e.g. Converting an integer value to a double for a specific calculation
            /// </summary>
            Console.WriteLine("Casting: ");
            int x = 5;
            double y = x;
            byte z = (byte)y;
            Console.WriteLine($"x, y, z: {x}, {y}, {z}");

            /// <summary>
            /// Parsing is effective at getting values out of string objects, but the format
            /// of the string needs to be appropriate
            /// e.g. Parsing values out of user-input from a website/api
            /// </summary>
            Console.WriteLine("Parsing: ");
            string time = "12:00:00";

            try
            {
                int hr = int.Parse(time);
                Console.WriteLine($"time: {time}, hr: {hr}");
            }
            catch (Exception)
            {
                Console.WriteLine("parse 1 failed.");
            }

            try
            {
                int hr = DateTime.Parse(time).Hour;
                Console.WriteLine($"time: {time}, hr: {hr}");
            }
            catch (Exception)
            {
                Console.WriteLine("parse 2 failed.");
            }

            /// <summary>
            /// Converting is more flexible than casting and parsing, as it allows user-defined conversions.
            /// Converting will return the default value in cases where parsing will throw an error.
            /// e.g. creating a class to represent complex numbers could benefit from conversions to built in
            ///     numeric types
            /// </summary>
            Console.WriteLine("Converting: ");

            int a = 100;
            double b = Convert.ToDouble(a);
            string s = "1083";
            int c = Convert.ToInt32(s);
            Console.WriteLine($"a: {a}, b: {b}, c: {c}, s: {s}");

            ConvertMe test = new();
            double d = Convert.ToDouble(test);
            DateTime date = Convert.ToDateTime(test);
            Console.WriteLine($"Conversion: {test}, double: {d}, date: {date}");

            try
            {
                Convert.ToDecimal(test);
            }
            catch (Exception)
            {
                Console.WriteLine($"decimal conversion not defined for {test}");
            }

            try
            {
                DontConvertMe test2 = new();
                Convert.ToDouble(test2);
            }
            catch (Exception)
            {
                Console.WriteLine("failed conversion");
            }

            ConvertMe2 testChangetype = new ConvertMe2(1, 5);
            ConvertMe testConvert = Convert.ChangeType(testChangetype, typeof(ConvertMe)) as ConvertMe;
            Console.WriteLine($"Test3: {testConvert}");
        }
    }

    class DontConvertMe
    {
        private int value = 5;
    }

    class ConvertMe2 : ConvertMe
    {

        public ConvertMe2(int a, int b) : base(a, b) { }

    }

    class ConvertMe : IConvertible
    {
        private int value1 = 6;
        private int value2 = 16;

        public ConvertMe() : base() { }

        public ConvertMe(int v1, int v2)
        {
            value1 = v1;
            value2 = v2;
        }

        public override string ToString()
        {
            return $"Convert me: {value1}, {value2}";
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return value1 + value2;
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return new DateTime(value2, value1, 1);
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(ConvertMe))
            {
                return (ConvertMe)this;
            }
            else
            {
                return null;
            }
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
