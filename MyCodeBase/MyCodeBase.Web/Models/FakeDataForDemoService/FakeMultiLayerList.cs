using MyCodeBase.Library.ViewModels.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCodeBase.Web.Models.FakeDataForDemoService
{
    /// <summary>
    /// 假多層資料
    /// </summary>
    public class FakeMultiLayerList
    {
        public Test FakeListForBind()
        {
            var t = 0;
            var testLists = new List<TestList>();
            while (t < 10)
            {
                var testlist = new TestList()
                {
                    Subject = "test",
                    Score = 100
                };
                testLists.Add(testlist);
                t += 1;
            }
            var test = new TestMajor()
            {
                Name = "LKK",
                Age = 16
            };
            var testMajor = new List<TestMajor>();
            testMajor.Add(test);
            var data = new Test()
            {
                Name = "HHH",
                Age = 26,
                TestLists = testLists,
                TestMajor = testMajor
            };

            return data;
        }

    }
}