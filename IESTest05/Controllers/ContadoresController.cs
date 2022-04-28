﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Data;
using MobileLite.Entities;
using IESTest05.Entity;

namespace MobileLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadoresController : ControllerBase
    {
        private readonly DataContext context;

        public ContadoresController(DataContext context)
        {
            this.context = context;
        }

        // Out: Listado de todos los contadores
        [HttpGet] // GET: api/contadores
        public IEnumerable<Contadores> Get()
        {
            try
            {
                return context.Contadores.ToList();
            }
            catch
            {
                return null;
            }

        }

        // In: Id de contador | Out: Contador correspondiente
        [HttpGet("{id}")] // GET api/contadores/5
        public Contadores Get(String id)
        {
            try
            {
                return context.Contadores.FirstOrDefault(c => c.Codigo.ToString() == id);
            }
            catch
            {
                return null;
            }

        }
    }
}
