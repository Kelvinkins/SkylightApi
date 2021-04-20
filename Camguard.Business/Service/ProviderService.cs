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
    public class ProviderService : IProviderService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProviderService()
        {
        }

        public ProviderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Provider> GetAll()
        {
            var data = _unitOfWork.ProviderRepository.Get().ToList();
            return data;
        }

        public Provider GetByID(int ProviderID)
        {
            var data = _unitOfWork.ProviderRepository.Get(a => a.ProviderID == ProviderID).FirstOrDefault();
            return data;
        }


        public List<Provider> GetBySearchTerm(string keyword)
        {
            var data = _unitOfWork.ProviderRepository.Get(a => a.ProviderName == keyword || a.ProviderName.Contains(keyword)).ToList();
            return data;
        }




        public int GetActiveCount()
        {
            int data = _unitOfWork.ProviderRepository.Get(a => a.Discontinued == false).Count();
            return data;
        }


        public int GetInActiveCount()
        {
            int data = _unitOfWork.ProviderRepository.Get(a => a.Discontinued == true).Count();
            return data;
        }

        public int GetAllCount()
        {
            int data = _unitOfWork.ProviderRepository.Get().Count();
            return data;
        }

        public List<Provider> Active()
        {
            var data = _unitOfWork.ProviderRepository.Get(a => a.Discontinued == false).ToList();
            return data;
        }

        public List<Provider> InActive()
        {
            var data = _unitOfWork.ProviderRepository.Get(a => a.Discontinued == true).ToList();
            return data;
        }



        public async Task<(bool status, string message)> Update(Provider model)
        {
            string message = "";
            try
            {
                _unitOfWork.ProviderRepository.Update(model);
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

        public async Task<(bool status, string message)> AddAsync(Provider model)
        {
            string message = "";
            try
            {

                _unitOfWork.ProviderRepository.Insert(model);
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

        public async Task<(bool status, string message)> AddBulkAsync(List<Provider> model)
        {
            string message = "";
            foreach (var item in model)
            {
                try
                {
                    _unitOfWork.ProviderRepository.Insert(item);
                    await _unitOfWork.SaveAsync();
                    message = $"{message}\n {item.ProviderID} Inserted successfully";
                }
                catch (Exception ex)
                {
                    message = $"ID: {item.ProviderID}Error has occured. Error message: {ex.Message}\nInner Exception:{ex.InnerException.Message}";
                    return (false, message);
                }
            }
            return (true, message);

        }

    }
}

