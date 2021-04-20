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
    public class PolicyService : IPolicyService
    {
        private readonly UnitOfWork _unitOfWork;

        public PolicyService()
        {
        }

        public PolicyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Policy> GetAll()
        {
            var data = _unitOfWork.PolicyRepository.Get().ToList();
            return data;
        }

        public Policy GetByID(string ID)
        {
            var data = _unitOfWork.PolicyRepository.Get(a => a.PolicyID == ID).FirstOrDefault();
            return data;
        }


        public List<Policy> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.PolicyRepository.Get(a => a.PolicyName == keyword || a.Description == keyword).ToList();
            return data;
        }




        public int GetActiveCount()
        {
            int data = _unitOfWork.PolicyRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.PolicyRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.PolicyRepository.Get().Count();
            return data;
        }

        public List<Policy> Active()
        {
            var data = _unitOfWork.PolicyRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<Policy> InActive()
        {
            var data = _unitOfWork.PolicyRepository.Get(a => a.Discontinued == true).ToList();
            return data;
        }



        public async Task<(bool status, string message)> Update(Policy model)
        {
            string message = "";
            try
            {
                _unitOfWork.PolicyRepository.Update(model);
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

        public async Task<(bool status, string message)> AddAsync(Policy model)
        {
            string message = "";
            try
            {

                _unitOfWork.PolicyRepository.Insert(model);
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

        public async Task<(bool status, string message)> AddBulkAsync(List<Policy> model)
        {
            string message = "";
            foreach (var item in model)
            {
                try
                {
                    _unitOfWork.PolicyRepository.Insert(item);
                    await _unitOfWork.SaveAsync();
                    message = $"{message}\n {item.PolicyID} Inserted successfully";
                }
                catch (Exception ex)
                {
                    message = $"ID: {item.PolicyID}Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                    return (false, message);
                }
            }
            return (true, message);

        }

    }
}
