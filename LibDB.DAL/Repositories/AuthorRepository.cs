using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class AuthorRepository : IRepository<Author>
    {
        private ApplicationDbContext context;
        private DbSet<Author> table;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public AuthorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Authors;
        }

        public void Create(Author t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new Author { AuthorId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public Author Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return table;
        }

        public Task<Author> GetAsync(int id)
        {
            return context.Authors.FindAsync(id);
        }

        public void Update(Author t)
        {
            var author = context.Authors
                             .AsNoTracking()
                             .Where(ct => ct.AuthorId == t.AuthorId)
                             .FirstOrDefault();
            context.Entry<Author>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
