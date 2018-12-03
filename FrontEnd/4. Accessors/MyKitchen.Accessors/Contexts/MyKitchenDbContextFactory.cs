using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyKitchen.Accessors.Contexts;

public class MyKitchenDbContextFactory : IDesignTimeDbContextFactory<MyKitchenDbContext>
{

    public MyKitchenDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyKitchenDbContext>();
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=MyKitchen;Trusted_Connection=True;");

        return new MyKitchenDbContext(optionsBuilder.Options);
    }
}