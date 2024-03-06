using EShop.Infrastructure;
using EShop.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Scan(selector => selector
.FromAssemblies(
    typeof(EShop.Infrastructure.AssemblyReference).Assembly
    ).AddClasses(false)
    .AsImplementedInterfaces()
    .WithScopedLifetime());
builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(EShop.Application.AssemblyReference).Assembly);
});
builder.Services.AddSingleton<ConvertDomainEventToOutboxMessagesInterceptor>();
string connectionString = builder.Configuration.GetConnectionString("eShopConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>((sp, opt) =>
{
    var interceptor = sp.GetRequiredService<ConvertDomainEventToOutboxMessagesInterceptor>();
    opt.UseNpgsql(connectionString).AddInterceptors(interceptor);
});
builder.Services.AddControllers().AddApplicationPart(typeof(EShop.Application.AssemblyReference).Assembly);
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
