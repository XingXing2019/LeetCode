var sys = new RideSharingSystem();
sys.AddRider(8);
sys.AddDriver(8);
sys.AddDriver(6);
sys.MatchDriverWithRider();
sys.AddRider(2);
sys.CancelRider(2);
sys.MatchDriverWithRider();

class RideSharingSystem
{
    class User
    {
        public int Id;
        public bool IsCancelled;
        public User(int id) { Id = id; }
    }

    private Queue<User> riders;
    private Queue<User> drivers;
    private Dictionary<int, User> riderDict;
    private Dictionary<int, User> driverDict;

    public RideSharingSystem()
    {
        riders = new Queue<User>();
        drivers = new Queue<User>();
        riderDict = new Dictionary<int, User>();
        driverDict = new Dictionary<int, User>();
    }

    public void AddRider(int riderId)
    {
        var rider = new User(riderId);
        riders.Enqueue(rider);
        riderDict[riderId] = rider;
    }

    public void AddDriver(int driverId)
    {
        var driver = new User(driverId);
        drivers.Enqueue(driver);
        driverDict[driverId] = driver;
    }

    public int[] MatchDriverWithRider()
    {
        while (riders.Count != 0 && riders.Peek().IsCancelled)
            riders.Dequeue();
        if (riders.Count != 0 && drivers.Count != 0)
        {
            var rider = riders.Dequeue();
            var driver = drivers.Dequeue();
            return new[] { driver.Id, rider.Id };
        }
        return new[] { -1, -1 };
    }

    public void CancelRider(int riderId)
    {
        if (!riderDict.ContainsKey(riderId))
            return;
        riderDict[riderId].IsCancelled = true;
    }
}