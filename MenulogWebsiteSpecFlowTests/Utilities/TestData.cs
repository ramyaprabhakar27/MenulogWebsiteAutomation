using System.Collections.Generic;
using System.Linq;

namespace MenulogWebsiteSpecFlowTests.Utilities
{
    public static class TestData
    {        
        private static string data = "Westmead,Harris Park,Parramatta,Ajana,Albany,Aldersyde,Alexander Heights";

        public static List<string> GetTestData()
        {
            return (data.Split(',').ToList());
        }
    }
}
