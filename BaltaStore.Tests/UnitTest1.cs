using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Jhones","Goncalves");
            var document = new Document("41441441432");
            var email = new Email("contato@jhones.io");
            var customer = new Customer(name, document, email, "1141313170");

            var mouse = new Product("Mouse", "Mouse de computador", "img.png", 59.90M, 20);
            var teclado = new Product("Teclado", "Teclado de computador", "img.png", 590.90M, 30);
            var cadeira = new Product("Cadeira", "Cadeira de computador", "img.png", 159.90M, 10);

            var mouse1 = new Product("Mouse", "Mouse de computador", "img.png", 59.90M, 20);
            var teclado1 = new Product("Teclado", "Teclado de computador", "img.png", 590.90M, 30);
            var cadeira1 = new Product("Cadeira", "Cadeira de computador", "img.png", 159.90M, 10);

            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(teclado, 1));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(mouse1, 2));
            order.AddItem(new OrderItem(teclado1, 1));
            order.AddItem(new OrderItem(cadeira1, 5));

            order.Place();

            order.Pay();

            order.Ship();

            order.Cancel();
        }
    }
}
