using System;
using System.Collections.Generic;
using System.Text;

namespace MyCodeBase.Library.ViewModels.Test
{
    public class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<TestList> TestLists { get; set; }
        public TestMajor TestMajor { get; set; }
    }

    public class TestMajor
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class TestList
    {
        public string Subject { get; set; }
        public int Score { get; set; } 
    }
}
