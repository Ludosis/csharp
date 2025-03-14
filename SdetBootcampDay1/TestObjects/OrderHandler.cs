﻿namespace SdetBootcampDay1.TestObjects
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        public OrderHandler() //default
        {
            this.stock.Add(OrderItem.FIFA_24, 10);
            this.stock.Add(OrderItem.Fortnite, 100);
            this.stock.Add(OrderItem.SuperMarioBros3, 5);

            this.paymentProcessor = new PaymentProcessor(PaymentProcessorType.Stripe);
        }
        public OrderHandler(Dictionary<OrderItem, int> stock, PaymentProcessor paymentProcessor)
        {
            this.stock = stock;

            this.paymentProcessor = paymentProcessor;
        }
        // public OrderHandler(OrderItem item, int quantity, PaymentProcessorType processor)
        // {
        //     this.stock.Add(item, quantity);

        //     this.paymentProcessor = new PaymentProcessor(processor);
        // }

        /*
        public bool OrderAndPay(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;

            return this.paymentProcessor.PayFor(item, quantity);
        }
        // ^ Original Reference
        */
        public bool PlaceOrder(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;

            //return Pay(item, quantity);
            return true;

            //return this.paymentProcessor.PayFor(item, quantity);
        }

        public bool Pay(OrderItem item, int quantity, PaymentProcessorType paymentProcessor)
        {
            //this.paymentProcessor.SetPaymentProcessor(paymentProcessor);
            return this.paymentProcessor.PayFor(item, quantity, paymentProcessor);
        }

        //^ Added

        public void AddStock(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            this.stock[item] += quantity;
        }

        public int GetStockFor(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            return this.stock[item]; 
        }
    }
}
