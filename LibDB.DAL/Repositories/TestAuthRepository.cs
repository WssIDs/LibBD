using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class TestAuthRepository : IRepository<TestAuth>
    {
        private ApplicationDbContext context;
        private DbSet<TestAuth> table;

        public TestAuthRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.TestAuths;
        }

        public void Create(TestAuth t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new TestAuth { Id = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<TestAuth> Find(Func<TestAuth, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public TestAuth Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<TestAuth> GetAll()
        {
            return table.Include(c => c.Cards);
        }

        public Task<TestAuth> GetAsync(int id)
        {
            return context.TestAuths.FindAsync(id);
        }

        public void Update(TestAuth t)
        {
            var author = context.TestAuths
                             .AsNoTracking()
                             .Where(ct => ct.Id == t.Id)
                             .FirstOrDefault();
            context.Entry<TestAuth>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
