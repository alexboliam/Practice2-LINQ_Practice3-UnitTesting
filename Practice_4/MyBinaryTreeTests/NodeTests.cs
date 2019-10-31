using System;
using Xunit;
using MyBinaryTree;
using System.Collections;

namespace MyBinaryTreeTests
{
    
    public class NodeTests
    {
        [Fact]
        public void Node_CreateObject_ObjectIsNotNull()
        {
            //Arrange
            Node<int> node = null;
            //Act
            node = new Node<int>();
            //Assert
            Assert.NotNull(node);
        }

        [Fact]
        public void Node_CreateObjectWithValue_ObjectWithCorrectValue()
        {
            //Arrange
            Node<int> node = null;
            int value = 5;
            //Act
            node = new Node<int>(value);
            //Assert
            Assert.Equal(value, node.Data);
        }

        [Fact]
        public void GetEnumerator_GetEnumeratorForNode_EnumeratorIsNotNull()
        {
            //Arrange
            Node<int> node = new Node<int>(5);
            node.Left = new Node<int>(2);
            node.Right = new Node<int>(10);
            //Act
            var enumer = node.GetEnumerator();
            //Assert
            Assert.NotNull(enumer);
        }

        [Fact]
        public void GetEnumerator_GetNonGenericEnumeratorForNode_NonGenericEnumeratorIsNotNull()
        {
            //Arrange
            Node<int> node = new Node<int>();
            //Act
            IEnumerator result = ((IEnumerable)node).GetEnumerator();
            //Assert
            Assert.NotNull(result);
        }
    }
}
