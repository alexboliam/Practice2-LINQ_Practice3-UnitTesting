using System;
using System.Collections.Generic;
using System.Text;

namespace MyBinaryTree
{
    public class TestInfo : IComparable<TestInfo>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string TestName { get; set; }
        public string DatePass { get; set; }
        public float Mark { get; set; }

        public override string ToString()
        {
            return SecondName + ":" + Mark.ToString();
        }
        public TestInfo() { }
        public TestInfo(string SecondName, string FirstName, string TestName, string DatePass, float Mark = 0)
        {
            this.SecondName = SecondName;
            this.FirstName = FirstName;
            this.TestName = TestName;
            this.DatePass = DatePass;
            this.Mark = Mark;
        }
        public int CompareTo(TestInfo other)
        {
            if (Mark == other.Mark)
            {
                return 0;
            }
            else if (Mark > other.Mark)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
