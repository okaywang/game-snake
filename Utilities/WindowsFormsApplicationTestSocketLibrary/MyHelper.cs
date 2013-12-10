using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WindowsFormsApplicationTestSocketLibrary
{

    public class MyHelper
    {
        public static T BinaryDeserializeObject<T>(byte[] serializedType)
        {
            if (serializedType == null)
                throw new ArgumentNullException("serializedType");

            if (serializedType.Length.Equals(0))
                throw new ArgumentException("serializedType");

            T deserializedObject;

            using (MemoryStream memoryStream = new MemoryStream(serializedType))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                deserializedObject = (T)deserializer.Deserialize(memoryStream);
            }

            return deserializedObject;
        }

        /// <summary>
        /// Takes an object and serializes it into a byte array
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize</param>
        /// <returns>The object as a <see cref="byte"/> array</returns>
        public static byte[] BinarySerializeObject<T>(T t)
        {
            if (t == null)
                throw new ArgumentNullException("objectToSerialize");

            byte[] serializedObject;

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                serializedObject = stream.ToArray();
            }

            return serializedObject;
        }
    }
}
