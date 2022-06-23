int[] servers = { 3, 3 };
int[] tasks = { 2, 1, 1 };

AssignTasks(servers, tasks);

int[] AssignTasks(int[] servers, int[] tasks)
{
    var idle = new PriorityQueue<Server, Server>();
    var busy = new PriorityQueue<Server, BusyServer>();
    var res = new int[tasks.Length];
    for (int i = 0; i < servers.Length; i++)
    {
        var server = new Server(i, servers[i]);
        idle.Enqueue(server, server);
    }
    for (int i = 0; i < tasks.Length; i++)
    {
        while (busy.Count != 0 && busy.Peek()._freeTime <= i)
        {
            var server = busy.Dequeue();
            idle.Enqueue(server, server);
        }
        if (idle.Count != 0)
        {
            var freeServer = idle.Dequeue();
            freeServer._freeTime = i + tasks[i];
            res[i] = freeServer._index;
            busy.Enqueue(freeServer, new BusyServer(freeServer, freeServer._freeTime));
        }
        else
        {
            var freeServer = busy.Dequeue();
            freeServer._freeTime += tasks[i];
            res[i] = freeServer._index;
            busy.Enqueue(freeServer, new BusyServer(freeServer, freeServer._freeTime));
        }
    }
    return res;
}

class Server : IComparable
{
    public int _index;
    public int _freeTime;
    private int _weight;

    public Server(int index, int weight)
    {
        _index = index;
        _weight = weight;
    }
    public int CompareTo(object? obj)
    {
        var that = (Server)obj;
        if (this._weight == that._weight)
            return this._index < that._index ? -1 : 1;
        return this._weight < that._weight ? -1 : 1;
    }
}

class BusyServer : IComparable
{
    private readonly Server _server;
    private readonly int _freeTime;
    public BusyServer(Server server, int freeTime)
    {
        _server = server;
        _freeTime = freeTime;
    }
    public int CompareTo(object? obj)
    {
        var that = (BusyServer)obj;
        if (this._freeTime == that._freeTime)
            return this._server.CompareTo(that._server);
        return this._freeTime < that._freeTime ? -1 : 1;
    }
}