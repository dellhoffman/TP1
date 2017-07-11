using System.Collections.Generic;

namespace Estacionamento.Negocio
{

    public class Dados
    {
        private static List<CarroDto> _estacionamento = new List<CarroDto>();

        public static List<CarroDto> Estacionamento
        {
            get { return _estacionamento; }
            set { _estacionamento = value; }
        }
    }
}
