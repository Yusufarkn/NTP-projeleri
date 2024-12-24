using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP8._2
{
    public interface Identifiable
    {
        Guid Id { get; }
    }

 
    public interface Experienced
    {
        void DisplayExperience();
    }

    // Aşılar sınıfı
    public class Vaccine
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Vaccine(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    // Evcil hayvan bilgisi için sınıf
    public class PetInformation
    {
        public List<string> Traits { get; set; }
        public List<Vaccine> Vaccines { get; set; }

        public PetInformation()
        {
            Traits = new List<string>();
            Vaccines = new List<Vaccine>();
        }

        public void AddVaccine(Vaccine vaccine)
        {
            Vaccines.Add(vaccine);
        }
    }

    // Hayvan sınıfı
    public class Animal
    {
        public string Type { get; set; }
        public string Breed { get; set; }
        public bool Carnivore { get; set; }

        public Animal(string type, string breed, bool carnivore)
        {
            Type = type;
            Breed = breed;
            Carnivore = carnivore;
        }
    }

    // Hayvan Sahibi sınıfı
    public class Owner : Experienced
    {
        public string Name { get; set; }

        public Owner(string name)
        {
            Name = name;
        }

        public void DisplayExperience()
        {
            Console.WriteLine($"{Name} is an experienced pet owner.");
        }
    }

    // Evcil Hayvan Sınıfı
    public class Pet : Identifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public Animal Type { get; set; }
        public PetInformation PetInfo { get; set; }

        public Pet(string name, int age, Owner owner, Animal type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Owner = owner;
            Type = type;
            PetInfo = new PetInformation();
        }

        public void Feed()
        {
            if (Type.Carnivore)
            {
                Console.WriteLine($"{Name} is being fed meat.");
            }
            else
            {
                Console.WriteLine($"{Name} is being fed vegetables.");
            }
        }

        private bool IsHerbivore()
        {
            return !Type.Carnivore;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new Owner("Ali");
            var animal = new Animal("Köpek", "Labrador", false);
            var pet = new Pet("Dost", 3, owner, animal);

            pet.PetInfo.Traits.Add("Dost canlısı");
            pet.PetInfo.Traits.Add("Sadık");
            pet.PetInfo.AddVaccine(new Vaccine("Kuduz", "Zorunlu"));

            pet.Feed();

            owner.DisplayExperience();

            Console.WriteLine($"Evcil hayvan {pet.Name}, {pet.Age} yaşında ve sahibi {pet.Owner.Name}.");
            Console.WriteLine($"Evcil hayvanın özellikleri: {string.Join(", ", pet.PetInfo.Traits)}");
            Console.WriteLine($"Aşılar: {string.Join(", ", pet.PetInfo.Vaccines.Select(v => v.Name))}");
            Console.ReadLine();
        }
    }
}
