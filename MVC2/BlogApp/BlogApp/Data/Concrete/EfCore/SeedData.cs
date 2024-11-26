using Microsoft.EntityFrameworkCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(!context.Tags.Any()){//tag de herhangi bir kayıt yoksa
                    context.Tags.AddRange(
                        new Tag{Text = "web programlama", Url ="wep-programlama", Color=TagColors.warning},
                        new Tag{Text = "backend", Url="backend", Color = TagColors.info},
                        new Tag{Text = "frontend", Url="frontend", Color = TagColors.success},
                        new Tag{Text = "fullstack", Url="fullstack", Color = TagColors.primary},
                        new Tag{Text = "php", Url="php", Color = TagColors.secondary}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName = "hakandemir", Name = "Hakan Demir", Email = "hakan@hakan.com", Password="123456", Image="boy.png"},
                        new User{UserName = "huseyin", Name = "Hüseyin Karakullukcu", Email = "huseyin@huseyin.com", Password="123456", Image="man.png"},
                        new User{UserName = "ahmet", Name = "Ahmet Yılmaz", Email = "ahmet@ahmet.com", Password="123456", Image="profile.png"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any()){
                    context.AddRange(
                        new Post{
                            Title = "AspNet Core",
                            Content = "AspNet Core dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            Url="aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment>
                            {
                                new Comment{CommentText = "İyi bir kurs", PublishedOn= DateTime.Now.AddDays(-20), UserId = 1},
                                new Comment{CommentText = "Çok faydalı bir kurs", PublishedOn= DateTime.Now.AddDays(-30), UserId = 2}
                            }
                        },
                        new Post{
                            Title = "Php",
                            Content = "Php dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            IsActive = true,
                            Url = "php",
                            PublishedOn = DateTime.Now.AddDays(-55),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "2.jpg",
                            UserId = 2,
                        },
                        new Post{
                            Title = "Django",
                            Content = "Django dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            Url = "django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-45),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2,
                        },
                        new Post{
                            Title = "React",
                            Content = "React dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            Url = "react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-35),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "1.jpg",
                            UserId = 2,
                        },
                        new Post{
                            Title = "Angular",
                            Content = "Angular dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            Url = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "2.jpg",
                            UserId = 2,
                        },
                        new Post{
                            Title = "Web Tasarım",
                            Content = "Web tasarım dersleri, The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                            Url = "web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 1,
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}