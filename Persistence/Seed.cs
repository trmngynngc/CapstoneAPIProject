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
                Name = "Admin User",
                UserName = "admin",
                Email = "admin@test.com",
                Address = "123 Admin Lane, Cityville",
                Bio = "Administrator with full access."
            },
            new()
            {
                Name = "John Doe",
                UserName = "johndoe",
                Email = "johndoe@test.com",
                Address = "456 Test Street, Test City",
                Bio = "Aspiring IELTS student preparing for university admission."
            },
            new()
            {
                Name = "Jane Smith",
                UserName = "janesmith",
                Email = "janesmith@test.com",
                Address = "789 Example Blvd, Example City",
                Bio = "Language enthusiast and IELTS candidate."
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

        var titles = new List<string>
        {
            "IELTS Reading Test 1",
            "IELTS Reading Test 2",
            "IELTS Listening Test 1",
            "IELTS Listening Test 2"
        };

        _quizzes = new List<Quiz>();

        var questionsData = new List<(string QuestionText, string CorrectAnswer)>
        {
            ("What is the main idea of the passage?", "The main idea is about the evolution of the internet."),
            ("What did the speaker mention about climate change?", "The speaker discussed the consequences of climate change."),
            ("In the passage, what is the correct answer regarding renewable energy?", "Renewable energy is crucial for reducing carbon emissions."),
            ("What did the speaker emphasize about new technologies?", "The speaker highlighted the rapid pace of technological development.")
        };

        var start = new DateTime(2020, 1, 1);
        var range = (DateTime.Today - start).Days;

        for (int i = 0, len = titles.Count; i < len; i++)
        {
            var quiz = new Quiz
            {
                Title = titles[i],
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Category = _categories[i % _categories.Count]
            };

            // Create questions for each quiz
            var questions = new List<Question>();
            foreach (var questionData in questionsData)
            {
                var question = new Question
                {
                    QuestionText = questionData.QuestionText,
                    CorrectAnswer = questionData.CorrectAnswer,
                    Quiz = quiz
                };

                questions.Add(question);
            }

            quiz.Questions = questions;

            _quizzes.Add(quiz);
        }
    }

    public static void SeedCategories() {
        _categories = new List<Category>
        {
            new() { Name = "Reading" },
            new() { Name = "Listening" }
        };
    }
}

public class SeedingConfig
{
    public bool SeedUsers { get; set; }
    public bool SeedQuizzes { get; set; }
}
