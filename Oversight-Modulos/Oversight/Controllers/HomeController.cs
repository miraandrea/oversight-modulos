using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oversight.Models;
using Oversight.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Oversight.Controllers
{
    public class HomeController : Controller
    {
        BD bD = new BD();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Rutas

        public List<CAdministradores> getAdministradores()
        {
            List<CAdministradores> listaAdministradores = new List<CAdministradores>();

            CAdministradores administrador = new CAdministradores();

            administrador.nombres = "Paola Andrea";
            administrador.apellidos = "Mira";
            administrador.documento = 1007603423;

            listaAdministradores.Add(administrador);
            return listaAdministradores;
        }
        public List<CProfesores> getProfesores()
        {
            List<CProfesores> listaProfesores = new List<CProfesores>();

            CProfesores profesor = new CProfesores();

            profesor.nombres = "Elian";
            profesor.apellidos = "Jaramillo Rojas";
            profesor.documento = 1007603426;

            listaProfesores.Add(profesor);
            return listaProfesores;
        }

        public List<CEstudiantes> getEstudiantes()
        {
            List<CEstudiantes> listaEstudiantes = new List<CEstudiantes>();
            CEstudiantes estudiante = new CEstudiantes();

            estudiante.nombres = "Bryan Steven";
            estudiante.apellidos = "Osorio Zuleta";
            estudiante.documento = 1005133888;

            listaEstudiantes.Add(estudiante);
            return listaEstudiantes;
        }

        // Vista
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //insertar estudiantes
        public string InsertarEstudiantes([FromBody] CEstudiantes model)
        {
            string sql = "INSERT INTO estudiantes (documento, nombre, apellido) values( " + model.documento + ", '" + model.nombres + "', '" + model.apellidos + "' );";

            string resultado = bD.ejecutarSQL(sql);

            return resultado;
        }

        //insertar profesores
        public string InsertarProfesores([FromBody] CProfesores model)
        {
            string sql = "INSERT INTO profesores (documento, nombre, apellido) values( " + model.documento + ", '" + model.nombres + "', '" + model.apellidos + "' );";

            string resultado = bD.ejecutarSQL(sql);

            return resultado;
        }

        //mostrar un estudiante

        public List<CEstudiantes> MostrarUnEstudiante(int documento)

        {
            List<CEstudiantes> listaEstudiantes = new List<CEstudiantes>();

            DataTable dataTable = bD.ejecutarSQL1($"select * from estudiantes where documento = {documento}");

            listaEstudiantes = (from DataRow datos in dataTable.Rows
                                select new CEstudiantes()
                                {
                                    documento = Convert.ToInt32(datos["documento"]),
                                    nombres = Convert.ToString(datos["nombre"]),
                                    apellidos = Convert.ToString(datos["apellido"])
                                }).ToList();

            return listaEstudiantes;
        }

        //mostrar estudiantes

        public List<CEstudiantes> MostrarEstudiantes()

        {
            List<CEstudiantes> listaEstudiantes = new List<CEstudiantes>();

            DataTable dataTable = bD.ejecutarSQL1($"select * from estudiantes");

            listaEstudiantes = (from DataRow datos in dataTable.Rows
                            select new CEstudiantes()
                            {
                                documento = Convert.ToInt32(datos["documento"]),
                                nombres = Convert.ToString(datos["nombre"]),
                                apellidos = Convert.ToString(datos["apellido"])
                            }).ToList();

            return listaEstudiantes;
        }

        //mostrar profesores

        public List<CProfesores> MostrarProfesores()

        {
            List<CProfesores> listaProfesores = new List<CProfesores>();

            DataTable dataTable = bD.ejecutarSQL1($"select * from profesores");

            listaProfesores = (from DataRow datos in dataTable.Rows
                                select new CProfesores()
                                {
                                    documento = Convert.ToInt32(datos["documento"]),
                                    nombres = Convert.ToString(datos["nombre"]),
                                    apellidos = Convert.ToString(datos["apellido"])
                                }).ToList();

            return listaProfesores;
        }

        //mostrar administradores
        public List<CAdministradores> MostrarAdministradore()

        {
            List<CAdministradores> listaAdministradores = new List<CAdministradores>();

            DataTable dataTable = bD.ejecutarSQL1($"select * from administradores");

            listaAdministradores = (from DataRow datos in dataTable.Rows
                               select new CAdministradores()
                               {
                                   documento = Convert.ToInt32(datos["documento"]),
                                   nombres = Convert.ToString(datos["nombre"]),
                                   apellidos = Convert.ToString(datos["apellido"])
                               }).ToList();

            return listaAdministradores;
        }
    }
}
