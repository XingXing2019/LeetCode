class OrderManagementSystem
{
    class Order
    {
        public int orderId;
        public int price;
        public string type;

        public Order(int orderId, int price, string type)
        {
            this.orderId = orderId;
            this.price = price;
            this.type = type;
        }
    }

    private Dictionary<int, Order> orders;
    private HashSet<Order> buys;
    private HashSet<Order> sells;
    
    public OrderManagementSystem()
    {
        orders = new Dictionary<int, Order>();
        buys = new HashSet<Order>();
        sells = new HashSet<Order>();
    }

    public void AddOrder(int orderId, string orderType, int price)
    {
        var order = new Order(orderId, price, orderType);
        if (orderType == "buy")
            buys.Add(order);
        else 
            sells.Add(order);
        orders[orderId] = order;
    }

    public void ModifyOrder(int orderId, int newPrice)
    {
        var order = orders[orderId];
        order.price = newPrice;
    }

    public void CancelOrder(int orderId)
    {
        var order = orders[orderId];
        orders.Remove(orderId);
        if (order.type == "buy")
            buys.Remove(order);
        else
            sells.Remove(order);
    }

    public int[] GetOrdersAtPrice(string orderType, int price)
    {
        if (orderType == "buy")
            return buys.Where(x => x.price == price).Select(x => x.orderId).ToArray();
        else
            return sells.Where(x => x.price == price).Select(x => x.orderId).ToArray();
    }
}