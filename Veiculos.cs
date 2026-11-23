namespace GestaoFrota;

public class Veiculo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public double KmAtual { get; set; }

    public Veiculo(string placa, string modelo, int ano, double kmAtual)
    {
        Placa = placa.ToUpper().Trim();
        Modelo = modelo.Trim();
        Ano = ano;
        KmAtual = kmAtual;
    }

    public override string ToString()
    {
        return $"[{Placa}] {Modelo} ({Ano}) - {KmAtual:N0} km";
    }

    public bool AtualizarKm(double novaKm)
{
    if (novaKm <= KmAtual)
    {
        return false;
    }

    KmAtual = novaKm;
    return true;
}

}