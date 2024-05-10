using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Contracts;
using RecordManagement.Application.DTOs;
using RecordManagement.Domain.Entities;
using RecordManagement.Infrastructure.Data;

namespace RecordManagement.Infrastructure.Implementations;

public class EmployeeRepo : IEmployee
{
    private readonly AppDbContext appDbContext;
    public EmployeeRepo(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<ServiceResponse> AddAsync(Employee employee)
    {
        appDbContext.Employees.Add(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Add user sucessfully");
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var employee = await appDbContext.Employees.FindAsync(id);
        if (employee == null)
            return new ServiceResponse(false, "No user found");

        appDbContext.Employees.Remove(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Deleted user successfully");

    }

    public async Task<List<Employee>> GetAsync() => await appDbContext.Employees.AsNoTracking().ToListAsync();

    public async Task<Employee?> GetByIdAsync(int id) => await appDbContext.Employees.FindAsync(id);

    public async Task<ServiceResponse> UpdateAsync(Employee employee)
    {
        appDbContext.Update(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Successfully updated");
    }

    private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
}