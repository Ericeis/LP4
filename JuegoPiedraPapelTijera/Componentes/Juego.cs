using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace JuegoPiedraPapelTijera.Componentes
{
    public partial class Juego
    {
        private int puntosjugador;
        private int puntoscomputador;
        private string opcionjugadorimagen;
        private string opcioncomputadorimagen;
        private string mensaje;

        private readonly Action<int> opcionjugadorhecha;
        private readonly Action<int> opcioncompuhecha;
        private readonly Action<int, int> ambasopcioneshechas;

        private readonly Random rand;

        public Juego()
        {
            rand = new Random();

            opcionjugadorhecha = (opcionjugador) =>
             {
                 opcionjugadorimagen = opciones[opcionjugador];
                 opcioncompuhecha(opcionjugador);
             };

            opcioncompuhecha = (opcionjugador) => 
            {
                var opcioncompu = rand.Next(2);
                opcioncomputadorimagen = opciones[opcioncompu];
                StateHasChanged();

                ambasopcioneshechas(opcionjugador, opcioncompu);
            };

            ambasopcioneshechas = (opcionjugador, opcioncompu) => 
            {
                var (_,_, jugadorgana, computadorgana, mensaje) = Reglasganadoras[opcionjugador, opcioncompu];
                this.mensaje = mensaje;
                puntosjugador = jugadorgana ? ++puntosjugador : puntosjugador;
                puntoscomputador = computadorgana ? ++puntoscomputador : puntoscomputador;

                StateHasChanged();
            };
        }

        protected override void OnInitialized() => SetDefaultMessage();

        private void SetDefaultMessage() => mensaje = "Elige una opción";
        private void JugadorEleccion(int opcionjugador) => opcionjugadorhecha(opcionjugador);

        private void Reiniciar()
        {
            SetDefaultMessage();
            puntosjugador = puntoscomputador = 0;
            opcionjugadorimagen = opcioncomputadorimagen = string.Empty;
        }

        [Inject]
        public Reglasganadoras Reglasganadoras { get; set; }
    }
}
