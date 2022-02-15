using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using Fabrica.Models;

namespace EFPrueba
{
    class Program
    {
        static void CrearBD()
        {
            using (var db = new FabricaContext())
            {
                bool deleted = db.Database.EnsureDeleted();
                WriteLine($"Database deleted: {deleted}");
                bool created = db.Database.EnsureCreated();
                WriteLine($"Database created: {created}");
            }
        }
        static void CrearPedidosyTabla()
        {
            using (var db = new FabricaContext())
            {

                db.Pedido.RemoveRange(db.Pedido);
                db.Tela.RemoveRange(db.Tela);
                db.PedidoxTela.RemoveRange(db.PedidoxTela);
                db.SaveChanges();

                db.Pedido.AddRange(
                    new Pedido { PedidoId = 1,Cliente = "Maria", País="Colombia" },
                    new Pedido { PedidoId = 2,Cliente = "Maria", País="Turquia" },
                    new Pedido { PedidoId = 3,Cliente = "Ana", País="España" },
                    new Pedido { PedidoId = 4,Cliente = "Marcelo", País="Brasil" },
                    new Pedido { PedidoId = 5,Cliente = "Angel", País="Mexico" }
                    
                   
                );
                db.SaveChanges();

                db.Tela.AddRange(
                    new  Tela { TelaId = 10,Metros= 150, Tipo = "Seda" },
                    new  Tela { TelaId = 20,Metros= 200, Tipo = "Vaquera" },
                    new  Tela { TelaId = 30,Metros= 250, Tipo = "Hilo" },
                    new  Tela { TelaId = 40,Metros= 300, Tipo = "Satinado" },
                    new  Tela { TelaId = 50,Metros= 350, Tipo = "Algodòn" }
                    
                );
                db.SaveChanges();


                 db.PedidoxTela.AddRange(
                    new  PedidoxTela { PedidoId = 1, TelaId = 20, Cantidad = 50},
                    new  PedidoxTela { PedidoId = 1, TelaId = 10, Cantidad = 100},
                    new  PedidoxTela { PedidoId = 3, TelaId = 30, Cantidad = 30},
                    new  PedidoxTela { PedidoId = 3, TelaId = 50, Cantidad = 50},
                    new  PedidoxTela { PedidoId = 5, TelaId = 40, Cantidad = 200}
                
                );
                db.SaveChanges();


            }
        }


         static void Main(string[] args)
        {
            CrearBD();
            CrearPedidosyTabla();

        }
    }
        }
      
      /*
     VAR RESULT = await-context.Pedidos.Where(p => id == null ? true : p.Id== Id).GroupBy(pl => new {pl.cliente, pl.Pedido}).Select(g => new{
         pedido = g.Key.Pedido,
         Cliente = g.Key.Cliente,
         TotalPedido = g.Sum(pl => pl.TotalLinea)
     })

      */