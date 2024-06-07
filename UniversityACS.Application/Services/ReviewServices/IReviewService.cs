using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<Review> AddReviewAsync(Review review);
        Task<List<ReviewResponseDto>> GetReviewsByStudentIdAsync(Guid studentId);
        Task<List<ReviewResponseDto>> GetReviewsByTeacherIdAsync(Guid teacherId);
    }
}
