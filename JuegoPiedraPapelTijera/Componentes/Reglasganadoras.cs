using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPiedraPapelTijera.Componentes
{
    public class Reglasganadoras
    {
        private readonly IList<(int, int, bool, bool, string)> reglasganadoras =
            new List<(int, int, bool, bool, string)>
            {
                (0,0, false, false, "Ambos seleccionaron Piedra, Es empate"),
                (0,1, false, true, "Papel vence a la Piedra, Perdiste"),
                (0,2, true, false, "Piedra vence a la tijera, Ganaste"),
                (1,0, true, false, "Papel vence a la piedra, Ganaste"),
                (1,1, false, false, "Ambos eligieron Papel, Es empate"),
                (1,2, false, true, "Tijera vence Papel, Perdiste"),
                (2,0, false, true, "Piedra vence tijera, Perdiste"),
                (2,1, true, false, "Tijera vence papel, Ganaste"),
                (2,2, false, false, "Ambos eligieron Tijera, Es empate")
            };

        public(int, int, bool, bool, string) this[int opcionjugador, int opcioncompu]
            =>reglasganadoras.Single(w => w.Item1 == opcionjugador && w.Item2 == opcioncompu);
    }
}
