// See https://aka.ms/new-console-template for more information
using singletonclass;

Console.WriteLine("Hello, World!");
Parallel.Invoke(
               //Let us Assume PrintTeacherDetails method is Invoked by Thread-1
               () => PrintTeacherDetails(),
               //Let us Assume PrintStudentdetails method is Invoked by Thread-2
               () => PrintStudentdetails()
               );
Console.ReadLine();
static void PrintTeacherDetails(){
    logger log = logger.getInstance();
    Console.WriteLine("from teachers");
}
static void PrintStudentdetails()
{
    logger log = logger.getInstance();
    Console.WriteLine("from students");
}
