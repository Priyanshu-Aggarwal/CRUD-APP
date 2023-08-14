using CRUD_App.Models;

namespace CRUD_App.DB
{
    public enum Options
    {
        Name,
        City
    }

    public class MyDB
    {
        // static index which increments always when we Create the student. Used to store it as ID
        static int index = 0;
        public static List<Student> studentDB;
        public MyDB() {
            studentDB = new List<Student>();
        }

        // Add Students
        public Student Create(Student student)
        {
            student.Id = ++index;
            student.created_at = DateTime.Now;
            studentDB.Add(student);
            Console.WriteLine("Created");
            return student;
        }

        // Delete Student By ID
        public void DeleteById(int id)
        {
            try
            {
                studentDB.RemoveAll(student => student.Id == id);
            }
            catch(Exception) {
                Console.WriteLine("No Data Found");
            }
            Console.WriteLine("Deleted...");
        }
        // Get All Student
        public void FindAll() {

            PrintDB(studentDB);
        }

        // Get Student By ID
        public dynamic FindById(int id)
        {
            Student student = new Student() ;
            try
            {
                student = studentDB.First(student => student.Id == id);
                return student;
            }
            catch (Exception){
                Console.WriteLine("DB is Empty OR No Data Found");
            }
            return "";
        }

        // Find Student Using Filter By Name OR City
        public void FindAllByOption(Options option, string data)
        {
          List<Student> studentList = new List<Student>();
          switch (option)
            {
                case Options.Name:
                    {
                         studentList = studentDB.Where(student => student.Name.Equals(data, StringComparison.OrdinalIgnoreCase)).ToList();
                         break;
                    }
                case Options.City:
                    {
                         studentList = studentDB.Where(student => student.City.Equals(data , StringComparison.OrdinalIgnoreCase)).ToList();
                         break;
                    }
            }
            PrintDB(studentList);
           
        }
        // Update Student
        public Student Update(Student st)
        {
            Student student = studentDB.First(student => student.Id == st.Id);
            // fetching the index
            int index = studentDB.IndexOf(student);
            // setting the values
            student.Name= st.Name;
            student.Description = st.Description;
            student.updated_at = DateTime.Now;

            studentDB[index] = student;
            return student;
        }

        // Print the Student List
        private void PrintDB(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
