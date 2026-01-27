var sys = new AuctionSystem();
sys.AddBid(11, 19, 186);
sys.UpdateBid(11, 19, 36);
sys.RemoveBid(11, 19);
sys.GetHighestBidder(19);


class AuctionSystem
{
    class Bid : IComparable<Bid>
    {
        public int userId;
        public int amount;
        public Bid(int userId, int amount)
        {
            this.userId = userId;
            this.amount = amount;
        }

        public int CompareTo(Bid? other)
        {
            if (this.amount > other.amount)
                return 1;
            else if (this.amount == other.amount)
                return this.userId > other.userId ? 1 : -1;
            else
                return -1;
        }
    }

    private Dictionary<string, Bid> bids;

    private Dictionary<int, SortedSet<Bid>> records;
    public AuctionSystem()
    {
        bids = new Dictionary<string, Bid>();
        records = new Dictionary<int, SortedSet<Bid>>();
    }

    public void AddBid(int userId, int itemId, int bidAmount)
    {
        var key = $"{userId}_{itemId}";
        if (!records.ContainsKey(itemId))
            records[itemId] = new SortedSet<Bid>();
        if (bids.ContainsKey(key))
            records[itemId].RemoveWhere(x => x.userId == bids[key].userId);
        var bid = new Bid(userId, bidAmount);
        bids[key] = bid;
        records[itemId].Add(bid);
    }

    public void UpdateBid(int userId, int itemId, int newAmount)
    {
        RemoveBid(userId, itemId);
        AddBid(userId, itemId, newAmount);
    }

    public void RemoveBid(int userId, int itemId)
    {
        var key = $"{userId}_{itemId}";
        var bid = bids[key];
        records[itemId].RemoveWhere(x => x.userId == bid.userId);
        bids.Remove(key);
    }

    public int GetHighestBidder(int itemId)
    {
        if (!records.ContainsKey(itemId))
            return -1;
        var bid = records[itemId].Max;
        return bid.userId;
    }
}