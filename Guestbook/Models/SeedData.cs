using Microsoft.EntityFrameworkCore;

namespace Guestbook.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (GuestBookContext context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>()))
            {

                if (!context.Book.Any())
                {

                    string[] guid = { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

                    context.Book.AddRange(
                    new Book
                    {
                        BookID = guid[0],
                        Title = "你們有在冬天爬過山嗎?",
                        Description = "阿爾卑斯山日落時分，山脈被夕陽染成金黃色，景色壯觀。",
                        Author = "Joanna",
                        Photo = guid[0] + ".jpg",
                        CreateDate = DateTime.Now
                    },
                    new Book
                    {
                        BookID = guid[1],
                        Title = "獨自登山旅行者",
                        Description = "徒步旅行者站在草木茂盛的山脊上，凝視著遠方的廣闊翠綠的山谷。",
                        Author = "David",
                        Photo = guid[1] + ".jpg",
                        CreateDate = DateTime.Now
                    },
                    new Book
                    {
                        BookID = guid[2],
                        Title = "下龍灣的群島",
                        Description = "群島的壯麗全景，在陽光下閃耀著碧綠的水面，遠處的石灰岩山峰矗立在海面上，形成壯觀的景色。",
                        Photo = guid[2] + ".jpg",
                        Author = "Lily",
                        CreateDate = DateTime.Now

                    },
                    new Book
                    {
                        BookID = guid[3],
                        Title = "威尼斯大運河",
                        Description = "這是義大利威尼斯大運河的經典景觀，水道兩旁歷史建築林立，貢多拉在水面上穿梭，此生一定要來一趟。",
                        Photo = guid[3] + ".jpg",
                        Author = "Evon",
                        CreateDate = DateTime.Now
                    },
                    new Book
                    {
                        BookID = guid[4],
                        Title = "觀賞飛機",
                        Description = "本人比較喜歡靜態活動，看著一架飛機翱翔在蓬鬆白雲的湛藍天空中，感覺很放鬆。",
                        Photo = guid[4] + ".jpg",
                        Author = "Chris",
                        CreateDate = DateTime.Now
                    }

                );

                    context.SaveChanges();




                    context.Rebook.AddRange(

                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "我去年有去滑雪，冬天爬山要注意保暖，還有防滑裝備。",
                            Author = "Ben",
                            CreateDate = DateTime.Now,
                            BookID = guid[0]    //回覆第一筆留言
                        },
                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "我不喜歡。冬天爬山太冷了！我寧願在家裡喝熱可可。",
                            Author = "Nancy",
                            CreateDate = DateTime.Now,
                            BookID = guid[0]
                        },
                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "你這樣要準備多少裝備啊？",
                            Author = "Watson",
                            CreateDate = DateTime.Now,
                            BookID = guid[1]
                        },
                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "你好勇敢！我都不敢一個人去登山",
                            Author = "Mike",
                            CreateDate = DateTime.Now,
                            BookID = guid[1]
                        },
                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "我有去參加遊河活動，真的很棒！",
                            Author = "Gina",
                            CreateDate = DateTime.Now,
                            BookID = guid[2]
                        },

                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "這是威尼斯我最喜歡的地方",
                            Author = "Bob",
                            CreateDate = DateTime.Now,
                            BookID = guid[3]
                        },

                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "我上次去的時候，看到一個人從橋上掉下去了",
                            Author = "Mei",
                            CreateDate = DateTime.Now,
                            BookID = guid[3]
                        },

                        new Rebook
                        {
                            RebookID = Guid.NewGuid().ToString(),
                            Description = "你們都在哪裡拍攝的",
                            Author = "JACK",
                            CreateDate = DateTime.Now,
                            BookID = guid[4]
                        }


                        );

                    context.SaveChanges();

                    string SeedPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedPhotos");
                    string BookPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookPhotos");


                    string[] files = Directory.GetFiles(SeedPhotosPath);

                    for (int i = 0; i < files.Length; i++)
                    {
                        string destFile = Path.Combine(BookPhotosPath, guid[i] + ".jpg");


                        File.Copy(files[i], destFile);
                    }




                }
            }
            
        }

    }
}
