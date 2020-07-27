using System;

namespace Leilao.Domain.Entities
{
    public class ItemLeilao : Entity
    {
        public ItemLeilao()
        {

        }

        public ItemLeilao(string nomeLeilao, Double valorInicial, bool itemUsado, DateTime dataInicio, DateTime dataFim, string nomeUsuario, string user)
        {
            nome_leilao = nomeLeilao;
            valor_inicial = valorInicial;
            item_usado = itemUsado;
            data_inicio = dataInicio;
            data_fim = dataFim;
            nome_usuario = nomeUsuario;
            User = user;
        }

        public string nome_leilao { get; private set; }
        public Double valor_inicial { get; private set; }
        public bool item_usado { get; private set; }
        public DateTime data_inicio { get; private set; }
        public DateTime data_fim { get; private set; }
        public string nome_usuario { get; private set; }
        public string User { get; private set; } //vem da api do google como uma referência

        public void UpdateLeilao(string nomeLeilao, Double valorInicial, bool itemUsado, DateTime dataInicio, DateTime dataFim)
        {
            nome_leilao = nomeLeilao;
            valor_inicial = valorInicial;
            item_usado = itemUsado;
            data_inicio = dataInicio;
            data_fim = dataFim;
        }
    }
}