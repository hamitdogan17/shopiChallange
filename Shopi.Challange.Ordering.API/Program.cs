using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopi.Challange.Ordering.API.Core;
using Shopi.Challange.Ordering.Business.Behaviours;
using Shopi.Challange.Ordering.Business.Commands.AddNewOrders;
using Shopi.Challange.Ordering.Core.Repositories;
using Shopi.Challange.Ordering.Core.Repositories.Base;
using Shopi.Challange.Ordering.Data.EF;
using Shopi.Challange.Ordering.Data.Repositories;
using Shopi.Challange.Ordering.Data.Repositories.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
}); 
builder.Services.AddEfTemplateContext();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddMediatR(typeof(Handler).GetTypeInfo().Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<IValidator<Request>, AddOrderListRequestValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.MapControllers();

app.Run();