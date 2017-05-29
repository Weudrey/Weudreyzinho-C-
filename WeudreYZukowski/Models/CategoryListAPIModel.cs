using Model.Tables;

namespace WeudreYZukowski.Models
{
    public class CategoryListAPIModel : APIModel
    {
        public System.Collections.Generic.List<Category> Result { get; set; }
    }
    public class CategoryAPIModel : APIModel
    {
        public Category Result { get; set; }
    }
}