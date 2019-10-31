using System;
using Xunit;
using MyArray;

namespace MyArrayTests
{
    public class MyArrayTests
    {
        [Fact]
        public void GetEnumerator_GetEnumeratorForMyArray_EnumeratorIsNotNull()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(0, 10);
            //Act
            var enumer = array.GetEnumerator();
            //Assert
            Assert.NotNull(enumer);
        }

        [Theory]
        [InlineData(10, 5, 4, 3, 2, -10)]
        [InlineData(10, 5, 4, 3, 2, -5)]
        [InlineData(10, 5, 4, 3, 2, 5)]
        public void Indexator_GetValueByIndex_GetCorrectValue(int i1, int i2, int i3, int i4, int i5, int lower)
        {
            //Arrange
            int[] temp = new int[5] { i1, i2, i3, i4, i5 };
            MyArray<int> array = new MyArray<int>(temp, lower);      
            //Act
            var res1 = array[lower];
            var res2 = array[lower + array.Capacity -1];
            //Assert
            Assert.Equal(i1, res1);
            Assert.Equal(i5, res2);
        }
        [Fact]
        public void Indexator_SetValueByIndex_SetCorrectValue()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(-10, 5);
            //Act
            array[-10] = 5;
            array[-6] = 1;
            //Assert
            Assert.Equal(5, array[-10]);
            Assert.Equal(1, array[-6]);
        }

        [Fact]
        public void Indexator_SetValueByIndex_IfIndexIncorrectThrowIndexOutOfRangeException()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(-10, 5);
            //Act
            Action action = () => { array[-11] = 5; };
            //Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }
        [Fact]
        public void Indexator_GetValueByIndex_IfIndexIncorrectThrowIndexOutOfRangeException()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(-10, 5);
            int res = 0;
            //Act
            Action action = () => { res = array[-3]; };
            //Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void CopyTo_CopyDataToAnotherMyArray_DataIsSame()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(new int[3] { 1, 2, 3 });
            MyArray<int> temp = new MyArray<int>(0, 3);
            //Act
            array.CopyTo(temp);
            //Assert
            Assert.Equal(array, temp);
        }
        [Fact]
        public void CopyTo_CopyDataToAnotherMyArray_IfAnotherCapacityLowerThanThisThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(new int[3] { 1, 2, 3 });
            MyArray<int> temp = new MyArray<int>(0, 2);
            //Act
            Action action = () => { array.CopyTo(temp); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CopyTo_CopyDataToArray_DataIsSame()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(new int[3] { 1, 2, 3 });
            int[] temp = new int[3];
            //Act
            array.CopyTo(temp);
            //Assert
            Assert.Equal(array, temp);
        }
        [Fact]
        public void CopyTo_CopyDataToArray_IfAnotherLengthLowerThanMyCapacityThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = new MyArray<int>(new int[3] { 1, 2, 3 });
            int[] temp = new int[2];
            //Act
            Action action = () => { array.CopyTo(temp); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }


        [Fact]
        public void MyArray_CreateInstance_CreatedInstanceIsNotNullAndCapacityIsCorrect()
        {
            //Arrange
            MyArray<int> array = null;
            //Act
            array = new MyArray<int>(10, 5);
            //Assert
            Assert.NotNull(array);
            Assert.Equal(5, array.Capacity);
        }
        [Fact]
        public void MyArray_CreateInstanceFromArrayFromZeroIndex_CreatedInstanceHasSameData()
        {
            //Arrange
            MyArray<int> array = null;
            int[] temp = new int[5] { 1, 2, 3, 4, 5 };
            //Act
            array = new MyArray<int>(temp);
            //Assert
            Assert.Equal(temp, array);
        }
        [Fact]
        public void MyArray_CreateInstanceFromArrayFromCustomIndex_CreatedInstanceHasSameDataStartingFromIndex()
        {
            //Arrange
            MyArray<int> array = null;
            int[] temp = new int[5] { 1, 2, 3, 4, 5 };
            //Act
            array = new MyArray<int>(temp, -10);
            //Assert
            Assert.Equal(temp, array);
        }
        [Fact]
        public void MyArray_CreateInstanceFromAnotherMyArray_CreatedInstanceHasSameDataStartingFromSameIndex()
        {
            //Arrange
            MyArray<int> array = null;
            MyArray<int> temp = new MyArray<int>(new int[5] { 1, 2, 3, 4, 5 }, -5);
            //Act
            array = new MyArray<int>(temp);
            //Assert
            Assert.Equal(temp, array);
            Assert.Equal(temp.LowerBound, array.LowerBound);
        }
        
        [Fact]
        public void MyArray_CreateInstanceWithIndexAndCapacity_IfCapacityLowerThan1ThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = null;
            //Act
            Action action = () => { array = new MyArray<int>(10, 0); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }
        [Fact]
        public void MyArray_CreateInstanceFromArray_IfNullLengthOfArrayLowerThan1ThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = null;
            int[] temp = new int[0];
            //Act
            Action action = () => { array = new MyArray<int>(temp); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }
        [Fact]
        public void MyArray_CreateInstanceFromArrayAndCustomIndex_IfNullLengthOfArrayLowerThan1ThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = null;
            int[] temp = null;
            //Act
            Action action = () => { array = new MyArray<int>(temp, -5); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }
        [Fact]
        public void MyArray_CreateInstanceFromAnotherMyArray_IfNullOrCapacityLowerThan1ThrowArgumentException()
        {
            //Arrange
            MyArray<int> array = null;
            MyArray<int> temp = null;
            //Act
            Action action = () => { array = new MyArray<int>(temp); };
            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
