﻿namespace UniversityACS.Core.DTOs.Requests;

public class ApplicationUserDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? DepartmentEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid? DepartmentId { get; set; }
}