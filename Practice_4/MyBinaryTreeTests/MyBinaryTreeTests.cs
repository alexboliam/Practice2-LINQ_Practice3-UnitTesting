using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyBinaryTree;
using System.Collections;

namespace MyBinaryTreeTests
{
    public class MyBinaryTreeTests
    {
        [Fact]
        public void MyBinaryTree_CreateInstance_InstanceIsNotNull()
        {
            //Arrange
            MyBinaryTree<string> tree = null;
            //Act
            tree = new MyBinaryTree<string>();
            //Assert
            Assert.NotNull(tree);
        }

        [Theory]
        [InlineData(5,5,5)]
        [InlineData(5,3,3)]
        [InlineData(5, 8, 8)]
        public void Find_TryFindValue_IfValuePresentsReturnNotNull(int first, int second, int find)
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Insert(first);
            tree.Insert(second);
            //Act
            var res = tree.Find(find);
            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void Find_TryFindValue_IfTreeIsEmtyReturnNull()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            //Act
            var res = tree.Find(5);
            //Assert
            Assert.Null(res);
        }

        [Fact]
        public void Insert_InsertValueToRoot_TreeContainsValue()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            //Act
            tree.Insert(5);
            //Assert
            var res = tree.Find(5);
            Assert.NotNull(res);
        }
        
        [Theory]
        [InlineData("1")]
        [InlineData("8")]
        public void Insert_InsertValueToLeaves_TreeContainsNewValue(string value)
       {
           //Arrange
           MyBinaryTree<string> tree = new MyBinaryTree<string>();
           tree.Insert("5");
            //Act
            tree.Insert(value);
           //Assert
           var res = tree.Find(value);
           Assert.NotNull(res);
       }

        [Theory]
        [InlineData("4","2","1","3","6","5","8","7","9","4")]
        [InlineData("4","2","1","3","6","5","8","7","9","3")]
        [InlineData("4","2","1","3","6","5","8","7","9","1")]
        [InlineData("4","2","1","3","6","5","8","7","9","2")]
        [InlineData("4","2","1","3","6","5","8","7","9","6")]
        [InlineData("4","2","1","3","6","5","8","7","9","5")]
        [InlineData("4","2","1","3","6","5","8","7","9","9")]
        [InlineData("4","2","1","3","6","5","8","4.5","4.2","4.5")]
        [InlineData("4","2","1","3","6","5","8","4.5","4.2","4.2")]
        public void Remove_RemoveRootValue_NodeRemovedAndTreeGetsNewRoot(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string remove)
        {
            //Arrange
            MyBinaryTree<string> tree = new MyBinaryTree<string>();
            tree.Insert(s1);
            tree.Insert(s2);
            tree.Insert(s3);
            tree.Insert(s4);
            tree.Insert(s5);
            tree.Insert(s6);
            tree.Insert(s7);
            tree.Insert(s8);
            tree.Insert(s9);
            //Act
            tree.Remove(remove);
            //Assert
            var res = tree.Find(remove);
            Assert.Null(res);
            Assert.NotNull(tree.Root);
        }
        [Fact]
        public void Remove_RemoveRootValue_IfTreeIsEmptyDontThrowException()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            //Act
            tree.Remove(5);
            //Assert
            var res = tree.Find(5);
            Assert.Null(res);
        }
        [Fact]
        public void Remove_RemoveRootValue_IfTreeContainsOnlyRootItChangesToNull()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Insert(5);
            //Act
            tree.Remove(5);
            //Assert
            Assert.Null(tree.Root);
        }
        [Theory]
        [InlineData(5,10)]
        [InlineData(5, 1)]
        public void Remove_RemoveRootValue_IfOneFromRootNodeIsNullMoveRootToAnotherNode(int first, int second)
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Insert(first);
            tree.Insert(second);
            //Act
            tree.Remove(first);
            //Assert
            var res = tree.Root.Data;
            Assert.Equal(second, res);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6)]
        [InlineData(4, 1, 3, 6, 5, 4)]
        [InlineData(7, 8, 3, 4, 9, 5)]
        [InlineData(9, 8, 7, 6, 5, 4)]
        public void GetEnumerator_CopyTreeToListWithForEach_TreeAndListAreSimilarByValues(int i1, int i2, int i3, int i4, int i5, int i6)
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();

            List<int> l = new List<int>() { i1, i2, i3, i4, i5, i6 };
            foreach (var item in l)
            {
                tree.Insert(item);
            }
            l.Sort();
            List<int> res = new List<int>();
            //Act
            foreach (var item in tree)
            {
                res.Add(item);
            }
            //Assert
            Assert.Equal(l, res);
        }
        [Fact]
        public void GetEnumerator_GetEnumeratorFromForEach_IfTreeIsEmptySkipForEach()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            bool check = true;
            //Act
            foreach (var item in tree)
            {
                check = false;
            }
            //Assert
            Assert.True(check);
        }
        [Fact]
        public void GetEnumerator_GetNonGenericEnumeratorForTree_NonGenericEnumeratorIsNotNull()
        {
            //Arrange
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(1);
            //Act
            IEnumerator result = ((IEnumerable)tree).GetEnumerator();
            //Assert
            Assert.NotNull(result);
        }
    }
}
