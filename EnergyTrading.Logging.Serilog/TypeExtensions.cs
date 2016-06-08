using System;
using System.Net;
using System.Net.Configuration;

namespace EnergyTrading.Logging.Serilog
{
    public static class TypeExtensions
    {
        public static bool ShouldDeconstruct(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            return !(type.IsPrimitive ||
                     type.Is<decimal>() ||
                     type.Is<byte[]>() ||
                     type.Is<string>() ||
                     type.Is<DateTime>() ||
                     type.Is<DateTimeOffset>() ||
                     type.Is<TimeSpan>() ||
                     type.Is<Guid>() ||
                     type.Is<Uri>() ||
                     type.Is<object>());

        }

        public static bool ShouldDeconstruct<T>(this T item)
        {
            return item != null && ShouldDeconstruct(item.GetType());
        }

        private static bool Is<T>(this Type type)
        {
            return type == typeof(T);
        }
    }
}