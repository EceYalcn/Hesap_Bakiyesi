using System;
using System.Collections.Generic;

class User
{
    public string Username { get; set; }
    public double Balance { get; set; }
    public List<Order> Orders { get; set; }
}

class Instrument
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Cart
{
    public List<Instrument> Instruments { get; set; }
}

class Order
{
    public User User { get; set; }
    public List<Instrument> Instruments { get; set; }
    public DateTime OrderDate { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User
        {
            Username = "sample_user",
            Balance = 1000, // Başlangıç bakiyesi
            Orders = new List<Order>()
        };

        Cart cart = new Cart
        {
            Instruments = new List<Instrument>()
            {
                new Instrument { Name = "Öğrenci", Price = 200 },
                new Instrument { Name = "Aile", Price = 300 },
                new Instrument { Name = "Premium Bireysel", Price = 315 },
                new Instrument { Name = "Premium Duo", Price = 200 }
            }
        };

        while (true)
        {
            Console.WriteLine("Üyelikler :");
            for (int i = 0; i < cart.Instruments.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {cart.Instruments[i].Name} : {cart.Instruments[i].Price} TL");
            }
            Console.WriteLine("9) Çıkış\n" +
                              "Bakiyeniz: " + user.Balance + " TL\n" +
                              "Seçiminizi Yapınız : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 9)
            {
                Console.WriteLine("Çıkış Yapılıyor...");
                break;
            }
            else if (choice >= 1 && choice <= cart.Instruments.Count)
            {
                int selectedInstrumentIndex = choice - 1;
                Instrument selectedInstrument = cart.Instruments[selectedInstrumentIndex];

                if (user.Balance >= selectedInstrument.Price)
                {
                    user.Balance -= selectedInstrument.Price;
                    Console.WriteLine($"{selectedInstrument.Name} Paketi Seçildi");
                    Order order = new Order
                    {
                        User = user,
                        Instruments = new List<Instrument> { selectedInstrument },
                        OrderDate = DateTime.Now
                    };
                    user.Orders.Add(order);
                }
                else
                {
                    Console.WriteLine($"Yetersiz bakiye. {selectedInstrument.Name} paketi almak için yeterli bakiyeniz yok.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            }
        }
    }
}

