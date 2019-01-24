using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class CardRepository : IRepository<Card>
    {
        private ApplicationDbContext context;
        private DbSet<Card> table;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public CardRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Cards;
        }

        public void Create(Card t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new Card { Id = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public Card Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Card> GetAll()
        {
            return table;
        }

        public Task<Card> GetAsync(int id)
        {
            return context.Cards.FindAsync(id);
        }

        public void Update(Card t)
        {
            var author = context.Cards
                             .AsNoTracking()
                             .Where(ct => ct.Id == t.Id)
                             .FirstOrDefault();
            context.Entry<Card>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
