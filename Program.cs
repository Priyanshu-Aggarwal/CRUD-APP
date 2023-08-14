using CRUD_App.DB;
using CRUD_App.Models;
using static System.Console;
public class Entry
{
    static void Main(string[] args)
    {
        MyDB db = new MyDB();
        
        // Mock Data for Testing Purpose

        //Student student1 = new Student() { Name = "John", Description ="Manager", City ="Delhi"};
        //Student student2 = new Student() { Name = "Denny", Description = "Manager", City = "Lucknow" };
        //Student student3 = new Student() { Name = "Mary", Description = "Clerk", City = "Delhi" };
        //Student student4 = new Student() { Name = "Brian", Description = "Clerk", City = "UP" };
        //Student student5 = new Student() { Name = "David", Description = "Finance", City = "UK" };
        //Student student6 = new Student() { Name = "Cartman", Description = "Finance", City = "GK" };

        //db.Create(student1);
        //db.Create(student2);
        //db.Create(student3);
        //db.Create(student4);
        //db.Create(student5);
        //db.Create(student6);


        
        bool check = true;
        while (check)
        {
            WriteLine("1 for Create");
            WriteLine("2 for Update");
            WriteLine("3 for Fetch");
            WriteLine("4 for FetchByID");
            WriteLine("5 for DeleteById");
            WriteLine("6 for FindByFilter");
            WriteLine("0 for Exit");

            var result = ReadLine();

            switch (result)
            {
                case "1":
                    {
                        string name, description, city;
                        Write(" Enter Name: ");
                        name = ReadLine();
                        Write(" Enter Description: ");
                        description = ReadLine();
                        Write("Enter City: ");
                        city = ReadLine();
                        Student student = new() { Name = name, Description = description,City= city };
                        db.Create(student);
                        break;
                    }
                case "2":
                    {
                        string name, description;
                        Write("Enter ID: ");
                        int id = Convert.ToInt32(ReadLine());
                        Write(" Enter Name: ");
                        name = ReadLine();
                        Write(" Enter Description: ");
                        description = ReadLine();
                        Student student = new() { Id = id, Name = name, Description = description };
                        db.Update(student);
                        break;
                    }

                case "3": {  db.FindAll(); break; }

                case "4": 
                    {
                        Write("Enter ID: ");
                        int id = Convert.ToInt32(ReadLine());
                        var res = db.FindById(id);
                        WriteLine(res.ToString());
                        break;
                    }
                case "5": 
                    {
                        Write("Enter ID: ");
                        int id = Convert.ToInt32(ReadLine());
                        db.DeleteById(id);                        
                        break;
                    }
                case "6":
                    {
                        WriteLine("Choose Filter  1 for City and 2 for Name: ");
                        int option = Convert.ToInt32(ReadLine());
                        string data = ReadLine();
                        switch (option)
                        {
                            case 1: { db.FindAllByOption(Options.City, data); break;}
                            case 2: { db.FindAllByOption(Options.Name, data); break; }
                        }
                        break;
                    }
                case "0": { check = false; break; }

                default: { WriteLine("Choose Correct Option") ; break; }
            }
        }
        
        
    }
}
