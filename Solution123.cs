using System.Collections.Generic;

namespace ConsoleApp1
{
    class LogisticSystem
    {
        public enum OrderStatus
        {
            Pending,
            InTransit,
            Processed
        }

        public enum ItemType
        {
            Item1,
            Item2
        }

        public class Item
        {
            int itemID;
            ItemType iType;
            OrderStatus status;
            int quantity;
            public int cost { get; private set; }
            Location destionation;
        }

        public class Order
        {
            int OrderID;
            OrderStatus status;
            int amount;
            List<Item> itemList;  
            
            public Order(Item items)
            {
                OrderID = 123;
                status = OrderStatus.Pending;
                itemList.Add(items);
                amount = items.cost;
            }
        }

        public class Location
        {
            string address;
            float Logitude;
            float Latitude;
        }

        public class Client
        {
            int clientID;
            List<Item> orderHistory;
            int amount;
            List<Location> prefferedLocations;


            //functionality
            public void PlaceNewOrder(List<Item> items)
            {

            }

            public OrderStatus CheckStatus(int orderID)
            {
                return OrderStatus.InTransit;
            }
        }

        public class Admin
        {
            List<Order> incompleteOrders;

            //TrackOrders
            //Methods
            public void NewOrderCreated(Order order)
            {

            }

            public void OrderDelivered(Order order)
            {
                string s = string.Empty;                
            }
        }
    }
}
