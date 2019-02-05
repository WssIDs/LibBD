using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class TestBaseRepository : IRepository<TestBase>
    {
        private ApplicationDbContext context;
        private DbSet<TestBase> table;

        public TestBaseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.TestAuths;
        }

        public void Create(TestBase t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new TestBase { Id = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<TestBase> Find(Func<TestBase, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public TestBase Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<TestBase> GetAll()
        {
            return table;
        }

        public Task<TestBase> GetAsync(int id)
        {
            return context.TestAuths.FindAsync(id);
        }

        public void Update(TestBase t)
        {
            var author = context.TestAuths
                             .AsNoTracking()
                             .Where(ct => ct.Id == t.Id)
                             .FirstOrDefault();
            context.Entry<TestBase>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
