using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowMagical.Business.Dtos;
using WowMagical.Business.Types;

namespace WowMagical.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(AddUserDto addUserDto);

        UserInfoDto LoginUser(LoginDto loginDto);
        bool AddGift(AddGiftDto addGiftDto);
    }
}
