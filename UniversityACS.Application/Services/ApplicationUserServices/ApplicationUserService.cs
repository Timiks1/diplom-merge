using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ApplicationUserServices;

public class ApplicationUserService : IApplicationUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<CreateResponseDto<ApplicationUserResponseDto>> CreateAsync(ApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.UserName == dto.UserName, cancellationToken);

        if (existingUser != null)
        {
            return new CreateResponseDto<ApplicationUserResponseDto>()
            {
                Success = false,
                ErrorMessage = "User with the same username already exists."
            };
        }

        if (dto.Password == null)
        {
            return new CreateResponseDto<ApplicationUserResponseDto>()
            {
                Success = false, 
                ErrorMessage = "Password is required."
            };
        }
        
        var hasher = new PasswordHasher<ApplicationUser>();
        
        var newUser = dto.ToEntity();
        newUser.PasswordHash = hasher.HashPassword(newUser, dto.Password);

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<ApplicationUserResponseDto>()
        {
            Success = true, 
            Item = newUser.ToDto(), 
            Id = newUser.Id
        };
    }

    public async Task<UpdateResponseDto<ApplicationUserResponseDto>> UpdateAsync(Guid id, ApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingUser == null)
        {
            return new UpdateResponseDto<ApplicationUserResponseDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }
        
        existingUser.UpdateEntity(dto);
        _context.ApplicationUsers.Update(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ApplicationUserResponseDto>()
        {
            Success = true,
            Item = existingUser.ToDto(),
            Id = existingUser.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (existingUser == null)
        {
            return new UpdateResponseDto<ApplicationUserDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }
        
        _context.ApplicationUsers.Remove(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ApplicationUserResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (existingUser == null)
        {
            return new DetailsResponseDto<ApplicationUserResponseDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }

        return new DetailsResponseDto<ApplicationUserResponseDto>()
        {
            Item = existingUser.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<ApplicationUserResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _context.ApplicationUsers.ToListAsync(cancellationToken);

        return new ListResponseDto<ApplicationUserResponseDto>()
        {
            Items = users.Select(u => u.ToDto()).ToList(),
            TotalCount = users.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<ApplicationUserResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var users = await _context.ApplicationUsers
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ApplicationUserResponseDto>()
        {
            Items = users.Select(u => u.ToDto()).ToList(),
            TotalCount = users.Count,
            Success = true
        };
    }

    public async Task<ResponseDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == changePasswordDto.UserId, cancellationToken);

        if (existingUser == null)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "User not found" };
        }
        
        var hasher = new PasswordHasher<ApplicationUser>();
        var passwordVerificationResult =
            hasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, changePasswordDto.OldPass);

        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "Invalid old password" };
        }

        existingUser.PasswordHash = hasher.HashPassword(existingUser, changePasswordDto.NewPass);
        _context.ApplicationUsers.Update(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<ResponseDto> UpdateUserRolesAsync(UpdateUserRolesDto requestDto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == requestDto.UserId, cancellationToken);

        if (existingUser == null)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "User not found" };
        }

        if (requestDto.Roles == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Need to send roles"
            };
        }
        
        var userRoles = await _context.IdentityUserRoles
            .Where(x => x.UserId == requestDto.UserId)
            .ToListAsync(cancellationToken);

        _context.IdentityUserRoles.RemoveRange(userRoles);

        foreach (var roleName in requestDto.Roles)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == roleName.ToLower(),
                cancellationToken);
            if (role == null) continue;
            var userRole = new IdentityUserRole<Guid>
            {
                RoleId = role.Id,
                UserId = existingUser.Id
            };
            _context.IdentityUserRoles.Add(userRole);
        }
        
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto()
        {
            Success = true
        };
    }
}