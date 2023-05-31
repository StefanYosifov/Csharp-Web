namespace ForumApp.Data.Data.Seeder
{
    using Models;

    public class PostSeeder
    {
        public ICollection<Post> GeneratePosts()
        {
            ICollection<Post> posts=new List<Post>();

            Post post = new Post()
            {
                Id = 1,
                Title = "Razboinicite ot selo sliven",
                Content = "Pesho i Gosho igraqt navunka i palqt gumi",
            };

            posts.Add(post);

            Post post2 = new Post()
            {
                Id = 2,
                Title = "Razboinicite ot kvartala",
                Content = "Piqt, pushat i rejat gumi",
            };

            posts.Add(post2);

            Post post3 = new Post()
            {
                Id = 3,
                Title = "Lorem ipsum title man",
                Content = "This is the newest version of lorem ipsum 30"
            };
            
            posts.Add(post3);

            return posts;
        }
    }
}
