namespace AspNetCoreWebAPI.Models
{
    public class Product
    {
        // When sending POST requests, the keys in the json MUST match (CASE-SENSITIVE!!)
        // the variable names of these field members
        public string Name { get; set; }
        public string Price { get; set; }
    }
}