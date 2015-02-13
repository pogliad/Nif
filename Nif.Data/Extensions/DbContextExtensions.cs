using System;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using Nif.Core.Extensions;

namespace Nif.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static DateTime SqlServerGetDate(this DbContext dbContext)
        {
            Contract.Requires<ArgumentNullException>(dbContext.IsNotNull());

            var dateTime = dbContext.Database
                .SqlQuery<DateTime>("SELECT GETDATE()")
                .Single();

            return dateTime;
        }
    }
}