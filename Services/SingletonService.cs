namespace dependence_injection_example
{
    public class SingletonService : ISingletonService
    {
        public Guid Id { get; set; }
        public SingletonService()
        {
            Id = Guid.NewGuid();
        }
    }
}
