using RecordManagement.Application.DTOs;
using RecordManagement.Domain.Entities;

namespace RecordManagement.Application.Contracts;

public interface IEmployee
{
    Task<ServiceResponse> AddAsync(Employee employee);
    Task<ServiceResponse> UpdateAsync(Employee employee);
    Task<ServiceResponse> DeleteAsync(int id);
    Task<List<Employee>> GetAsync();
    Task<Employee> GetByIdAsync(int id);

}