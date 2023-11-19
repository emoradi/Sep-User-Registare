using SEP.User.Registare.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Service.Services.Users.Contracts
{
    public interface IZaerService
    {
        ZaerDTO Create(ZaerDTO zaerDTO);
        ZaerDTO Update(ZaerDTO zaerDTO);
        void Delete(ZaerDTO zaerDTO);
        ZaerDTO Get(ZaerDTO zaerDTO);
    }
}
