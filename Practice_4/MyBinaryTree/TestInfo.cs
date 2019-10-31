using System;
using System.Collections.Generic;
using System.Text;

namespace MyBinaryTree
{
    public class TestInfo : IComparable<TestInfo>
    {
        private float mark;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string TestName { get; set; }
        public string DatePass { get; set; }
        public float Mark {
            get { return this.mark; }
            set
            {
                if (value < 0) throw new ArgumentException("Mark cannot be negative number");
                this.mark = value;
            }
        }

        public override string ToString()
        {
            return SecondName + ":" + Mark.ToString();
        }
        public TestInfo() 
        {
            this.SecondName = default;
            this.FirstName = default;
            this.TestName = default;
            this.DatePass = default;
            this.Mark = default;
        }
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
