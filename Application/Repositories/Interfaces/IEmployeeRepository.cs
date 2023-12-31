﻿using Domain.Entities;

namespace Application.Repositories.Interfaces;

public interface IEmployeeRepository
{
    /// <summary>
    /// This method is responsible to get all employee from Blazor data base.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<EmployeeEntity>> GetAllEmployees();


    /// <summary>
    /// This method is responsible to get employee by id from Blazor data base.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<EmployeeEntity> GetEmployeeById(int id);


    /// <summary>
    /// This method is responsible to to update existing employee.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employee"></param>
    /// <returns></returns>
    Task<bool> UpdateEmployee(int id, EmployeeEntity employee);


    /// <summary>
    /// This method is responsible to Delete existing employee.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteEmployee(int id);


    /// <summary>
    /// This method is responsible to add new employee.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    Task<bool> CreateNewEmployee(EmployeeEntity employee);
}
