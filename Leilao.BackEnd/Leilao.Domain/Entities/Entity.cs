namespace Leilao.Domain.Entities
{
    //Entidade base. Outras entidades podem fazer uso dela mas fora isso, nunca poderá ser herdada
    public abstract class Entity
    {
        public Entity()
        {

        }

        public long Id { get; private set; }

    }
}