using System;
using Flunt.Notifications;
using Flunt.Validations;
using Leilao.Domain.Commands.Contracts;

namespace Leilao.Domain.Commands
{
    public class UpdateLeilaoCommand : Notifiable, ICommand
    {
        public UpdateLeilaoCommand() { }

        public UpdateLeilaoCommand(long id, string nomeLeilao, Double valorInicial, bool itemUsado, DateTime dataInicio, DateTime dataFim, string user)
        {
            Id = id;
            nome_leilao = nomeLeilao;
            valor_inicial = valorInicial;
            item_usado = itemUsado;
            data_inicio = dataInicio;
            data_fim = dataFim;
            User = user;
        }

        public long Id { get; set; }
        public string nome_leilao { get; set; }
        public Double valor_inicial { get; set; }
        public bool item_usado { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Id do leilão", "O Id do leilão está vazio!")
                    .IsNotNullOrEmpty(nome_leilao, "Nome Leilão", "Favor informar o nome do Leilão!")
                    .IsNotNull(valor_inicial, "Valor inicial", "Favor informar o valor inicial do Leilão!")
                    .IsNotNull(item_usado, "Item usado", "Favor informar se o item a ser leioado é ou não usado!")
                    .IsNotNull(data_inicio, "Data Início", "Favor informar a data de início do Leilão!")
                    .IsNotNull(data_fim, "Data Fim", "Favor informar a data final do Leilão!")
                    .IsGreaterThan(valor_inicial, 0, "Valor inicial", "O valor inicial não deve ser menor ou igual a zero!")
                    .IsGreaterThan(data_fim, data_inicio, "Data Final", "A data final não pode ser menor ou igual a data inicial!")
                    .HasMaxLen(nome_leilao, 100, "Nome Leilão", "O nome deve conter até 100 caracteres!")
                    .IsNotNullOrEmpty(User, "Usuário", "O usuário está vazio!")
            );
        }
    }
}