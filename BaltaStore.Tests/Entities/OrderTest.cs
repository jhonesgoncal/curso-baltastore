using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTest
    {
        private readonly Customer _customer;
        private readonly Order _order;
        private readonly Product _mouse;
        private readonly Product _keyboard;

        public OrderTest()
        {
            var name = new Name("Jhones", "Goncalves");
            var document = new Document("01449951074");
            var email = new Email("contato@jhones.io");

            _customer = new Customer(name, document, email, "11950634443");
            _order = new Order(_customer);

            _mouse = new Product("Mouse", "Mouse de computador", "img.png", 59.90M, 10);
            _keyboard = new Product("Teclado", "Teclado de computador", "img.png", 590.90M, 30);
        }

        [TestMethod]
        [TestCategory("Order - Entity")]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.IsTrue(_order.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreateWhenOrderCreated()
        {
            Assert.IsTrue(_order.Status == EOrderStatus.Created);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 2);
            Assert.IsTrue(_order.Items.Count == 2);
        }

        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void StatusShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Pay();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        public void StatusShouldReturnShipForShippingsWhenOrderShip()
        {
            _order.AddItem(_mouse, 2);
            _order.AddItem(_keyboard, 4);

            _order.Ship();

            foreach (var delivery in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Shipped, delivery.Status);
            }
        }

        [TestMethod]
        public void StatusShouldReturnCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnCanceledShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Cancel();

            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }
        }
    }
}