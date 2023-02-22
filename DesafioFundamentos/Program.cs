using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            estacionamento.AdicionarVeiculo(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Veículo adicinado com sucesso!!!!");
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int horas = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            decimal tempoPermanencia = estacionamento.CalcularTempoPermanencia(placa, horas);
            if(tempoPermanencia > 0)
            {
                estacionamento.RemoverVeiculo(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {tempoPermanencia}");

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

            break;

        case "3":
            Console.Clear();
            List<string> veiculos = estacionamento.ListarVeiculos();
            if (veiculos == null)
            {
                Console.WriteLine("Não há veículos estacionados.");
                break;
            }

            Console.WriteLine("Os veículos estacionados são:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Console.WriteLine();
    Console.WriteLine("Pressione Enter para continuar....");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
