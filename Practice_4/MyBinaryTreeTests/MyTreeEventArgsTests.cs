using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyBinaryTree;

namespace MyBinaryTreeTests
{
    public class MyTreeEventArgsTests
    {
        [Fact]
        public void MyTreeEventArgs_CreateInstance_InstanceIsNotNull()
        {
            //Arrange
            MyTreeEventArgs<string> args = null;
            //Act
            args = new MyTreeEventArgs<string>();
            //Assert
            Assert.NotNull(args);
        }

        [Fact]
         public void MyTreeEventArgs_CreateInstanceWithValue_ValueInInstanceIsCorrect()
         {
            //Arrange
            MyTreeEventArgs<string> args = null;
            string value = "sample";
            //Act
            args = new MyTreeEventArgs<string>(value);
            //Assert
            Assert.Equal(value, args.Value);
         }
        
    }
}
