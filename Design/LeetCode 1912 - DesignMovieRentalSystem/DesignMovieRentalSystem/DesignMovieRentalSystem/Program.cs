var entries = new int[][]
{
    new[] { 0, 1, 5 },
    new[] { 0, 2, 6 },
    new[] { 0, 3, 7 },
    new[] { 1, 1, 4 },
    new[] { 1, 2, 7 },
    new[] { 2, 1, 5 },
};
var s = new MovieRentingSystem(3, entries);
Console.WriteLine(s.Search(1));
s.Rent(0, 1);
s.Rent(1, 2);
Console.WriteLine(s.Report());
s.Drop(1, 2);
Console.WriteLine(s.Search(2));


public class MovieRentingSystem
{
    class Movie : IComparable<Movie>
    {
        public int Shop { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }

        public Movie(int shop, int id, int price)
        {
            Shop = shop;
            Id = id;
            Price = price;
        }

        public int CompareTo(Movie? other)
        {
            if (other.Price == this.Price && other.Shop == this.Shop)
                return this.Id - other.Id;
            if (other.Price == this.Price)
                return this.Shop - other.Shop;
            return this.Price - other.Price;
        }
    }

    private Dictionary<int, SortedSet<Movie>> unrented;
    private SortedSet<Movie> rented;
    private Dictionary<string, Movie> dict;

    public MovieRentingSystem(int n, int[][] entries)
    {
        unrented = new Dictionary<int, SortedSet<Movie>>();
        rented = new SortedSet<Movie>();
        dict = new Dictionary<string, Movie>();
        foreach (var entry in entries)
        {
            int shop = entry[0], id = entry[1], price = entry[2];
            var movie = new Movie(shop, id, price);
            if (!unrented.ContainsKey(id))
                unrented[id] = new SortedSet<Movie>();
            unrented[id].Add(movie);
            var key = $"{shop}:{id}";
            dict[key] = movie;
        }
    }

    public IList<int> Search(int movie)
    {
        if (!unrented.ContainsKey(movie))
            return new List<int>();
        var movies = unrented[movie];
        var res = new List<int>();
        foreach (var m in movies)
        {
            if (res.Count == 5)
                return res;
            res.Add(m.Shop);
        }
        return res;
    }

    public void Rent(int shop, int movie)
    {
        var m = dict[$"{shop}:{movie}"];
        unrented[movie].Remove(m);
        rented.Add(m);
    }

    public void Drop(int shop, int movie)
    {
        var m = dict[$"{shop}:{movie}"];
        rented.Remove(m);
        unrented[movie].Add(m);
    }

    public IList<IList<int>> Report()
    {
        var res = new List<IList<int>>();
        foreach (var m in rented)
        {
            if (res.Count == 5)
                return res;
            res.Add(new List<int> { m.Shop, m.Id });
        }
        return res;
    }
}