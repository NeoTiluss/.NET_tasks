class Program
{
    static void Main()
    {
        using (var context = new SchoolDbContext())
        {
            var teachers = context.Teachers
                .Where(t => t.TeacherPupils.Any(tp => tp.Pupil.FirstName == "Giorgi"))
                .ToArray();

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.FirstName} {teacher.LastName}");
            }
        }
    }
}
