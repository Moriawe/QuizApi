using Quiz_API;
using Quiz_API.Adapters;
using Quiz_API.Persistance;
using Quiz_API.Repositories;
using Quiz_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Later: <Interface, ImplementingClass>
builder.Services.AddScoped<IQuizDatabaseContext, QuizDatabaseContext>();
builder.Services.AddScoped<QuestionRepository, QuestionRepository>();
builder.Services.AddScoped<QuestionAdapter, QuestionAdapter>();
builder.Services.AddScoped<QuestionService, QuestionService>();

builder.Services.AddScoped<QuizAdapter, QuizAdapter>();
builder.Services.AddScoped<QuizService, QuizService>();

builder.Services.AddScoped<AnswerRepository, AnswerRepository>();
builder.Services.AddScoped<AnswerService, AnswerService>();
builder.Services.AddScoped<TriviaAdapter, TriviaAdapter>();

















builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

