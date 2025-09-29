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

        public Administrator Include(Administrator administrator)
        {
            _Context.Administrators.Add(administrator);
            _Context.SaveChanges();

            return administrator;
        }

        public List<Administrator> ListAll(int? page)
        {
            var query = _Context.Administrators.AsQueryable();

            int ItensPerPage = 10;
            if (page != null)
            {
                query = query.Skip(((int)page - 1) * ItensPerPage).Take(ItensPerPage); //paginação dos resultados.   
            }


            return query.ToList();
        }

        public Administrator? FindById(int Id)
        {
            return _Context.Administrators.Where(v => v.Id == Id).FirstOrDefault();
        }
    }
}