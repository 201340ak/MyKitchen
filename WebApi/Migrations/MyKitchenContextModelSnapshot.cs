﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyKitchen.Models;

namespace MyKitchen.Migrations
{
    [DbContext(typeof(MyKitchenContext))]
    partial class MyKitchenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyKitchen.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("MyKitchen.Models.FoodUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodID");

                    b.Property<int>("UnitID");

                    b.HasKey("Id");

                    b.HasIndex("FoodID");

                    b.HasIndex("UnitID");

                    b.ToTable("FoodUnit");
                });

            modelBuilder.Entity("MyKitchen.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodId");

                    b.Property<decimal>("Quantity");

                    b.Property<int>("RecipeId");

                    b.Property<int>("SelectedUnitId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("SelectedUnitId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MyKitchen.Models.InventoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodId");

                    b.Property<decimal>("Quantity");

                    b.Property<int>("SelectedUnitId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("SelectedUnitId");

                    b.HasIndex("UserId");

                    b.ToTable("InventoryEntry");
                });

            modelBuilder.Entity("MyKitchen.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("MyKitchen.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<string>("PluralName");

                    b.Property<string>("SingularName");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("MyKitchen.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyKitchen.Models.FoodUnit", b =>
                {
                    b.HasOne("MyKitchen.Models.Food", "Food")
                        .WithMany("AvailableFoodUnits")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyKitchen.Models.Unit", "Unit")
                        .WithMany("FoodUnits")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyKitchen.Models.Ingredient", b =>
                {
                    b.HasOne("MyKitchen.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyKitchen.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyKitchen.Models.Unit", "SelectedUnit")
                        .WithMany()
                        .HasForeignKey("SelectedUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyKitchen.Models.InventoryEntry", b =>
                {
                    b.HasOne("MyKitchen.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyKitchen.Models.Unit", "SelectedUnit")
                        .WithMany()
                        .HasForeignKey("SelectedUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyKitchen.Models.User", "User")
                        .WithMany("Inventory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyKitchen.Models.Recipe", b =>
                {
                    b.HasOne("MyKitchen.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
