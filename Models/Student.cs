
namespace CRUD_App.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? created_at { get; set; }

        public DateTime? updated_at = null;

        public String? City { get; set; }

        public String ToString()
        {
            return "[ id = "+this.Id+ " name = "+this.Name+ " description = "+this.Description+ " created_At =  "+this.created_at.ToString()+
                    " updated_At "+this?.updated_at.ToString()+ " City = "+this.City+ "]";
        }
    }
}
