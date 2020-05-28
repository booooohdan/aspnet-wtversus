namespace WTVersus.Models
{
    /// <summary>Database context</summary>
    public class PlaneCollection
    {
        public AppDbContext Context { get; }
        public PlaneCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
