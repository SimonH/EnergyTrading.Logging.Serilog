using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EnergyTrading.Logging.Serilog
{
    public static class StringFormatExtensions
    {
        private static string normalFormatPattern = @"\{\d\}";
        public static string ToSerilogFormat(this string format, object[] args)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                return format;
            }
            var result = format;
            var nextIndexes = new Dictionary<string, int>();
            var matches = Regex.Matches(format, normalFormatPattern);
            if ((args == null && matches.Count != 0) || (args != null && matches.Count > args.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(args), "The number of args must match the number of format variables");
            }
            for (var index = 0; index < matches.Count; ++index)
            {
                var type = args[index].GetType();
                if (nextIndexes.ContainsKey(type.Name))
                {
                    result = result.Replace(matches[index].Value, GetReplacementString(type, nextIndexes[type.Name]));
                    nextIndexes[type.Name]++;
                }
                else
                {
                    result = result.Replace(matches[index].Value, GetReplacementString(type, 0));
                    nextIndexes.Add(type.Name, 1);
                }
            }
            return result;
        }

        private static string GetReplacementString(Type type, int nextIndex)
        {
            return "{" + (type.ShouldDeconstruct() ? "@" : string.Empty) + type.Name + (nextIndex > 0 ? "-" + nextIndex : string.Empty) + "}";
        }
    }
}