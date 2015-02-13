using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nif.Core;
using Nif.Data.Exceptions;
using Nif.Extensions;

namespace Nif.Data.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        protected readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            Contract.Requires<ArgumentNullException>(context.IsNotNull());

            _context = context;
        }

        public virtual async Task CommitAsync(DateTime lastModifyDateTime)
        {
            try
            {
                var changeSet = _context.ChangeTracker.Entries<EntityBase<long>>();

                if (changeSet.IsNotNull())
                {
                    foreach (var entry in changeSet.Where(c => c.State == EntityState.Added))
                    {
                        var propertyCreateDateTimeName = entry.Entity.GetMemberName(entity => entity.CreateDateTime);
                        entry.Entity.SetPropertyValue(propertyCreateDateTimeName, lastModifyDateTime);
                        entry.Entity.LastModifyDateTime = lastModifyDateTime;
                    }

                    foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                    {
                        var createdDateTime = entry.Entity.CreateDateTime;

                        if (lastModifyDateTime <= createdDateTime)
                        {
                            entry.Entity.LastModifyDateTime = lastModifyDateTime;
                        }
                        else
                        {
                            throw new EntityLastModifyDateTimeIsLessThanCreateDateTimeException(string.Format("Entity <{0}> last modify date time <{1}> is less than create date time <{2}>.",
                                entry.Entity.Id,
                                lastModifyDateTime,
                                entry.Entity.CreateDateTime));
                        }

                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException exception)
            {
                var message = new StringBuilder();
                foreach (var errors in exception.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                    {
                        message.AppendLine(
                        string.Format("Validation failed for entity while saving changes to database. Details: Class: <{0}>, Property: <{1}>, Error: <{2}>", errors.Entry.Entity.GetType().FullName, error.PropertyName, error.ErrorMessage));
                    }
                }

                throw new DbEntitiesValidationsException(message.ToString());
            }
        }

        protected override void DisposeManagedResources()
        {
            if (_context.IsNotNull())
                _context.Dispose();
        }
    }
}