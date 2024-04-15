using Blog2.Data;
using Blog2.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            using var context = new BlogDataContext();
            // var posts = context
            // .Posts
            // .AsNoTracking()
            // .Include(x => x.Author)
            // // .Where(x => x.AuthorId == 1)
            // .OrderByDescending(x => x.LastUpdateDate)
            // .ToList();

            // foreach (var post in posts)
            // {
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
            // }



            // context.Users.Add(new User
            // {
            //     Bio = "9x Microsof MVP",
            //     Email = "andre@balta.io",
            //     Image = "https://balta.io",
            //     Name = "André Baltieri",
            //     PasswordHash = "1234",
            //     Slug = "andre-baltieri"
            // });
            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();

            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Frontend",
                    Slug = "frontend"
                },
                CreateDate = DateTime.Now,
                // LastUpdateDate = 
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir",
                // Tags=null
                Title = "Meu artigo"
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}