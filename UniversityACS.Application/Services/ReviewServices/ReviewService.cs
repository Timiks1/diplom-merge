using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs.Responses;
using System.Xml.Linq;
namespace UniversityACS.Application.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<ReviewResponseDto>> GetReviewsByStudentIdAsync(Guid studentId)
        {
            var elements = await _context.Reviews.Where(r => r.StudentId == studentId).ToListAsync();
            List<ReviewResponseDto> result = new List<ReviewResponseDto>();
            foreach (var element in elements)
            {
                result.Add(new ReviewResponseDto()
                {
                    Id = element.Id,
                    Comment = element.Comment,
                    Discipline = element.Discipline,
                    Date = element.Date,
                    Student = _context.Student.Where(x => x.Id == element.StudentId).FirstOrDefault(),
                    Teacher = _context.ApplicationUsers.Where(x => x.Id == element.TeacherId).FirstOrDefault(),
                });
            }
            return result;
        }

        public async Task<List<ReviewResponseDto>> GetReviewsByTeacherIdAsync(Guid teacherId)
        {
            var elements = await _context.Reviews.Where(r => r.TeacherId == teacherId).ToListAsync();
            List<ReviewResponseDto> result = new List<ReviewResponseDto>();
            foreach (var element in elements)
            {
                result.Add(new ReviewResponseDto()
                {
                    Id = element.Id,
                    Comment = element.Comment,
                    Discipline = element.Discipline,
                    Date = element.Date,
                    Student = _context.Student.Where(x => x.Id == element.StudentId).FirstOrDefault(),
                    Teacher = _context.ApplicationUsers.Where(x => x.Id == element.TeacherId).FirstOrDefault(),
                });
            }
            return result;
        }
    }
}
