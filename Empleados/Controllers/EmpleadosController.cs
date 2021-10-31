using Empleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

namespace Empleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly BDEmpleadosContext _context;
        public EmpleadosController(BDEmpleadosContext context)
        {
            _context = context;
        }

        //Http Get Index
        /// <summary>
        /// Metodo para mostrar el formulario 
        /// </summary>
        public IActionResult Index()
        {
            IEnumerable<Empleado> listEmpleados = _context.Empleados;
            return View(listEmpleados);
        }
        /// <summary>
        /// Metodo para crear un registro 
        /// </summary>
        
        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.TelefonoEmpleado = FormatearTelefono(empleado.TelefonoEmpleado);
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                TempData["mensaje"] = "El empleado se ha creado correctamente"; //Mensaje que saldra cuando se ha  guardado un registro 
                return RedirectToAction("Index");
            }
            return View();
        }
        public string FormatearTelefono (string telefono)
        {
            return "(" + telefono.Substring(0, 3) + ") "+ telefono.Substring(3,3)+"-"+ telefono.Substring(6,4);
        }
        //Http Get edit

        public IActionResult Edit( int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //obtener la lista  de  empleados 
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        //Http post  edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            //Validacion del modelo empleado

            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                _context.SaveChanges();
                TempData["mensaje"] = "El empleado se ha actualizado correctamente"; //Mensaje que saldra cuando se ha  actualizado un registro 
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener la lista  de  empleados 
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmpleado(int? Idempleado)
        {
            var empleado = _context.Empleados.Find(Idempleado);
         
                if (empleado == null)
            {
                return NotFound();
            }
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();


                TempData["mensaje"] = "El empleado se ha eliminado correctamente"; //Mensaje que saldra cuando se ha  actualizado un registro 
                return RedirectToAction("Index");
            
          
        }

        }
    }

