using RestfulApi.Context;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Services;
using RestfulApi.IServices;
using Quartz;
using RestfulApi.Quartz;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(opt =>
    opt.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddQuartz(q => {
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Create a "key" for the job
    var jobKey = new JobKey("QuartzJob");
    // Register the job with the DI container
    q.AddJob<QuartzJob>(opts => opts.WithIdentity(jobKey));
    // Create a trigger for the job
    q.AddTrigger(opts => opts
        .ForJob(jobKey) // link to the HelloWorldJob
        .WithIdentity("QuartzJob-trigger") // give the trigger a unique name
        .WithCronSchedule("0/59 * * * * ?")); // run every 5 seconds
});

// ASP.NET Core hosting
builder.Services.AddQuartzServer(options =>
{
    // when shutting down we want jobs to complete gracefully
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UsePathBase(new PathString("/api"));

app.UseRouting();

app.Run();
