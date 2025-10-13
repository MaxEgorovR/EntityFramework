using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework1.Entities;
using EntityFramework1.Repositories;

namespace EntityFramework1.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(OnlineСoursesContext db)
        {
            _reviewRepository = new ReviewRepository(db);
        }

        public async Task AddAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var rev = _reviewRepository.GetByIdAsync(review.Id);

            if (rev != null)
            {
                throw new Exception($"Отзыв с идентификатором {review.Id} уже существует");
            }

            await _reviewRepository.AddAsync(review);
        }

        public async Task RemoveAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var rev = _reviewRepository.GetByIdAsync(review.Id);

            if (rev == null)
            {
                throw new Exception($"Отзыва с идентификатором {review.Id} не существует");
            }

            await _reviewRepository.DeleteAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var rev = _reviewRepository.GetByIdAsync(review.Id);

            if (rev == null)
            {
                throw new Exception($"Отзыва с идентификатором {review.Id} не существует");
            }

            await _reviewRepository.UpdateAsync(review);
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"Идентификатор отзыва не может быть '{id}'");
            }

            var review = await _reviewRepository.GetByIdAsync(id);

            if (review == null)
            {
                throw new ArgumentNullException($"Идентификатора отзыва {id} не существует");
            }

            return review;
        }
    }
}
