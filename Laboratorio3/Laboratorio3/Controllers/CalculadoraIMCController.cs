using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio3.Models;

namespace Laboratorio3.Controllers
{
    public class CalculadoraIMCController : Controller
    {
        Random random = new Random();
        // GET: CalculadoraIMC
        public ActionResult ResultadoIMC()
        {
            PersonaModel persona = new PersonaModel(1, "Cristiano Ronaldo", 84.0, 1.87);
            double IMC = persona.Peso / (persona.Estatura * persona.Estatura);
            ViewBag.IMC = IMC;
            ViewBag.persona = persona;
            return View();
        }

        public ActionResult ResultadosAleatoriosIMC()
        {
            PersonaModel[] personas;
            
            int size = 30;
            personas = new PersonaModel[size];
            double[] IMCVector = new double[size];
            double PesoTemporal = 0;
            double AlturaTemporal = 0;
            double IMCTemporal = 0;
            for(int i = 0; i<size; i++)
            {
                PesoTemporal = GetRandomNumber(20, 150);
                AlturaTemporal = GetRandomNumber(1, 2);
                IMCTemporal = PesoTemporal / (AlturaTemporal * AlturaTemporal);
                IMCVector[i] = IMCTemporal;
                personas[i] = new PersonaModel(i, "Bryan Umana", PesoTemporal, AlturaTemporal);
                //random.NextDouble() * (maximum - minimum) + minimum;
            }
            ViewBag.personas = personas;
            ViewBag.Imcs = IMCVector;

            return View();
        }
        public double GetRandomNumber(double minimum, double maximum)
        {
            
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

    }
}