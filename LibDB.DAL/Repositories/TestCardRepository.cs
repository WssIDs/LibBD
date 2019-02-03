using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class TestCardRepository : IRepository<TestCard>
    {
        private ApplicationDbContext context;
        private DbSet<TestCard> table;

        public TestCardRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.TestCards;
        }

        public void Create(TestCard t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new TestCard { Id = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<TestCard> Find(Func<TestCard, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public TestCard Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<TestCard> GetAll()
        {
            return table.Include(a=>a.Auth);
        }

        public Task<TestCard> GetAsync(int id)
        {
            return context.TestCards.FindAsync(id);
        }

        public void Update(TestCard t)
        {
            var author = context.TestCards
                             .AsNoTracking()
                             .Where(ct => ct.Id == t.Id)
                             .FirstOrDefault();
            context.Entry<TestCard>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
