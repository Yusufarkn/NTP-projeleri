using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int PostalCode { get; set; }
    public string Country { get; set; }

    public bool Validate()
    {
        // Adres doğrulama mantığı
        return !string.IsNullOrWhiteSpace(Street) && !string.IsNullOrWhiteSpace(City) && PostalCode > 0;
    }

    public string OutputAsLabel()
    {
        return $"{Street}, {City}, {State}, {Country} - {PostalCode}";
    }
}

public abstract class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public Address LivesAt { get; set; }

    public void PurchaseParkingPass()
    {
        Console.WriteLine($"{Name} bir otopark kartı satın aldı.");
    }
}

public class Student : Person
{
    public int StudentNumber { get; set; }
    public int AverageMark { get; set; }

    public bool IsEligibleToEnroll(string course)
    {
        // Ders kayıt uygunluğu kontrolü
        Console.WriteLine($"Ders kaydı uygunluğu kontrol ediliyor: {course}");
        return AverageMark >= 50;
    }

    public int GetSeminarsTaken()
    {
        // Seminer sayısını hesaplayan örnek bir metod
        return new Random().Next(1, 10);
    }
}

public class Professor : Person
{
    public int Salary { get; set; }
    protected int StaffNumber { get; set; }
    protected int YearsOfService { get; set; }
    protected int NumberOfClasses { get; set; }

    public Professor(int staffNumber, int yearsOfService, int numberOfClasses)
    {
        StaffNumber = staffNumber;
        YearsOfService = yearsOfService;
        NumberOfClasses = numberOfClasses;
    }

    public void SuperviseStudent(Student student)
    {
        Console.WriteLine($"{Name}, {student.Name} adlı öğrenciyi denetliyor.");
    }
}

namespace NTP8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address
            {
                Street = "123 Ana Cadde",
                City = "Bahçelievler",
                State = "Ankara",
                PostalCode = 06000,
                Country = "Türkiye"
            };

            Student student = new Student
            {
                Name = "Ahmet Yılmaz",
                PhoneNumber = "123-456-7890",
                EmailAddress = "ahmet.yilmaz@ornek.com",
                StudentNumber = 1001,
                AverageMark = 75,
                LivesAt = address
            };

            Professor professor = new Professor(2001, 10, 5)
            {
                Name = "Dr. Kaya",
                PhoneNumber = "987-654-3210",
                EmailAddress = "dr.kaya@ornek.com",
                Salary = 90000,
                LivesAt = address
            };

            Console.WriteLine(student.IsEligibleToEnroll("Matematik 101") ?
                "Öğrenci bu derse kaydolmaya uygun." :
                "Öğrenci bu derse kaydolmaya uygun değil.");
            professor.SuperviseStudent(student);
            Console.ReadLine();
        }
    }
}