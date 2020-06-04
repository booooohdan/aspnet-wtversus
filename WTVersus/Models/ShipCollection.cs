namespace WTVersus.Models
{
    /// <summary>Database context</summary>
    public class ShipCollection
    {
        public AppDbContext Context { get; }
        public ShipCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
