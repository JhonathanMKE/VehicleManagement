using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;

namespace Domain.Services
{
    public class AdministratorService : IadministratorService
    {
        private readonly DatabaseContext _Context; 
        public AdministratorService(DatabaseContext context)
        {
            _Context = context;
        }
        public Administrator? Login(LoginDTO loginDTO)
        {
            var adm = _Context.Administrators.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
            return adm;
        }
    }
}