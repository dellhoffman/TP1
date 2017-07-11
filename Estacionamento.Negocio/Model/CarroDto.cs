using System;

namespace Estacionamento.Negocio
{
    public class CarroDto
    {
        public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }

        public static CarroDto Novo(string placa)
        {
            return new CarroDto { Placa = placa.ToString(), HoraEntrada = DateTime.Now };

        }
    }
}
