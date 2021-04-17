namespace Communications.Api.Models
{
    using System.Collections.Generic;

    public class Paged<T> where T : class, new()
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RecordsInPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
    }
}