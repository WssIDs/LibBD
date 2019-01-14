using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDB.DAL
{
    public class OrganizationRepository : IRepository<Organization>
    {
        private ApplicationDbContext context;
        private DbSet<Organization> table;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public OrganizationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Organizations;
        }

        public void Create(Organization t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
            .Entry(new Organization { OrganizationId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Organization> Find(Func<Organization, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public Organization Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return table;
        }

        public Task<Organization> GetAsync(int id)
        {
            return context.Organizations.FindAsync(id);
        }

        public void Update(Organization t)
        {
            var author = context.Organizations
                             .AsNoTracking()
                             .Where(ct => ct.OrganizationId == t.OrganizationId)
                             .FirstOrDefault();
            context.Entry<Organization>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
