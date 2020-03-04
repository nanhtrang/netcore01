using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace blog.Services.Utilities
{
    public class Util
    {
        public static byte[] ConvertObjectToBytes(object obj)
        {
            if (obj == null)
                return null;
            var json = JsonConvert.SerializeObject(obj);
            var value = Encoding.UTF8.GetBytes(json);
            return value;
        }
    }
}