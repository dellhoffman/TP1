namespace Estacionamento.Negocio
{
    public interface ICommand
    {
        bool Validar(object placa);
        double Run(object placa);
    }
}
