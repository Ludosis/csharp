using System.Diagnostics;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SdetBootcampDay2.TestObjects.Answers;

namespace SdetBootcampDay2.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        [SetUp]
        public void InitItem()
        {
            OrderItem item = new OrderItem();
        }

        [TestCase(OrderItem.FIFA_24, 10, TestName = "10 Copies of FIFA_24")]
        [TestCase(OrderItem.Fortnite, 5, TestName = "5 Copies of Fortnite")]
        [TestCase(OrderItem.SuperMarioBros3, 1, TestName = "1 Copy of SuperMarioBros3")]

        [Test]
        public void MockPaymentProcessor_ReturnFalseForAllStripePayments(OrderItem item, int count)
        {
            //Test Case
            //OrderItem item = new OrderItem();
            //item = OrderItem.FIFA_24;
            //int count = 10;

            Dictionary<OrderItem, int> stock = new Dictionary<OrderItem, int>
            {
                { item, count }
            };

            /**
             * TODO: Create a mock object representing the payment processor. Pass in Stripe
             * as the payment processor type. Set up the mock so that a call to PayFor() with
             * FIFA 24 and 10 as arguments returns false.
             */
            var mockPaymentProcessor = new Mock<PaymentProcessor>(PaymentProcessorType.Stripe);
            mockPaymentProcessor.Setup(o => o.PayFor(item, count)).Returns(false);

            /**
             * TODO: Complete the test by creating a new OrderHandler, passing in the mock object
             * for the payment processor. Call the Order() method and then assert that the PayFor()
             * method of the OrderHandler returns false
             */
            OrderHandler oh = new OrderHandler(stock, mockPaymentProcessor.Object);
            oh.Order(item, count);
            Assert.That(oh.PayFor(item, count), Is.False);

            /**
             * TODO: verify that the PayFor() method of the mock payment processor was called
             * exactly once with FIFA_24 and 10 as parameters.
             */
            mockPaymentProcessor.Verify(m => m.PayFor(item, count), Times.Once());

        }
    }
}
