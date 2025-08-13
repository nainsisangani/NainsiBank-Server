using CommBank.Models;
using CommBank.Services;
using CommBank_Server.Models;
using CommBank_Server.Services;
using MongoDB.Driver;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Read MongoDB settings
builder.Services.Configure<CommBankDatabaseSettings>(
    builder.Configuration.GetSection("CommBankDatabase"));

var dbSettings = builder.Configuration
    .GetSection("CommBankDatabase")
    .Get<CommBankDatabaseSettings>();

// ✅ Create MongoClient with ServerApi + Timeout
var settings = MongoClientSettings.FromConnectionString(dbSettings.ConnectionString);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
settings.ServerSelectionTimeout = TimeSpan.FromSeconds(60);
var mongoClient = new MongoClient(settings);

// ✅ Ping test BEFORE app runs
try
{
    var result = mongoClient
        .GetDatabase("admin")
        .RunCommand<BsonDocument>(new BsonDocument("ping", 1));

    Console.WriteLine("✅ MongoDB ping succeeded.");
}
catch (Exception ex)
{
    Console.WriteLine("❌ MongoDB connection failed: " + ex.Message);
}

// Get the actual database
var mongoDatabase = mongoClient.GetDatabase(dbSettings.DatabaseName);

// Register services
builder.Services.AddSingleton<IAccountsService>(new AccountsService(mongoDatabase));
builder.Services.AddSingleton<IAuthService>(new AuthService(mongoDatabase));
builder.Services.AddSingleton<IGoalsService>(new GoalsService(mongoDatabase));
builder.Services.AddSingleton<ITagsService>(new TagsService(mongoDatabase));
builder.Services.AddSingleton<ITransactionsService>(new TransactionsService(mongoDatabase));
builder.Services.AddSingleton<IUsersService>(new UsersService(mongoDatabase));
builder.Services.AddSingleton<MongoDbService>();

// Controllers, Swagger, and CORS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS Setup
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ✅ Correct Middleware Order
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommBank API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.MapGet("/", () => "Welcome to the CommBank API! Visit /swagger to explore.");

app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
