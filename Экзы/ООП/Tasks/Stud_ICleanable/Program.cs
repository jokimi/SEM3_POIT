using System;
using System.Collections.Generic;
using System.Linq;

enum Speciality
{
    POIT,
    ISIT,
    Mobile
}

class Stud
{
    public string Name { get; set; }
    public int GroupNumber { get; set; }
    public int Course { get; set; }
    public Speciality Speciality { get; set; }
    public List<int> ExamScores { get; set; }

    public Stud(string name, int groupNumber, int course, Speciality speciality, List<int> examScores)
    {
        Name = name;
        GroupNumber = groupNumber;
        Course = course;
        Speciality = speciality;
        ExamScores = examScores;
    }

    public (int, int, double) GetExamStats()
    {
        int minScore = ExamScores.Min();
        int maxScore = ExamScores.Max();
        double averageScore = ExamScores.Average();
        return (minScore, maxScore, averageScore);
    }
}

class Group
{
    public List<Stud> students;

    public Group()
    {
        students = new List<Stud>();
    }

    public void AddStudent(Stud student)
    {
        students.Add(student);
    }

    public void PrintStudents()
    {
        foreach (Stud student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Group: {student.GroupNumber}, Course: {student.Course}, Speciality: {student.Speciality}");
        }
    }

    public IEnumerable<Stud> GetStudentsWithMaxAverageScoreBySpeciality(Speciality speciality)
    {
        var maxAverageScore = students.Where(s => s.Speciality == speciality)
                                      .Max(s => s.GetExamStats().Item3);

        return students.Where(s => s.Speciality == speciality && s.GetExamStats().Item3 == maxAverageScore);
    }
}

interface ICleanable
{
    void Clean();
}

class GroupWithCleanup : Group, ICleanable
{
    public void Clean()
    {
        if (students.Count == 0)
        {
            throw new InvalidOperationException("The group is already empty.");
        }
        else
        {
            students.Clear();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов типа Stud
        Stud student1 = new Stud("John", 1, 2, Speciality.POIT, new List<int> { 80, 85, 90 });
        Stud student2 = new Stud("Alice", 2, 3, Speciality.ISIT, new List<int> { 75, 92, 88 });
        Stud student3 = new Stud("Bob", 1, 1, Speciality.Mobile, new List<int> { 90, 92, 95 });
        Stud student4 = new Stud("Sarah", 2, 2, Speciality.POIT, new List<int> { 85, 90, 87 });
        Stud student5 = new Stud("Mike", 1, 3, Speciality.Mobile, new List<int> { 80, 85, 82 });

        // Создание объекта типа Group
        Group group = new Group();

        // Добавление студентов в группу
        group.AddStudent(student1);
        group.AddStudent(student2);
        group.AddStudent(student3);
        group.AddStudent(student4);
        group.AddStudent(student5);

        // Вывод информации о студентах в группе
        Console.WriteLine("Students in the group:");
        group.PrintStudents();
        Console.WriteLine();

        // Вывод студентов с максимальным средним баллом для каждой специальности
        Console.WriteLine("Students with the maximum average score for each speciality:");
        foreach (Speciality speciality in Enum.GetValues(typeof(Speciality)))
        {
            var studentsWithMaxAverageScore = group.GetStudentsWithMaxAverageScoreBySpeciality(speciality);
            Console.WriteLine($"Speciality: {speciality}");
            foreach (Stud student in studentsWithMaxAverageScore)
            {
                Console.WriteLine($"Name: {student.Name}, Group: {student.GroupNumber}, Course: {student.Course}");
            }
            Console.WriteLine();
        }

        // Очистка группы
        GroupWithCleanup groupWithCleanup = new GroupWithCleanup();
        groupWithCleanup.AddStudent(student1);
        groupWithCleanup.Clean();
        //groupWithCleanup.Clean(); // Генерирует исключение, так как группа уже пуста
    }
}