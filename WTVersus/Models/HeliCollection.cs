namespace WTVersus.Models
{
    /// <summary>Database context</summary>
    public class HeliCollection
    {
        public AppDbContext Context { get; }
        public HeliCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
