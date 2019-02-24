using dotnet_code_challenge.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dotnet_code_challenge.Infrastructure
{
    public static class ReaderFactory
    {
        public static IFileReader CreateFileReader(string fileName)
        {
            var extension = GetFileExtension(fileName);
            switch (extension)
            {
                case "xml":
                    return new XmlReader();
                case "json":
                    return new JsonReader();
                default:
                    throw new NotSupportedException();
            }
        }

        public static string GetFileExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return extension.Substring(1, extension.Length - 1);
        }
    }
}
