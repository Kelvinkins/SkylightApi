using Camguard.Business.IContract;
using Camguard.Data.DAL;
using Skylight.DAL;
using Skylight.Data.ViewModel;
using Skylight.Mapping;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public EmployeeService()
        {
        }

        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            mapper = new Mapper();

        }

        public List<Employee> GetAll()
        {
            var data = _unitOfWork.EmployeeRepository.Get().ToList();
            return data;
        }

        public Employee GetByID(int ID)
        {
            var data = _unitOfWork.EmployeeRepository.Get(a => a.EmployeeID == ID).FirstOrDefault();
            return data;
        }


        public List<Employee> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.EmployeeRepository.Get(a => a.Surname == keyword || a.Surname == keyword).ToList();
            return data;
        }


     

        public int GetActiveCount()
        {
            int data = _unitOfWork.EmployeeRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.EmployeeRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.EmployeeRepository.Get().Count();
            return data;
        }

        public List<Employee> Active()
        {
            var data = _unitOfWork.EmployeeRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<Employee> InActive()
        {
            var data = _unitOfWork.EmployeeRepository.Get(a=>a.Discontinued==true).ToList();
            return data;
        }

   

        public async Task<(bool status, string message)> Update(Employee model)
        {
            string message = "";
            try
            {
                _unitOfWork.EmployeeRepository.Update(model);
                await  _unitOfWork.SaveAsync();
                message = "The terminal has been successfully updated";
                return (true, message);

            }
            catch (Exception ex)
            {
                message =$"Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                return (true, message);
            }

        }

        public async Task<(bool status, string message)> AddAsync(Employee model)
        {
            string message = "";
            try
            {

                _unitOfWork.EmployeeRepository.Insert(model);
                await _unitOfWork.SaveAsync();
                message = "Record Inserted successfully";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                return (false, message);
            }

        }

        public async Task<(bool status, string message)> AddBulkAsync(List<EmployeeViewModel> employees, List<DependantViewModel> dependants)
        {
            string errorMessage = "";
            int successCount = 0;
            int failureCount = 0;
            string message = "";
            foreach (var principal in employees)
            {

                try
                {
                    var tempDependants = dependants.Where(a => a.EmployeeID == principal.ID).ToList();
                    var employee = mapper.EmployeeFromViewModel(principal);
                    _unitOfWork.EmployeeRepository.Insert(employee);
                    await _unitOfWork.SaveAsync();
                    if (string.IsNullOrEmpty(employee.OldID))
                    {

                        employee.OldID = $"HA/{employee.RegionID}/{employee.CompanyID}/{employee.EmployeeID}";
                        _unitOfWork.EmployeeRepository.Update(employee);
                        await _unitOfWork.SaveAsync();
                    }


                    foreach (var dep in tempDependants)
                    {
                        var dependant = mapper.DependantFromViewModel(dep);
                        var Dependants = _unitOfWork.DependantRepository.Get(a => a.EmployeeID == employee.EmployeeID).ToList();
                        dependant.EmployeeID = employee.EmployeeID;
                        dependant.CompanyID = employee.CompanyID;
                        dependant.DependantID = employee.EmployeeID + "." + Dependants.Count() + "." + (int)dependant.Relationship;
                        dependant.OldID = $"{employee.OldID}/{dependant.Letter}";
                        _unitOfWork.DependantRepository.Insert(dependant);
                        await _unitOfWork.SaveAsync();
                        //Dependants saved successfully
                    }
                    successCount = successCount + 1;
                }
                catch (Exception ex)
                {
                    failureCount = failureCount + 1;
                    errorMessage = $"Main Exception: {ex.Message} \nInner Exception: {ex.InnerException.Message}";
                }


            }
            message = $"{message}  \nSuccessful: {successCount} ";
            message = $"{message}  \nFailed: {failureCount} ";
            message = $"{message} \nError Message Encountered: {errorMessage}";
            return (true, message);


        }

    }
}
