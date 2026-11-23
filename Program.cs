using GestaoFrota;

var veiculos = new List<Veiculo>();
var opcao = "";

while (opcao != "0")
{
    Console.Clear();
    Console.WriteLine("=== CONTROLE DE FROTA ===");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Listar veículos");
    Console.WriteLine("3 - Buscar veículo");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha uma opção: ");
    opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            Console.Write("Placa (ex: ESN-0G77): ");
            var placa = Console.ReadLine() ?? "";

            Console.Write("Modelo (ex: Voyage): ");
            var modelo = Console.ReadLine() ?? "";

            Console.Write("Ano (ex: 2010): ");
            var anoValido = int.TryParse(Console.ReadLine(), out var ano);

            Console.Write("KM atual (ex: 145000): ");
            var kmValido = double.TryParse(Console.ReadLine(), out var kmAtual);

            if (!string.IsNullOrWhiteSpace(placa) &&
                !string.IsNullOrWhiteSpace(modelo) &&
                anoValido && kmValido)
            {
                veiculos.Add(new Veiculo(placa, modelo, ano, kmAtual));
                Console.WriteLine("Veículo cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Dados inválidos. Verifica a placa, o modelo, o ano e a quilometragem.");
            }
            Pausar();
            break;

        case "2":
            Console.WriteLine("\n--- Veículos Cadastrados ---");
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado ainda.");   
            }
            else
            {
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {veiculos[i]}");
                }
            }
            Pausar();
            break;

        case "3":
            Console.Write("\nDigite parte da placa ou do modelo para buscar: ");
            var termo = (Console.ReadLine() ?? "").Trim();

            var encontrados = veiculos
                .Where(v => v.Placa.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                            v.Modelo.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("\n--- Resultados da Busca ---");
            if (string.IsNullOrWhiteSpace(termo) || encontrados.Count == 0)
            {
                Console.WriteLine("Nenhum veículo encontrado.");
            }
            else
            {
                foreach (var v in encontrados)
                {
                    Console.WriteLine(v);
                }
            }
            Pausar();
            break;

        case "0":
            Console.WriteLine("A encerrar o sistema...");
            break;

        default:
            Console.WriteLine("Opção inválida!");
            Pausar();
            break;
    }
}

static void Pausar()
{
    Console.WriteLine("\nCarrega em ENTER para continuar...");
    Console.ReadLine();
}