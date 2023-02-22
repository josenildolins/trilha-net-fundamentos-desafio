using System.Numerics;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; set; }
        public decimal PrecoPorHora { get; set; }
        
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.PrecoInicial = precoInicial;
            this.PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
        }

        public void RemoverVeiculo(string placa)
        {

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                veiculos.Remove(placa);                
            }
        }

        public List<string> ListarVeiculos()
        {
            if (veiculos.Any())
            {
                return veiculos;

            }
            else
            {
                return null;
            }
        }

        public decimal CalcularTempoPermanencia(string placa, int horas)
        {
                decimal valorTotal = 0;

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                valorTotal = (PrecoInicial + PrecoPorHora) * horas;
            }
            else
            {

                return 0;
            }
            return valorTotal;
        }

    }
}
