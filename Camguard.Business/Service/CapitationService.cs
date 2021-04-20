using Camguard.Business.IContract;
using Skylight.DAL;
using Skylight.Data;
using Skylight.Data.Models;
using Skylight.Mapping;
using Skylight.Models;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.Service
{
    public class CapitationService : ICapitationService
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailService emailService;
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        public CapitationService()
        {
        }

        public CapitationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            emailService = new EmailService();
            mapper = new Mapper();
        }


        public async Task<(bool status, string message)> Process(CapitationMaster model)
        {
            string message = "";

            try
            {
                var Principals = _unitOfWork.EmployeeRepository.Get(a => a.PolicyID != null && a.Started == true && a.Discontinued == false, includeProperties: "Policy,Provider").ToList();
                var Dependants = _unitOfWork.DependantRepository.Get(a => a.PolicyID != null && a.Started == true && a.Discontinued == false, includeProperties: "Policy,Provider").ToList();
                //Harvesting principals
                try
                {
                    model.SystemDateTime = Glob.SkylightDateTime();
                    _unitOfWork.CapitationMasterRepository.Insert(model);
                    await _unitOfWork.SaveAsync();
                    foreach (var p in Principals)
                    {
                        try
                        {
                            var cap = new Capitation();
                            cap.EmployeeID = p.EmployeeID.ToString();
                            cap.EnrolleeCode = p.OldID;
                            cap.Surname = p.Surname;
                            cap.OtherName = p.OtherName;
                            cap.StaffID = p.StaffID;
                            cap.PolicyID = p.PolicyID;
                            cap.ProviderID = p.ProviderID;
                            cap.SystemDate = Glob.SkylightDateTime();
                            cap.EnrolleeType = EnrType.Principal;
                            cap.Gender = p.Gender;
                            cap.PhoneNumber = p.PhoneNumber;
                            cap.Amount = p.Policy.Amount;
                            cap.ServiceType = p.Provider.ProviderService;
                            cap.CompanyID = p.CompanyID;
                            cap.DateOfBirth = p.DateOfBirth;
                            cap.Email = p.Email;
                            cap.MainDate = model.DueDate;
                            cap.CapitationMasterID = model.CapitationMasterID;
                            _unitOfWork.CapitationRepository.Insert(cap);
                            await _unitOfWork.SaveAsync();
                            message = message + " \n Successful for " + p.OldID;

                        }
                        catch (Exception ex)
                        {
                            message = message + "\n" + ex.Message;
                        }
                    }
                    //Harvesting dependants
                    foreach (var d in Dependants)
                    {
                        try
                        {
                            var cap = new Capitation();
                            cap.EmployeeID = d.EmployeeID.ToString();
                            cap.EnrolleeCode = d.OldID;
                            cap.Surname = d.Surname;
                            cap.OtherName = d.OtherName;
                            cap.StaffID = d.StaffID;
                            cap.PolicyID = d.PolicyID;
                            cap.ProviderID = (int)d.ProviderID;
                            cap.SystemDate = Glob.SkylightDateTime();
                            cap.EnrolleeType = EnrType.Dependant;
                            cap.Gender = d.Gender;
                            cap.PhoneNumber = d.PhoneNumber;
                            cap.Amount = d.Policy.Amount;
                            cap.ServiceType = d.Provider.ProviderService;
                            cap.CompanyID = d.Employee.CompanyID;
                            cap.DateOfBirth = d.DateOfBirth;
                            cap.Email = d.Email;
                            cap.MainDate = model.DueDate;
                            cap.CapitationMasterID = model.CapitationMasterID;
                            _unitOfWork.CapitationRepository.Insert(cap);
                            await _unitOfWork.SaveAsync();
                            message = message + " \n Successful for " + d.OldID;
                            message = $"{message}\n {d.EmployeeID.ToString()} Inserted successfully";


                        }
                        catch (Exception ex)
                        {
                            message = message + "\n" + ex.Message;

                        }
                    }
                }
                catch (Exception ex)
                {
                    return (false, message);
                }


            }
            catch (Exception ex)
            {

            }
            return (true, message);

        }


        public async Task<(bool status, ServiceResponse message)> PublishCapitation()
        {
            string log = "";
            ServiceResponse response = new ServiceResponse();

            var cap = _unitOfWork.CapitationMasterRepository.Get(a => a.Published == true && a.Finished != true).OrderByDescending(a => a.CapitationMasterID).FirstOrDefault();
            var filteredCapitations = new List<Capitation>();
            if (cap != null)
            {
                log = log + "\n Monthly list sending started Time: " + Glob.SkylightDateTime();
                filteredCapitations = _unitOfWork.CapitationRepository.Get(a => a.CapitationMasterID == cap.CapitationMasterID && a.Sent != true).ToList();
                log = log + $"\n Total list = {filteredCapitations.Count()}" + Glob.SkylightDateTime();



                var providers = _unitOfWork.ProviderRepository.Get(a => a.Discontinued == false).ToList();
                log = log + $"\n Total Providers = {providers.Count()}" + Glob.SkylightDateTime();

                foreach (var p in providers)
                {
                    var capList = filteredCapitations.Where(a => a.ProviderID == p.ProviderID && a.ServiceType == SerType.Prepaid).ToList();
                    var ffsList = filteredCapitations.Where(a => a.ProviderID == p.ProviderID && a.ServiceType == SerType.FFS).ToList();
                    if (capList.Count() != 0)
                    {

                        var capFile = fileService.CreatePdf(capList);
                        try
                        {
                            await emailService.SendMail(_unitOfWork, $"Capitation for the month of {capList.FirstOrDefault().SystemDate.ToString("MMM") } {capList.FirstOrDefault().SystemDate.Year}", p.ProviderID.ToString(), "Find attached capitation list", Module.Capitation, capFile, $"Capitation{capList.FirstOrDefault().SystemDate.ToString("MMM") }_{capList.FirstOrDefault().SystemDate.Year}");
                            log = log + $"\n Successfully sent Capitation list to  {p.ProviderName}" + Glob.SkylightDateTime();
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "Sent", "1");
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "DateSent", Glob.SkylightDateTime().ToString());

                        }
                        catch (Exception ex)
                        {
                            log = log + $"\n failed sending Capitation list to  {p.ProviderName}" + Glob.SkylightDateTime();
                            log = log + $"\n Error Message {ex.Message}" + Glob.SkylightDateTime();
                            log = log + $"\n Inner Exception Message {ex.InnerException.Message}" + Glob.SkylightDateTime();
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "Sent", "0");
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "DateSent", Glob.SkylightDateTime().ToString());


                        }
                    }

                    if (ffsList.Count() != 0)
                    {
                        try
                        {
                            var ffsFile = fileService.CreatePdf(ffsList);
                            await emailService.SendMail(_unitOfWork, $"Fee For _unitOfWork for the month of {ffsList.FirstOrDefault().SystemDate.ToString("MMM") } {ffsList.FirstOrDefault().SystemDate.Year}", p.ProviderID.ToString(), "Find attached Fee For _unitOfWork list", Module.Capitation, ffsFile, $"FeeForService{ffsList.FirstOrDefault().SystemDate.ToString("MMM") }_{ffsList.FirstOrDefault().SystemDate.Year}");
                            log = log + $"\n Successfully sent Fee For _unitOfWork list to  {p.ProviderName}" + Glob.SkylightDateTime();
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "Sent", "1");
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "DateSent", Glob.SkylightDateTime().ToString());


                        }
                        catch (Exception ex)
                        {
                            log = log + $"\n failed sending Fee For _unitOfWork list to  {p.ProviderName}" + Glob.SkylightDateTime();
                            log = log + $"\n Error Message {ex.Message}" + Glob.SkylightDateTime();
                            log = log + $"\n Inner Exception Message {ex.InnerException.Message}" + Glob.SkylightDateTime();
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "Sent", "0");
                            await _unitOfWork.BulkUpdate("Capitations", "ProviderID", p.ProviderID.ToString(), "DateSent", Glob.SkylightDateTime().ToString());

                        }
                    }
                }

                await _unitOfWork.BulkUpdate("CapitationMasters", "CapitationMasterID", cap.CapitationMasterID.ToString(), "Finished", "1");
                response.ServiceID = "PublishCapitation";
                response.ServiceStatus = ServiceStatus.Successful;
                response.LastRun = Glob.SkylightDateTime();
                response.Log = log;
            }
            return (true, response);

        }

    }
}       
