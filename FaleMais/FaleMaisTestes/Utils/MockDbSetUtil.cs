using Moq;
using Microsoft.EntityFrameworkCore;

namespace FaleMaisTestes.Utils
{
    internal static class MockDbSetUtil
    {
        public static Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> listEntity) where T : class, new()
        {
            var queryableList = listEntity.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(_ => _.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(_ => _.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(_ => _.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(_ => _.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
            return dbSetMock;
        }
    }
}
