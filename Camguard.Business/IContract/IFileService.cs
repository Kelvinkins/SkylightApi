using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camguard.Business.IContract
{
   public interface IFileService
    {
        public byte[] CreatePdf(List<Capitation> data);

    }
}
