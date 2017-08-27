using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ServiceWithIoC.Repository
{
    public class TestRepository : ITestRepository
    {
        public Expression Expression => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IQueryable Get()
        {
            List<string> arrayObject = new List<string>();
            arrayObject.Add("test1");
            arrayObject.Add("test2");

            return arrayObject.AsQueryable();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}