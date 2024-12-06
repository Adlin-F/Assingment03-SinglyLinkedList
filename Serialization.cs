using System.IO;
using System.Runtime.Serialization;
using Assignment03.Utility;

namespace Assignment03Tests
{
    public static class Serialization
    {
        public static void SerializeUsers(SLL users, string fileName)
        {
            var serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        public static SLL DeserializeUsers(string fileName)
        {
            var serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL)serializer.ReadObject(stream);
            }
        }
    }
}
