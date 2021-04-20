using Camguard.Business.IContract;
using Skylight.DAL;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight.Business.Service
{
    public class CompanyPolicyService : ICompanyPolicyService
    {
        private readonly UnitOfWork _unitOfWork;

        public CompanyPolicyService()
        {
        }

        public CompanyPolicyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CompanyPolicy> GetAll(int CompanyID)
        {
            var data = _unitOfWork.CompanyPolicyRepository.Get().ToList();
            return data;
        }

        public CompanyPolicy GetByID(string ID)
        {
            var data = _unitOfWork.CompanyPolicyRepository.Get(a => a.CompanyPolicyID == ID).FirstOrDefault();
            return data;
        }


        public List<CompanyPolicy> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.CompanyPolicyRepository.Get(a => a.CompanyPolicyName == keyword || a.Description == keyword).ToList();
            return data;
        }




        public int GetActiveCount()
        {
            int data = _unitOfWork.CompanyPolicyRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.CompanyPolicyRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.CompanyPolicyRepository.Get().Count();
            return data;
        }

        public List<CompanyPolicy> Active()
        {
            var data = _unitOfWork.CompanyPolicyRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<CompanyPolicy> InActive()
        {
            var data = _unitOfWork.CompanyPolicyRepository.Get(a => a.Discontinued == true).ToList();
            return data;
        }



        public async Task<(bool status, string message)> Update(CompanyPolicy model)
        {
            string message = "";
            try
            {
                _unitOfWork.CompanyPolicyRepository.Update(model);
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

        public async Task<(bool status, string message)> AddAsync(CompanyPolicy model)
        {
            string message = "";
            try
            {

                _unitOfWork.CompanyPolicyRepository.Insert(model);
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

        public async Task<(bool status, string message)> AddBulkAsync(List<CompanyPolicy> model)
        {
            string message = "";
            foreach (var item in model)
            {
                try
                {
                    _unitOfWork.CompanyPolicyRepository.Insert(item);
                    await _unitOfWork.SaveAsync();
                    message = $"{message}\n {item.CompanyPolicyID} Inserted successfully";
                }
                catch (Exception ex)
                {
                    message = $"ID: {item.CompanyPolicyID}Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                    return (false, message);
                }
            }
            return (true, message);

        }


    }
}
