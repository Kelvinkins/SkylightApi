using Camguard.Business.IContract;
using RandomSolutions;
using Skylight.Data.ViewModel;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camguard.Business.Service
{
   public class FileService:IFileService
    {
        public byte[] CreatePdf(List<Capitation> data)
        {

            var list = new List<ListViewModel>();
            foreach (var cap in data)
            {
                var li = new ListViewModel();
                li.Code = cap.EnrolleeCode;
                li.Surname = cap.Surname;
                li.OtherName = cap.OtherName;
                li.EnrolleeType = cap.EnrolleeType.ToString();
                li.DOB = Convert.ToDateTime(cap.DateOfBirth).ToShortDateString();

                list.Add(li);
            }

            byte[] pdf = list.ToPdf();
            return pdf;

        }
    }
}
