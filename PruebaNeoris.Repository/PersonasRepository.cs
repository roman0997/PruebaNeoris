﻿using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Repository
{
    public class PersonasRepository: IPersonasRepository
    {
        private readonly DataContext db;
        private readonly IConfiguration Configuration;

        public PersonasRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            this.db = new DataContext(optionBuilder.Options, configuration);
            Configuration = configuration;
        }

        public async Task<List<Personas>> GetPersonas()
        {
            try
            {
                return await this.db.Personas.ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public async Task<bool> AddPersona(Personas persona)
        {
            bool response;
            try
            {
                db.Add(persona);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> UpdatePersona(Personas persona)
        {
            bool response;
            try
            {
                db.Update(persona);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> DeletePersona(string identificacion)
        {
            bool response;
            try
            {
                Personas persona = db.Personas.Find(identificacion);
                db.Remove(persona);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }
    }
}
