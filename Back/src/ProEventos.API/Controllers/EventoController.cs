﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.src.ProEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                    EventoId = 1,
                    Tema = "Angular e DotNet5",
                    Local = "BH",
                    Lote = "Primeiro Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemUrl = "Photo.png"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular e DotNet5 e suas funcionalidades",
                    Local = "RJ",
                    Lote = "Segundo Lote",
                    QtdPessoas = 300,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemUrl = "Photo(2).png"
                }
        };
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }


        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Exemplo de put com id = " + id;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Exemplo de delete com id = " + id;
        }


    }
}