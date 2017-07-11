using System;

namespace Estacionamento.Negocio
{
    public class CheckOut : ICommand
    {
        /// <summary>
        /// Registra a saída de um carro do estacionamento.
        /// </summary>
        public double Run(object placa)
        {
            Validar(placa);
            CarroDto _carro = Dados.Estacionamento.Find(x => x.Placa.Equals(placa));
            _carro.HoraSaida = DateTime.Now;
            Dados.Estacionamento.RemoveAll(x => x.Placa.Equals(placa));

            return CalcularValorEstacionamento(_carro);
        }

        /// <summary>
        /// Valida se a operação de checkout pode ser realizada
        /// </summary>
        public bool Validar(object placa)
        {
            if (String.Equals(placa.ToString(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (!Dados.Estacionamento.Exists(x => x.Placa.Equals(placa)))
                throw new Exception(String.Format("Carro com a placa '{0}' NÃO existe!", placa));

            return true;
        }

        /// <summary>
        /// Calcula o valor com base no tempo de permanência
        /// </summary>
        public static double CalcularValorEstacionamento(CarroDto carro)
        {
            var permanencia = carro.HoraSaida.Value.Subtract(carro.HoraEntrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo
        }
    }
}
