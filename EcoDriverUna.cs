using EcoDriver.Core.Models;
using EcoDriver.Core.Services;

Console.WriteLine("==================================================");
Console.WriteLine("        🌱 PROJETO ECODRIVER - MOBILIDADE        ");
Console.WriteLine("==================================================\n");

var calculadora = new CalculadoraEcoDriver();

Console.Write("Digite a distância percorrida por dia (km): ");
if (!double.TryParse(Console.ReadLine(), out double distancia) || distancia < 0)
{
    Console.WriteLine("⚠️ Distância inválida.");
    return;
}

Console.WriteLine("\nEscolha o meio de transporte principal:");
Console.WriteLine("1 - Bicicleta / Caminhada");
Console.WriteLine("2 - Metrô");
Console.WriteLine("3 - Ônibus");
Console.WriteLine("4 - Moto");
Console.WriteLine("5 - Carro a Gasolina");
Console.Write("Opção: ");

ModoTransporte modo = Console.ReadLine() switch
{
    "1" => ModoTransporte.BicicletaCaminhada,
    "2" => ModoTransporte.Metro,
    "3" => ModoTransporte.Onibus,
    "4" => ModoTransporte.Moto,
    "5" => ModoTransporte.CarroGasolina,
    _ => ModoTransporte.CarroGasolina
};

var resultado = calculadora.Calcular(distancia, modo);

Console.WriteLine("\n--------------------------------------------------");
Console.WriteLine("📊 RELATÓRIO DE IMPACTO AMBIENTAL");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Emissão Diária de CO2:  {resultado.Co2DiarioKg} kg");
Console.WriteLine($"Emissão Anual estimada: {resultado.Co2AnualKg} kg");
Console.WriteLine($"Árvores para compensar: {resultado.ArvoresNecessariasAnual} árvore(s)/ano");
Console.WriteLine("--------------------------------------------------\n");