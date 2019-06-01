using BaltaStore.Domain.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private readonly Document _validDocument;
        private readonly Document _invalidDocument;

        public DocumentTests()
        {
            _validDocument = new Document("01449951074");
            _invalidDocument = new Document("1212");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.IsTrue(_invalidDocument.Invalid);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.IsTrue(_validDocument.Valid);
        }
    }
}