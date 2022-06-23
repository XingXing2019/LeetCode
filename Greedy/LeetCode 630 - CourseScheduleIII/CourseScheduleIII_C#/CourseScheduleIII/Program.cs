int ScheduleCourse(int[][] courses)
{
    var selectedCourses = new PriorityQueue<int, int>();
    Array.Sort(courses, (a, b) => a[1] - b[1]);
    var curDay = 0;
    foreach (var course in courses)
    {
        if (curDay + course[0] <= course[1])
        {
            selectedCourses.Enqueue(course[0], -course[0]);
            curDay += course[0];
        }
        else if (selectedCourses.Count != 0 && course[0] < selectedCourses.Peek())
        {
            curDay -= selectedCourses.Dequeue() - course[0];
            selectedCourses.Enqueue(course[0], -course[0]);
        }
    }
    return selectedCourses.Count;
}
