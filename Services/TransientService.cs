namespace dependence_injection_example
{
    public class TransientService : ITransientService
    {
        public Guid Id { get; set; }
        public TransientService()
        {
            Id = Guid.NewGuid();
        }
    }
}
