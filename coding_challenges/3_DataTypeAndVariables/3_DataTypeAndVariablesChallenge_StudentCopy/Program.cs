using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool b = false;
            byte by = byte.MaxValue;
            sbyte sby = sbyte.MaxValue;
            char c = char.MaxValue;
            decimal dec;
            double db;
            float f;
            int i;
            uint ui;
            nint ni;
            nuint nui;
            long l;
            ulong ul;
            short s;
            ushort us;
        }

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            switch (obj)
            {
                case int x:
                    return "Data type => int";
                case bool b:
                    return "Data type => bool";
                case byte by:
                    return "Data type => byte";
                case sbyte sby:
                    return "Data type => sbyte";
                case char c:
                    return "Data type => char";
                case decimal dec:
                    return "Data type => decimal";
                case double db:
                    return "Data type => double";
                case float f:
                    return "Data type => float";
                case uint ui:
                    return "Data type => uint";
                case nint ni:
                    return "Data type => nint";
                case nuint nui:
                    return "Data type => nuint";
                case long l:
                    return "Data type => long";
                case ulong ul:
                    return "Data type => ulong";
                case short s:
                    return "Data type => short";
                case ushort us:
                    return "Data type => ushort";
                case string v:
                    return "Data type => string";
            }
            return $"Data type => {(obj.GetType()).Name.ToLower()}";
        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            //int res;
            if (!int.TryParse(numString, out int res))
            {
                return null;
            }
            return res;
        }
    }// end of class
}// End of Namespace
