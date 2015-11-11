using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Simle.System.Kit.Serialization
{
    public class ObjectClone
    {
        /// <summary>
        /// 对象的深copy
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Clone(object value)
        {
            using(MemoryStream stream =new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // 深度clone
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);

                formatter.Serialize(stream, value);

                stream.Position = 0;

                return formatter.Deserialize(stream);
            }
        }
    }
}
