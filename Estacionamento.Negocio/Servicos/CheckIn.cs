using System;

namespace Estacionamento.Negocio
{
    public class CheckIn : ICommand
    {
        private const int VAGAS_TOTAIS = 15;
        /// <summary>
        /// Registra a entrada de um carro no estacionamento.
        /// </summary>
        public double Run(object placa)
        {
            Validar(placa);
            Dados.Estacionamento.Add(CarroDto.Novo(placa.ToString()));
            return Double.MinValue;
        }

        /// <summary>
        /// Valida se a operação checkin pode ser realizada
        /// </summary>
        public bool Validar(object placa)
        {
            if (String.Equals(placa, string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (Dados.Estacionamento.Count == VAGAS_TOTAIS)
                throw new Exception("Estacionamento cheio!");

            if (Dados.Estacionamento.Exists(x => x.Placa.Equals(placa)))
                throw new Exception(String.Format("Carro placa '{0} já existe!", placa));

            return true;
        }
    }
}
