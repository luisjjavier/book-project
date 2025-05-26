var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BookStore_Server>("bookstore-server");

builder.Build().Run();
