namespace EFCoreDrillsApi.DTOs
{
    public class PaginationResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        // Dynamically calculate total pages based on count and size
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}