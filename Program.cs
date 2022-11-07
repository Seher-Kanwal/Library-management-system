class library
{
    String book_name = "";
    private int book_id;
    private int student_id = 0;
    public void printfn_book()
    {

        try
        {
            if (!File.Exists("book.txt"))
            {
                throw (new Exception("the file is not present"));
            }
            Console.WriteLine("Okay im going to print it......\n");
            StreamReader sw = new StreamReader("book.txt");
            string data = sw.ReadToEnd();
            Console.WriteLine(data);
            sw.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public void add_book()
    {
        Console.WriteLine("Entr name: ");
        book_name = Console.ReadLine();
        Console.WriteLine("Entr id: ");
        book_id = Convert.ToInt32(Console.ReadLine());
       

        StreamWriter sw1 = new StreamWriter("book.txt", append: true);
        sw1.WriteLine($"{book_id}\t{book_name}\t{student_id}");
        sw1.Flush();
        sw1.Close();
    }
    public void search() {
        Console.WriteLine("Enter the ID for searching: ");
        int val = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("book.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            book_id = Convert.ToInt32(data[0]);
            book_name = data[1];
            Console.WriteLine($"{book_id}    {book_name}");
            if (val == book_id)
            {
                a = false;
                Console.WriteLine("Value found:");
                Console.WriteLine($"id is :{book_id} \n the name is {book_name}");
                break;
            }

        }
        if (a)
        {
            Console.WriteLine("Value not found......");
        }


    }
    public void book_delete()
    {
        Console.WriteLine("Enter the ID for Deleting: ");
        int val = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("book.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            book_id = Convert.ToInt32(data[0]);
            book_name = data[1];
            if (val == book_id)
            {
                a = false;
                Console.WriteLine("Value found and deleted:");
            }
            else
            {
                StreamWriter raw_file = new StreamWriter("book2.txt", append: true);
                raw_file.WriteLine($"{book_id}\t{book_name}\t");
                raw_file.Flush();
                raw_file.Close();
            }
        }
        if (a)
        {
            Console.WriteLine("Value not found......");
        }
        sw2.Close();
        File.Delete("book.txt");
        Console.WriteLine("\t\t\tFinal file is get deleted is done\n");
        File.Move("book2.txt", "book.txt");
        Console.WriteLine("\t\t\tRename is done\n");
    }
    public void book_issued()
    {
        Console.WriteLine("These are the given book\n please choose from these books only:");
        printfn_book();
        Console.WriteLine("Enter the id  of the book:");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter you student id:");
        int student_id = Convert.ToInt32(Console.ReadLine());
        /*
         Here we will check the id of book and student from book and student file, if both are present 
         than we'll issue the book to student..
         here we just apply search operation and than we need to update the id only...
        
        
                  Ik how to do it but will do it later
                  Follow me on github to get more details 
         */
    }
    
    public void book_update()
    {
        Console.WriteLine("Enter book key to update:");
        int key = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 1 for book id, 2 for book name and 3 for student name:");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("book.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            book_id = Convert.ToInt32(data[0]);

            book_name = data[1];
            student_id = Convert.ToInt32(data[2]);
            if (key == book_id)
            {
                a = false;
                if (choice == 1)
                {
                    Console.WriteLine("Enter id");
                    book_id = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the name to change:");
                    book_name = Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the program name to change:");
                    student_id = Convert.ToInt32(Console.ReadLine());
                }
                StreamWriter raw_file1 = new StreamWriter("book2.txt", append: true);
                raw_file1.WriteLine($"{book_id}\t{book_name}\t{student_id}");
                raw_file1.Flush();
                raw_file1.Close();


            }
            else
            {
                StreamWriter raw_file = new StreamWriter("final2.txt", append: true);
                raw_file.WriteLine($"{book_id}\t{book_name}\t{student_id}");
                raw_file.Flush();
                raw_file.Close();
            }
        }
        sw2.Close();
        File.Delete("book.txt");
        Console.WriteLine("\t\t\tFinal file is get deleted is done\n");
        File.Move("book2.txt", "book.txt");
        Console.WriteLine("\t\t\tRename is done\n");


    }
}
class Student
{
    string name= "";
    private int id;
    string program = "";
    public void update()
    {
        Console.WriteLine("Enter key to update:");
        int key = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 1 for id, 2 for name and 3 for program:");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("final.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            id = Convert.ToInt32(data[0]);

            name = data[1];
            program = data[2];
            if (key == id)
            {
                a = false;
                if (choice == 1)
                {
                    Console.WriteLine("Enter id");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Enter the name to change:");
                    name = Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the program name to change:");
                    program = Console.ReadLine();
                }
                StreamWriter raw_file1 = new StreamWriter("final2.txt", append: true);
                raw_file1.WriteLine($"{id}\t{name}\t{program}");
                raw_file1.Flush();
                raw_file1.Close();


            }
            else
            {
                StreamWriter raw_file = new StreamWriter("final2.txt", append: true);
                raw_file.WriteLine($"{id}\t{name}\t{program}");
                raw_file.Flush();
                raw_file.Close();
            }
        }
        sw2.Close();
        File.Delete("final.txt");
        Console.WriteLine("\t\t\tFinal file is get deleted is done\n");
        File.Move("final2.txt", "final.txt");
        Console.WriteLine("\t\t\tRename is done\n");


    }
    public void delete()
    {
        Console.WriteLine("Enter the ID for Deleting: ");
        int val = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("final.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            id = Convert.ToInt32(data[0]);
            name = data[1];
            program = data[2];
            if (val == id)
            {
                a = false;
                Console.WriteLine("Value found and deleted:");
            }
            else
            {
                StreamWriter raw_file = new StreamWriter("final2.txt", append: true);
                raw_file.WriteLine($"{id}\t{name}\t{program}");
                raw_file.Flush();
                raw_file.Close();
            }
        }
        if (a)
        {
            Console.WriteLine("Value not found......");
        }
        sw2.Close();
        File.Delete("final.txt");
        Console.WriteLine("\t\t\tFinal file is get deleted is done\n");
        File.Move("final2.txt", "final.txt");
        Console.WriteLine("\t\t\tRename is done\n");
    }
    public void search()
    {
        Console.WriteLine("Enter the ID for searching: ");
        int val = Convert.ToInt32(Console.ReadLine());
        bool a = true;
        StreamReader sw2 = new StreamReader("final.txt");
        string[] records = sw2.ReadToEnd().Split("\n");
        for (int i = 0; i < records.Length - 1; i++)
        {
            string[] data = records[i].Split("\t");
            id = Convert.ToInt32(data[0]);
            name = data[1];
            program = data[2];
            Console.WriteLine($"{id}    {name}");
            if (val == id)
            {
                a = false;
                Console.WriteLine("Value found:");
                Console.WriteLine($"id is :{id} \n the name is {name} \n and the degree is {program}");
                break;
            }
        
        }
        if (a)
        {
            Console.WriteLine("Value not found......");
        }

    }
    public void create()
    {
        Console.WriteLine("Entr name: ");
        name = Console.ReadLine();
        Console.WriteLine("Entr id: ");
        id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Entr Degree: ");
        program = Console.ReadLine();

        StreamWriter sw1 = new StreamWriter("final.txt", append: true);
        sw1.WriteLine($"{id}\t{name}\t{program}");
        sw1.Flush();
        sw1.Close();

    }
    public void printfn()
    {

        try
        {
            if (!File.Exists("final.txt"))
            {
                throw (new Exception("the file is not present"));
            }
            Console.WriteLine("Okay im going to print it......\n");
            StreamReader sw = new StreamReader("final.txt");
            string data = sw.ReadToEnd();
            Console.WriteLine(data);
            sw.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
   
  
    static void Main(string[] args)
    {
        Student obj = new Student();
        string choice= "";
        string option = "";
        library obj2 = new library();
        while (option != "9")
        {
            Console.WriteLine("Enter 1 for student and 2 for library");
            choice = Console.ReadLine();
            if (choice == "2")
            {
                Console.WriteLine("Enter 1 for Entering the details of book:");
                Console.WriteLine("Enter 2 for deleteling the details of the book:");
                Console.WriteLine("Enter 3 for updating the records of the book:");
                Console.WriteLine("Enter 4 for viewing the details of the book:");
                Console.WriteLine("Enter 5 for searching a record:");
                Console.WriteLine("Enter 6 for lending the book to the student:");
                Console.WriteLine("Enter 9 for terminiting the loop:");
                option = Console.ReadLine();
                Console.WriteLine(option);
                if (option == "1")
                {
                    obj2.add_book();
                }
                else if (option == "4")
                {
                    obj2.printfn_book();
                }
                else if (option == "5")
                {
                    obj2.search();
                }
                else if (option == "2")
                {
                    obj2.book_delete();
                }
                else if (option == "3")
                {
                    obj2.book_update();
                }
                else if (option == "6")
                {
                    obj2.book_issued();
                }


            }
            if (choice == "1")
            {
                Console.WriteLine("Enter 1 for Entering the details:");
                Console.WriteLine("Enter 2 for deleteling the details:");
                Console.WriteLine("Enter 3 for updating the records:");
                Console.WriteLine("Enter 4 for viewing the details the details:");
                Console.WriteLine("Enter s for searching a record:");
                Console.WriteLine("Enter 9 for terminiting the loop:");
                option = Console.ReadLine();
                Console.WriteLine(option);
                if (option == "1")
                {
                    obj.create();
                }
                else if (option == "4")
                {
                    obj.printfn();
                }
               else if (option == "s")
                {
                    obj.search();
                }
                else if (option == "2")
                {
                    obj.delete();
                }
                else if (option == "3")
                {
                    obj.update();
                }


            }
        }
    }
}
