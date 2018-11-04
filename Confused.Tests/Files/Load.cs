using System.IO;
using System.Reflection;

namespace Confused.Tests.Files
{
    public static class Load
    {
        public static string ResourceFileContent(string fileName, string fileNamespace)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Confused.Tests." + fileNamespace + "." + fileName;

            string resource;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    resource = reader.ReadToEnd();
                }
            }

            return resource;
        }
    }
}