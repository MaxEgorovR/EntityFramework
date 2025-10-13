using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;

namespace EntityFramework1.Repositories
{
    public class ReviewRepository
    {
        private readonly OnlineСoursesContext _db;
        public ReviewRepository(OnlineСoursesContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Review review)
        {
            _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Review review)
        {
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _db.Reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            var dish = await _db.Reviews.FindAsync(id);
            return dish;
        }
    }
}
