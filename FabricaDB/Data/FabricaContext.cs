
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fabrica.Models;

public class FabricaContext : DbContext
{
    public static string connString { get; private set; } 

    public FabricaContext()
    {
        var database = "DB08Yasmin"; 
        connString = $"Server=185.60.40.210\\SQLEXPRESS,58015;Database={database};User Id=sa;Password=Pa88word;MultipleActiveResultSets=true";
        //connString = $"Server=(localdb)\\mssqllocaldb;Database=EFE8Yasmin;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connString);



    //public CryptoContext(DbContextOptions<CryptoContext> options) : base(options) { }
    //public CryptoContext() : base() { }
    
    public DbSet<Fabrica.Models.Pedido> Pedido { get; set; }
    public DbSet<Fabrica.Models.Tela> Tela { get; set; }
    public DbSet<Fabrica.Models.PedidoxTela> PedidoxTela { get; set; }

}
