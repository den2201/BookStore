using Microsoft.AspNetCore.Http;
using store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web
{
    public static class SessionExtensions
    {
        private static string key = "Cart";

        public static void Set( this ISession session, Cart value)
        {
            if (value == null)
                return;
            using(var stream = new MemoryStream())
                using(var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);
                session.Set(key, stream.ToArray());
            }
            

        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if(session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    value = new Cart(orderId);
                    value.TotalCount = reader.ReadInt32();
                    value.TotalPrice = reader.ReadDecimal();
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
