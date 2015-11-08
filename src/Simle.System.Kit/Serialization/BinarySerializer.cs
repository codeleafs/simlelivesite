using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Simle.System.Kit.Serialization
{
    public class BinarySerializer
    {
        public MemoryStream Serialize(object obj)
        {
            // 建立一个继承于Stream的类型的一个对象（可以是FileStream,FileStream等），该对象定义了要将序列化好的字节放到哪里。
            MemoryStream stream = new MemoryStream();

            // 继承于IFormatter的类型的对象，定义了如何去序列化一个对象。
            // 格式化器参考对每个对象的类型进行描述的元数据，从而决定如何序列化对象，序列化时利用反射来查看每个对象的类型中都有哪些实例字段。
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream;
        }

        public T Deserializer<T>(Stream stream)
        {
            // 从流的起始位置进行序列化
            stream.Position = 0;

            BinaryFormatter formatter = new BinaryFormatter();

            return (T)formatter.Deserialize(stream);
        }
    }
}
