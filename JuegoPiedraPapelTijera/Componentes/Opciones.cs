using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPiedraPapelTijera.Componentes
{
    public class Opciones
    {
        private readonly Dictionary<int, string> opciones = 
            new Dictionary<int, string>
            {
                {0,"✊" }, 
                {1,"✋" },
                {2,"✌️" }
            };
        public string this [int choiceKey] => opciones [choiceKey];
    }
}
