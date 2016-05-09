using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //THE PARAMETER TYPEMESSAGE IS 1 (MESSAGE)
        //<add key="TypeMessage" value="1" /><!--message :  1-->
        [TestMethod]
        public void TestMethod1()
        {
            bool bLogToDatabase = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToDatabase"]);
            bool bLogToFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToFile"]);
            bool bLogToConsole = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToConsole"]);
            TypeMessage typemessage = getTypeMessage(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TypeMessage"]));

            JobLoggerFixed target = new JobLoggerFixed(bLogToFile,bLogToConsole,bLogToDatabase,typemessage); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual = string.Empty; // TODO: Initialize to an appropriate value
            JobLoggerFixed.LogMessage("This is a text for message", TypeMessage.message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify: it must log the message if the parameter TypeMessage is TypeMessage.message");
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool bLogToDatabase = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToDatabase"]);
            bool bLogToFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToFile"]);
            bool bLogToConsole = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToConsole"]);
            TypeMessage typemessage = getTypeMessage(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TypeMessage"]));

            JobLoggerFixed target = new JobLoggerFixed(bLogToFile, bLogToConsole, bLogToDatabase, typemessage); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual = string.Empty; // TODO: Initialize to an appropriate value
            JobLoggerFixed.LogMessage("This is a text for warning", TypeMessage.warning);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify: it must log the message if the parameter TypeMessage is TypeMessage.warning");
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool bLogToDatabase = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToDatabase"]);
            bool bLogToFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToFile"]);
            bool bLogToConsole = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogToConsole"]);
            TypeMessage typemessage = getTypeMessage(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TypeMessage"]));

            JobLoggerFixed target = new JobLoggerFixed(bLogToFile, bLogToConsole, bLogToDatabase, typemessage); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual = string.Empty; // TODO: Initialize to an appropriate value
            JobLoggerFixed.LogMessage("This is a text for error", TypeMessage.error);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify: it must log the message if the parameter TypeMessage is TypeMessage.error");
        }


        private static TypeMessage getTypeMessage(int iTypeMessage)
        {
            switch (iTypeMessage)
            {
                case (int)TypeMessage.error:
                    return TypeMessage.error;
                case (int)TypeMessage.warning:
                    return TypeMessage.error;
                case (int)TypeMessage.message:
                    return TypeMessage.error;
             }
            return TypeMessage.error;
        }
    }
}
