class TaskManager
{
    class Task : IComparable<Task>
    {
        public int taskId;
        public int userId;
        public int priority;

        public Task(int userId, int taskId, int priority)
        {
            this.userId = userId;
            this.taskId = taskId;
            this.priority = priority;
        }

        public int CompareTo(Task? other)
        {
            if (other == null)
                return 1;
            return this.priority == other.priority ? other.taskId - this.taskId : other.priority - this.priority;
        }
    }

    PriorityQueue<Task, Task> _tasks;
    Dictionary<int, int> _priorities;
    Dictionary<int, int> _users;

    public TaskManager(IList<IList<int>> tasks)
    {
        _tasks = new PriorityQueue<Task, Task>();
        _priorities = new Dictionary<int, int>();
        _users = new Dictionary<int, int>();
        foreach (var t in tasks)
        {
            var task = new Task(t[0], t[1], t[2]);
            _tasks.Enqueue(task, task);
            _priorities[t[1]] = t[2];
            _users[t[1]] = t[0];
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        var task = new Task(userId, taskId, priority);
        _tasks.Enqueue(task, task);
        _priorities[taskId] = priority;
        _users[taskId] = userId;
    }

    public void Edit(int taskId, int newPriority)
    {
        _priorities[taskId] = newPriority;
        var userId = _users[taskId];
        var task = new Task(userId, taskId, newPriority);
        _tasks.Enqueue(task, task);
    }

    public void Rmv(int taskId)
    {
        _priorities.Remove(taskId);
        _users.Remove(taskId);
    }

    public int ExecTop()
    {
        while (_tasks.Count != 0)
        {
            var task = _tasks.Dequeue();
            if (_priorities.ContainsKey(task.taskId) && _priorities[task.taskId] == task.priority)
            {
                _priorities.Remove(task.taskId);
                _users.Remove(task.taskId);
                return task.userId;
            }
        }
        return -1;
    }
}