using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Simle.System.Kit.Serialization
{
    /// <summary>
    /// 二进制序列化
    /// 序列化时类型的全名和类型的定义程序集的名称会被写入流
    /// 其中包括程序集的完整标识（程序集的文件名，版本号，语言文化及公钥对象）
    /// 格式化器在程序集中查找与要反序列化的对象匹配的一个类型，
    /// 找到匹配的类型后，就创建一个类型的实例，并用流中包含的字段进行初始化
    /// 序列化对象必须是标识了SerializableAttribute的对象
    /// 可设置对象的字段为NonSerializedAttribute将不会序列化该字段
    /// 可以对方法设置OnSerializingAttribute/OnSerializedAttribute/OnDeserializingAttribute/OndeserializedAttribute 在序列化的恰当时刻调用该方法
    /// </summary>
    public class BinarySerializer
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>数据流</returns>
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

        /// <summary>
        /// 顺序序列化多对象
        /// </summary>
        /// <returns></returns>
        public MemoryStream Serialize<T1, T2>(T1 obj1, T2 obj2)
        {
            MemoryStream stream = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj1);
            formatter.Serialize(stream, obj2);

            return stream;
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserializer<T>(Stream stream)
        {
            // 从流的起始位置进行序列化
            stream.Position = 0;

            BinaryFormatter formatter = new BinaryFormatter();

            return (T)formatter.Deserialize(stream);
        }

        /// <summary>
        /// 顺序反序列化多对象
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="stream"></param>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void Deserializer<T1, T2>(Stream stream, out T1 obj1, out T2 obj2)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // 反序列化的顺序与序列化时顺序要一致
            obj1 = (T1)formatter.Deserialize(stream);
            obj2 = (T2)formatter.Deserialize(stream);
        }
    }
}
