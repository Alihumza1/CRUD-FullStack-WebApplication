using System.Collections.Generic;

namespace Web_Api.Models
{
    public class DataTablesParameters
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Searchmodel? search { get; set; }    
        public List<ColumnOrder> columns { get; set; }
        public List< ModelOrder>  order { get; set; }
    }
    public class Searchmodel
    {
        public string? value { get; set; }
    }
    public class ColumnOrder
    {
        public string? name { get; set; }
        public string? data { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
    }
    public class ModelOrder
    {
        public int column { get; set; }
        public string? dir { get; set; }
    }
}
