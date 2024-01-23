using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowMagical.Business.Dtos;
using WowMagical.Business.Services;
using WowMagical.Business.Types;
using WowMagical.Data.Entities;
using WowMagical.Data.Enums;
using WowMagical.Data.Repositories;

namespace WowMagical.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly IDataProtector _dataProtector;
        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider, IRepository<CategoryEntity> categoryRepository)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
            _categoryRepository = categoryRepository;


        }

        public bool AddGift(AddGiftDto addGiftDto)
        {
            {
                var hasCategory = _categoryRepository.GetAll(x => x.Name.ToLower() == addGiftDto.Name.ToLower()).ToList();

                if (hasCategory.Any())
                {
                    return false;

                }

                var entity = new CategoryEntity()
                {
                    Name = addGiftDto.Name,
                    Description = addGiftDto.Description
                };

                _categoryRepository.Add(entity);
                return true;

            }
        }

        ServiceMessage IUserService.AddUser(AddUserDto addUserDto)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == addUserDto.Email.ToLower()).ToList();

            if (hasMail.Any())
            {
                return new ServiceMessage()
                {
                    IsSucceed = false,
                    Message = "Bu Eposta adresli bir kullanıcı zaten mevcut."
                };
            }


            var entity = new UserEntity()
            {
                Email = addUserDto.Email,
                FirstName = addUserDto.FirstName,
                LastName = addUserDto.LastName,
                Password = _dataProtector.Protect(addUserDto.Password),
                UserType = UserTypeEnum.User
            };

            _userRepository.Add(entity);

            return new ServiceMessage
            {
                IsSucceed = true
            };

        }

       

        UserInfoDto IUserService.LoginUser(LoginDto loginDto)
        {
            var userEntity = _userRepository.Get(x => x.Email == loginDto.Email);

            if (userEntity is null)
            {
                return null;
            }

            var rawPassword = _dataProtector.Unprotect(userEntity.Password);

            if (rawPassword == loginDto.Password)
            {
                return new UserInfoDto()
                {
                    Id = userEntity.Id,
                    Email = userEntity.Email,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    UserType = userEntity.UserType
                };
            }
            else
            {
                return null;
            }

        }
    }
    }

