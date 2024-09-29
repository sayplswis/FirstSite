using MyNotes.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);  // ������� ��� IP �� ����� 80
});


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<NotesDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://sayplswis.ru");
       // policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();
using var scope = app.Services.CreateScope();
using var dbContex= scope.ServiceProvider.GetRequiredService<NotesDbContext>();
await dbContex.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.MapControllers();

app.Run();
