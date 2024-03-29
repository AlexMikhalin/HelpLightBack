﻿using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using User = HelpLight.Data.Models.User;
using AutoMapper;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HelpLightDbContext _HLDbContext;
        private readonly IVolunteerReporitory _volunteerReporitory;
        private readonly IOrganizationRepository _organizationRepository;

        public UserRepository(HelpLightDbContext _HLDbContext, IVolunteerReporitory _volunteerReporitory,
                              IOrganizationRepository _organizationRepository)
        {
            this._HLDbContext = _HLDbContext;
            this._volunteerReporitory = _volunteerReporitory;
            this._organizationRepository = _organizationRepository;
        }

        public void AddUser(Contracts.User user)
        {
            if (user == null)
            {
                throw new Exception("User is null");
            }

            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    user.PasswordHash = GetMd5Hash(md5Hash, user.PasswordHash);
                }

                var userEntity = Mapper.Map<Contracts.User, User>(user);
                _HLDbContext.Add(userEntity);
                SaveChanges();

                if (user.Role.ToLower() == "volunteer")
                {
                    AddNewUserKarma(user.Volunteer.IdVolunteer);
                }
            }
            catch
            {
                throw;
            }
        }

        private void AddNewUserKarma(Guid volunteerId)
        {
            try
            {
                var newUserKarma = new Data.Models.Karma(volunteerId);
                _HLDbContext.Add(newUserKarma);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Contracts.User GetUser(Guid userId)
        {
            try
            {
                var dbuser = _HLDbContext.Users
                                        .Where(u => u.IdUser == userId)
                                        .Include(u => u.Volunteer).ThenInclude(v => v.Skills)
                                        .Include(i => i.Volunteer).ThenInclude(t => t.Contacts)
                                        .Include(u => u.Organization)
                                        .FirstOrDefault();
                var info = Mapper.Map<Contracts.User>(dbuser);
                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsOrganization(Guid id)
        {
            throw new NotImplementedException();
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Guid LoginUser(LoginUser loginUser)
        {
            try
            {
                var dbuser = _HLDbContext.Users
                                        .Where(u => u.UserName == loginUser.UserName)
                                        .FirstOrDefault();

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, loginUser.Password);

                    if (VerifyMd5Hash(md5Hash, dbuser.PasswordHash, hash))
                    {
                        return dbuser.IdUser;
                    }
                    else
                    {
                        throw new Exception("Wrong password!");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _HLDbContext.SaveChanges();
        }
    }
}
