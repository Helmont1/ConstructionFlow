namespace ConstructionFlowAPI.Entities
{
    public class Construction
    {
        public Guid ConstructionId { get; set; }
        public required PropertyType PropertyType { get; set; }

    }
}
