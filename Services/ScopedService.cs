namespace dependence_injection_example
{
    public class ScopedService : IScopedService
    {
        public Guid Id { get; set; }
        public ScopedService()
        {
            Id = Guid.NewGuid();
        }
    }
}
