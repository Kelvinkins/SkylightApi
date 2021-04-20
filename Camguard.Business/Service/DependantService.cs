using Camguard.Business.IContract;
using Skylight.DAL;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.Service
{
    public class DependantService : IDependantService
    {
        private readonly UnitOfWork _unitOfWork;

        public DependantService()
        {
        }

        public DependantService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Dependant> GetAll(int EmployeeID)
        {
            var data = _unitOfWork.DependantRepository.Get(a=>a.EmployeeID==EmployeeID).ToList();
            return data;
        }

        public Dependant GetByID(string ID)
        {
            var data = _unitOfWork.DependantRepository.Get(a => a.DependantID == ID).FirstOrDefault();
            return data;
        }


        public List<Dependant> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.DependantRepository.Get(a => a.Surname == keyword || a.OtherName == keyword).ToList();
            return data;
        }




        public int GetActiveCount()
        {
            int data = _unitOfWork.DependantRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.DependantRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.DependantRepository.Get().Count();
            return data;
        }

        public List<Dependant> Active()
        {
            var data = _unitOfWork.DependantRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<Dependant> InActive()
        {
            var data = _unitOfWork.DependantRepository.Get(a => a.Discontinued == true).ToList();
            return data;
        }



        public async Task<(bool status, string message)> Update(Dependant model)
        {
            string message = "";
            try
            {
                _unitOfWork.DependantRepository.Update(model);
                await _unitOfWork.SaveAsync();
                message = "The terminal has been successfully updated";
                return (true, message);

            }
            catch (Exception ex)
            {
                message = $"Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                return (true, message);
            }

        }

        public async Task<(bool status, string message)> AddAsync(Dependant model)
        {
            string message = "";
            try
            {

                _unitOfWork.DependantRepository.Insert(model);
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

        public async Task<(bool status, string message)> AddBulkAsync(List<Dependant> model)
        {
            string message = "";
            foreach (var item in model)
            {
                try
                {
                    _unitOfWork.DependantRepository.Insert(item);
                    await _unitOfWork.SaveAsync();
                    message = $"{message}\n {item.DependantID} Inserted successfully";
                }
                catch (Exception ex)
                {
                    message = $"ID: {item.DependantID}Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                    return (false, message);
                }
            }
            return (true, message);

        }

    }
}

