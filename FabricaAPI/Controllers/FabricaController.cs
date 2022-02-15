using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FabricaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabricaController : ControllerBase
    {
      
         private readonly FabricaContext db;

    
        private readonly ILogger<FabricaController> _logger;

        public FabricaController(ILogger<FabricaController> logger, FabricaContext context)
        {
            _logger = logger;
                        db = context;

        }


             [HttpGet("/Query1/")]
        public ActionResult Item1()
        {


            //Consultar TotalMetros x Pedido de todos
            var list=db
                .Pedido
                .SelectMany(p =>p.LineasPedido,(p,pt) =>new{
                Pedido =p.PedidoId,
                Cliente =p.Cliente,
                totalMetros = pt.Cantidad * pt.Tela.Metros

           
            })
            .ToList();
      

            return Ok(new
            {
                Descripcion = "Total de Metros * Pedido de todos los clientes",
                Valores = list,
            });

        }


         [HttpGet("/Query2/")]
        public ActionResult Item2()
        {


            //Consultar TotalMetrosxPedido de todos
            var list=db
                .Pedido
                .SelectMany(p =>p.LineasPedido,(p,pt) =>new{
                Pedido =p.PedidoId,
                Cliente =p.Cliente,
                totalMetros = pt.Cantidad * pt.Tela.Metros


          //Consultar TotalMetrosxCliente
            })
            .GroupBy(mp => new{mp.Pedido, mp.Cliente})
             .Select(g => new{
                    pedido = g.Key.Pedido, 
                    cliente =g.Key.Cliente,
                    totalPedido =g.Sum(mp => mp.totalMetros),
            })
            .ToList();
      

            return Ok(new
            {
                Descripcion = "Total de Metros * Cliente y la cantidad total",
                Valores = list,
            });

        }

    }
}
