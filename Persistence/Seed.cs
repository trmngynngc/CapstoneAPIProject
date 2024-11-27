using Domain;
using Domain.Image;
using Domain.Quiz;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class Seed
{
    public static SeedingConfig SeedingConfig { get; set; } = new SeedingConfig
    {
        SeedUsers = false,
        SeedQuizzes = false,
        SeedOrders = true
    };

    private static readonly Random _random = new();

    private static DataContext _context;
    private static UserManager<User> _userManager;

    private static List<Image> _images;
    private static List<Image> _avatars;

    private static List<User> _users;
    private static List<Category> _categories;
    private static List<Quiz> _quizzes;

    public static async Task SeedData(DataContext context, UserManager<User> userManager)
    {
        if (userManager.Users.Any()) return;

        _context = context;
        _userManager = userManager;

        _avatars = SeedImages("/assets/images/avatars", "avatar", 24);

        if (SeedingConfig.SeedUsers)
        {
            SeedUsers();
            SeedAvatars();
            CreateUsers();
        }

        if (SeedingConfig.SeedQuizzes)
        {
            SeedQuizzes();
            context.AttachRange(_categories);
            context.AttachRange(_quizzes);
        }

        context.AttachRange(_images);

        await context.SaveChangesAsync();
    }

    public static List<Image> SeedImages(string url, string name, int total)
    {
        var list = new List<Image>();
        for (var i = 1; i <= total; i++)
            list.Add(new Image
            {
                Url = url,
                Name = name + "_" + i,
                Extension = "jpg"
            });

        _images ??= new List<Image>();
        _images.AddRange(list);
        return list;
    }

    public static void SeedUsers()
    {
        _users = new List<User>
        {
            new()
            {
                Name = "Amos Blanda",
                UserName = "amos",
                Email = "amos@test.com",
                Address = "1 at fake street"
            },
            new()
            {
                Name = "Brent Goodwin",
                UserName = "brent",
                Email = "brent@test.com",
                Address = "2 at fake street"
            },
            new()
            {
                Name = "Carol Koss",
                UserName = "carol",
                Email = "carol@test.com",
                Address = "3 at fake street"
            }
        };
    }

    public static void SeedAvatars()
    {
        for (int i = 0, len = _users.Count; i < len; i++) _users[i].Avatar = _avatars[i + 1];
    }

    public static async void CreateUsers()
    {
        foreach (var user in _users)
        {
            await _userManager.CreateAsync(user, "Password_123");
        }

        await _context.SaveChangesAsync();
    }

    public static void SeedQuizzes()
    {
        SeedCategories();

        var names = new List<string>
        {
            "Nike Air Force 1 NDESTRUKT",
            "Nike Space Hippie 04",
            "Nike Air Zoom Pegasus 37 A.I.R. Chaz Bear",
            "Nike Blazer Low 77 Vintage",
            "Nike ZoomX SuperRep Surge",
            "Zoom Freak 2",
            "Nike Air Max Zephyr",
            "Jordan Delta",
            "Air Jordan XXXV PF",
            "Nike Waffle Racer Crater",
            "Kyrie 7 EP Sisterhood",
            "Nike Air Zoom BB NXT",
            "Nike Air Force 1 07 LX",
            "Nike Air Force 1 Shadow SE",
            "Nike Air Zoom Tempo NEXT",
            "Nike DBreak-Type",
            "Nike Air Max Up",
            "Nike Air Max 270 React ENG",
            "NikeCourt Royale",
            "Nike Air Zoom Pegasus 37 Premium",
            "Nike Air Zoom SuperRep",
            "NikeCourt Royale",
            "Nike React Art3mis",
            "Nike React Infinity Run Flyknit"
        };
        var desc =
            "The Air Force 1 NDSTRKT blends unbelievable comfort with head-turning style and street-ready toughness to create an \'indestructible\' feel. In a nod to traditional work boots, the timeless silhouette comes covered in rubber reinforcements in high-wear areas. Lace up for tough conditions with this hardy take on a lifestyle classic.\nIntroduced in 1982, the Air Force 1 redefined basketball footwear from the hardwood to the tarmac. It was the first basketball sneaker to house Nike Air, but its innovative nature has since taken a back seat to its status as a street icon.";

        _quizzes = new List<Quiz>();

        var start = new DateTime(2020, 1, 1);
        var range = (DateTime.Today - start).Days;

        for (int i = 0, len = names.Count; i < len; i++)
        {
            var quiz = new Quiz
            {
                Name = names[i],
                Price = new decimal(_random.NextDouble() * 200),
                Stocks = _random.Next(0, 20),
                Description = desc,
            };

            var ran = _random.Next(3);
            if (ran != 2)
            {
                quiz.Category = _categories[ran];
            }

            _quizzes.Add(quiz);
        }
    }

    public static void SeedCategories() {
        _categories = new List<Category>
        {
            new() { Name = "For Men" },
            new() { Name = "For Women" }
        };
    }
}

public class SeedingConfig
{
    public bool SeedUsers { get; set; }
    public bool SeedQuizzes { get; set; }
    public bool SeedOrders { get; set; }
}
