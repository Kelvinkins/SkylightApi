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
    public class CompanyService : ICompanyService
    {
        private readonly UnitOfWork _unitOfWork;

        public CompanyService()
        {
        }

        public CompanyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Company> GetAll()
        {
            var data = _unitOfWork.CompanyRepository.Get().ToList();
            return data;
        }

        public Company GetByID(int CompanyID)
        {
            var data = _unitOfWork.CompanyRepository.Get(a => a.CompanyID == CompanyID).FirstOrDefault();
            return data;
        }


        public List<Company> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.CompanyRepository.Get(a => a.CompanyName == keyword || a.Description == keyword).ToList();
            return data;
        }




        public int GetActiveCount()
        {
            int data = _unitOfWork.CompanyRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.CompanyRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.CompanyRepository.Get().Count();
            return data;
        }

        public List<Company> Active()
        {
            var data = _unitOfWork.CompanyRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<Company> InActive()
        {
            var data = _unitOfWork.CompanyRepository.Get(a => a.Discontinued == true).ToList();
            return data;
        }



        public async Task<(bool status, string message)> Update(Company model)
        {
            string message = "";
            try
            {
                _unitOfWork.CompanyRepository.Update(model);
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

        public async Task<(bool status, string message)> AddAsync(Company model)
        {
            string message = "";
            try
            {

                _unitOfWork.CompanyRepository.Insert(model);
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

        public async Task<(bool status, string message)> AddBulkAsync(List<Company> model)
        {
            string message = "";
            foreach (var item in model)
            {
                try
                {
                    _unitOfWork.CompanyRepository.Insert(item);
                    await _unitOfWork.SaveAsync();
                    message = $"{message}\n {item.CompanyID} Inserted successfully";
                }
                catch (Exception ex)
                {
                    message = $"ID: {item.CompanyID}Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                    return (false, message);
                }
            }
            return (true, message);

        }

    }
}

