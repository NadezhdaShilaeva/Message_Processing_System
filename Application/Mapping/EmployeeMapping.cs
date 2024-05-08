using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class EmployeeMapping
    {
        public static EmployeeDto AsDto(this Employee employee)
        {
            return new EmployeeDto(employee.Id, employee.Name, employee.Accounts.Select(a => a.AsDto()).ToArray());
        }
    }
}