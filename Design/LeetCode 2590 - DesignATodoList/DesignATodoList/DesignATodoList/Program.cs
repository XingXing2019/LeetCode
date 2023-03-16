var toDoList = new TodoList();
toDoList.AddTask(1, "Task1", 50, new List<string>());
toDoList.AddTask(1, "Task2", 100, new List<string> { "P1" });
toDoList.GetAllTasks(1);
toDoList.GetAllTasks(5);
toDoList.AddTask(1, "Task3", 30, new List<string> { "P1" });
toDoList.GetTasksForTag(1, "P1");
toDoList.CompleteTask(5, 1);
toDoList.CompleteTask(1, 2);
toDoList.GetTasksForTag(1, "P1");


class TodoList
{
    class Task : IComparable
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskDescription { get; set; }
        public int DueDate { get; set; }
        public HashSet<string> Tags { get; set; }

        public Task(int taskId, int userId, string taskDescription, int dueDate, IList<string> tags)
        {
            TaskId = taskId;
            UserId = userId;
            TaskDescription = taskDescription;
            DueDate = dueDate;
            Tags = new HashSet<string>(tags);
        }

        public int CompareTo(object? obj)
        {
            var that = obj as Task;
            if (this.DueDate == that.DueDate)
                return 0;
            return this.DueDate < that.DueDate ? -1 : 1;
        }
    }

    class User
    {
        public int UserId { get; set; }
        public SortedSet<Task> IncompletedTasks { get; set; }
        public User(int userId)
        {
            UserId = userId;
            IncompletedTasks = new SortedSet<Task>();
        }
    }

    private int _taskId;
    private Dictionary<int, Task> _tasks;
    private Dictionary<int, User> _users;

    public TodoList()
    {
        _taskId = 1;
        _tasks = new Dictionary<int, Task>();
        _users = new Dictionary<int, User>();
    }

    public int AddTask(int userId, string taskDescription, int dueDate, IList<string> tags)
    {
        var task = new Task(_taskId, userId, taskDescription, dueDate, tags);
        _tasks[_taskId] = task;
        if (!_users.ContainsKey(userId))
            _users[userId] = new User(userId);
        _users[userId].IncompletedTasks.Add(task);
        return _taskId++;
    }

    public IList<string> GetAllTasks(int userId)
    {
        if (!_users.ContainsKey(userId))
            return new List<string>();
        var tasks = _users[userId].IncompletedTasks;
        return tasks.Select(x => x.TaskDescription).ToList();
    }

    public IList<string> GetTasksForTag(int userId, string tag)
    {
        if (!_users.ContainsKey(userId))
            return new List<string>();
        var tasks = _users[userId].IncompletedTasks;
        return tasks.Where(x => x.Tags.Contains(tag)).Select(x => x.TaskDescription).ToList();
    }

    public void CompleteTask(int userId, int taskId)
    {
        if (!_users.ContainsKey(userId) || !_tasks.ContainsKey(taskId))
            return;
        var user = _users[userId];
        var task = _tasks[taskId];
        if (user.IncompletedTasks.Contains(task))
        {
            user.IncompletedTasks.Remove(task);
        }
    }
}