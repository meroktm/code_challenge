using dotnet_code_challenge.Application;
using System;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class ReaderFactoryTests
    {
        [Fact]
        public void Return_Extension()
        {
            //Arrange
            var fileName = "test.xml";

            //Act
            var getExtension = Infrastructure.ReaderFactory.GetFileExtension(fileName);

            //Assert
            getExtension.Equals(".xml");
        }

        [Fact]
        public void Return_Xml_Reader_Interface()
        {
            //Arrange
            var fileName = "test.xml";

            //Act
            var getReader = Infrastructure.ReaderFactory.CreateFileReader(fileName);

            //Assert
            getReader.GetType().IsInterface.Equals(true);
        }

        [Fact]
        public void Return_Json_Reader_Interface()
        {
            //Arrange
            var fileName = "test.json";

            //Act
            var getReader = Infrastructure.ReaderFactory.CreateFileReader(fileName);

            //Assert
            getReader.GetType().IsInterface.Equals(true);
        }

        [Fact]
        public void Return_Not_Supported_Exception()
        {
            //Arrange
            var fileName = "test.jsonn";

            //Act
            Action action = () => Infrastructure.ReaderFactory.CreateFileReader(fileName);
           
            //Assert
            Assert.Throws<NotSupportedException>(action);            
        }
    }
}
