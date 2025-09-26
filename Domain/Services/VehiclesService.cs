using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class VehiclesService : IVehicleService
    {
        private readonly DatabaseContext _Context;
        public VehiclesService(DatabaseContext context)
        {
            _Context = context;
        }

        public void Delete(Vehicles V)
        {
            _Context.Vehicles.Remove(V);
            _Context.SaveChanges();
            //o _context é como se fosse um refnum do banco de dados via ORM
        }

        public void Update(Vehicles V)
        {
            _Context.Vehicles.Update(V);
            _Context.SaveChanges();
        }

        public Vehicles? FindById(int id)
        {
            return _Context.Vehicles.Where(v => v.Id == id).FirstOrDefault();
        }
        public void Include(Vehicles V)
        {
            _Context.Vehicles.Add(V);
            _Context.SaveChanges();
        }

        public List<Vehicles>? ListAll(int page = 1, string? name = null, string? vendor = null)
        {
            var query = _Context.Vehicles.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                //nesse caso um nome foi informado.
                query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{name.ToLower()}%"));
            }

            int ItensPerPage = 10;

            query = query.Skip((page-1)*ItensPerPage).Take(ItensPerPage); //paginação dos resultados.

            return query.ToList();
        }
    }
}