using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP8._3
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Payment { get; set; }

        public void Update()
        {
            Console.WriteLine("Müşteri bilgileri güncellendi.");
        }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }

        public void Update()
        {
            Console.WriteLine("İşlem güncellendi.");
        }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string List { get; set; }

        public void Confirmation()
        {
            Console.WriteLine("Rezervasyon onaylandı.");
        }
    }

    public class RentingOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNum { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void VerifyAccount()
        {
            Console.WriteLine("Hesap doğrulandı.");
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public int Details { get; set; }
        public string OrderType { get; set; }

        public void ProcessDebit()
        {
            Console.WriteLine("Ödeme işleme alındı.");
        }
    }

    public class Payment
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string Amount { get; set; }

        public void Add()
        {
            Console.WriteLine("Ödeme eklendi.");
        }

        public void Update()
        {
            Console.WriteLine("Ödeme güncellendi.");
        }
    }

    public class Rentals
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Price { get; set; }

        public void Add()
        {
            Console.WriteLine("Kiralama eklendi.");
        }

        public void Update()
        {
            Console.WriteLine("Kiralama güncellendi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yeni müşteri
            Customer customer = new Customer
            {
                Id = 2,
                Name = "Ayşe Demir",
                Contact = "05551234567",
                Address = "Sakarya Mahallesi, No:45",
                Payment = 750
            };

            customer.Update();

            // Yeni işlem
            Transaction transaction = new Transaction
            {
                Id = 202,
                Name = "Araç Bakım Hizmeti",
                Date = "2024-12-30",
                Address = "Yenimahalle Servis Merkezi"
            };

            transaction.Update();

            // Yeni rezervasyon
            Reservation reservation = new Reservation
            {
                Id = 303,
                Details = "Sedan Araç",
                List = "VIP Rezervasyon Listesi"
            };

            reservation.Confirmation();

            // Yeni araç
            Car car = new Car
            {
                Id = 404,
                Details = 7890,
                OrderType = "Manuel"
            };

            car.ProcessDebit();

            // Yeni ödeme
            Payment payment = new Payment
            {
                Id = 505,
                CardNumber = 987654321,
                Amount = "₺1500"
            };

            payment.Add();
            payment.Update();

            // Yeni kiralama
            Rentals rentals = new Rentals
            {
                Id = 606,
                Names = "Ayşe'nin Kiralaması",
                Price = "₺500"
            };

            rentals.Add();
            rentals.Update();

            // Yeni kiralama sahibi
            RentingOwner owner = new RentingOwner
            {
                Id = 707,
                Name = "Ali Veli",
                Age = 52,
                ContactNum = "05449876543",
                Username = "ali_sahip",
                Password = "gizlisifre"
            };

            owner.VerifyAccount();
            Console.ReadLine();
        }
    }
}
