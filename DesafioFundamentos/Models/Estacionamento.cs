using DesafioFundamentos.Interfaces;

namespace DesafioFundamentos.Models
{
    public class Estacionamento: IEstacionamento
    {
        private decimal _precoInicial { get; set; }
        private decimal _precoPorHora { get; set; }

        private List<string> _veiculos { get; set; }

        public Estacionamento(decimal precoInicial,  decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
            _veiculos = new List<string>();
        }
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            _veiculos.Add(placa.ToUpper());
            Console.WriteLine($"Veículo com placa {placa} estacionado.");
        }

        public void ListarVeiculos()
        {
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();


            if (_veiculos.Any(veiculo => veiculo == placa))
            {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = _precoInicial + _precoPorHora * horas;
                    _veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

        }
    }
}
