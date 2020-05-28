namespace WTVersus.Models
{
    /// <summary>Database context</summary>
    public class TankCollection
    {
        public AppDbContext Context { get; }
        public TankCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
