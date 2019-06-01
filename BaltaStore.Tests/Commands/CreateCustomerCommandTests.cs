using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Jhones";
            command.LastName = "Goncalves";
            command.Document = "01449951074";
            command.Email = "contato@jhones.io";
            command.Phone = "1199999999";

            Assert.AreEqual(true, command.isValid());
        }
    }
}