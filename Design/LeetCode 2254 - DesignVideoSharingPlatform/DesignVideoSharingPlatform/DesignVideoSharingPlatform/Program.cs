public class VideoSharingPlatform
{
    class Video
    {
        public int id;
        public string content;
        public int like;
        public int dislike;
        public int views;
        public Video(int id, string content)
        {
            this.id = id;
            this.content = content;
        }
    }

    private Dictionary<int, Video> videos;
    private int unusedId;
    private Queue<int> usedIds;
    public VideoSharingPlatform()
    {
        videos = new Dictionary<int, Video>();
        usedIds = new Queue<int>();
    }

    public int Upload(string video)
    {
        var id = usedIds.Count != 0 ? usedIds.Dequeue() : unusedId++;
        videos[id] = new Video(id, video);
        return id;
    }

    public void Remove(int videoId)
    {
        if (!videos.ContainsKey(videoId)) return;
        var video = videos[videoId];
        usedIds.Enqueue(videoId);
        videos.Remove(videoId);
    }

    public string Watch(int videoId, int startMinute, int endMinute)
    {
        if (!videos.ContainsKey(videoId)) return "-1";
        var video = videos[videoId];
        video.views++;
        return video.content.Substring(startMinute, Math.Min(endMinute, video.content.Length - 1) - startMinute + 1);
    }

    public void Like(int videoId)
    {
        if (!videos.ContainsKey(videoId)) return;
        videos[videoId].like++;
    }

    public void Dislike(int videoId)
    {
        if (!videos.ContainsKey(videoId)) return;
        videos[videoId].dislike++;
    }

    public int[] GetLikesAndDislikes(int videoId)
    {
        return videos.ContainsKey(videoId) ? new[] { videos[videoId].like, videos[videoId].dislike } : new[] { -1 };
    }

    public int GetViews(int videoId)
    {
        return videos.ContainsKey(videoId) ? videos[videoId].views : -1;
    }
}