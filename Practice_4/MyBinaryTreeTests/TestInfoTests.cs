using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyBinaryTree;

namespace MyBinaryTreeTests
{
    public class TestInfoTests
    {
        [Fact]
        public void TestInfo_CreateInstance_InstanceIsNotNull()
        {
            //Arrange
            TestInfo testInfo = null;
            //Act
            testInfo = new TestInfo();
            //Assert
            Assert.NotNull(testInfo);
        }

        [Fact]
        public void TestInfo_CreateInstanceWithData_InstanceIncludesAllData()
        {
            //Arrange
            TestInfo testInfo = null;
            string secondName = "SECONDNAME", firstName = "FIRSTNAME";
            string testName = "TESTNAME", datePass = "DATEPASS";
            float mark = 100f;
            List<string> exp = new List<string>() { secondName, firstName, testName, datePass, mark.ToString() };
            //Act
            testInfo = new TestInfo(secondName, firstName, testName, datePass, mark);
            List<string> res = new List<string>() { testInfo.SecondName, testInfo.FirstName, testInfo.TestName, testInfo.DatePass, testInfo.Mark.ToString()};
            //Assert
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestInfo_SetMarkToInstance_IfMarkIsNegativeCatchException()
        {
            //Arrange
            TestInfo info = new TestInfo();
            //Act
            Action act = () => { info.Mark = -5; };
            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ToString_ReturnStringForInstance_StringIsCorrect()
        {
            //Arrange
            TestInfo testInfo = new TestInfo();
            testInfo.SecondName = "SecondName";
            testInfo.Mark = 100f;
            //Act
            var result = testInfo.ToString();
            //Assert
            Assert.Equal("SecondName:100", result);
        }

        [Theory]
        [InlineData(100f,50f,1)]
        [InlineData(20f, 25f, -1)]
        [InlineData(50f, 50f, 0)]
        public void CompareTo_CompareTwoTestInfos_FirstInfoIsBiggerThanSecond(float firstMark, float secondMark, float exp)
        {
            //Arrange
            TestInfo testInfo = new TestInfo();
            testInfo.Mark = firstMark;
            TestInfo testInfo2 = new TestInfo();
            testInfo2.Mark = secondMark;
            //Act
            var result = testInfo.CompareTo(testInfo2);
            //Assert
            Assert.Equal(exp, result);
        }

    }
}
