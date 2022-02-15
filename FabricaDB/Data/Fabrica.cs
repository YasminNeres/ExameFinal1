using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fabrica.Models
{
    public class Pedido
    {
        //Clave Principal 
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PedidoId { get; set; }
        public string Cliente { get; set; }
        public string País { get; set; }


     //Propiedades de navegaciòn
        [JsonIgnore]
        public List<PedidoxTela> LineasPedido {get;} = new List<PedidoxTela>();
    }
    public class Tela
    {
        //Clave Principal 
         [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TelaId { get; set; }
        public decimal Metros { get; set; }
        public string Tipo { get; set; }

         //Propiedades de navegaciòn

        [JsonIgnore]
         public List<PedidoxTela> LineasTela{get;} = new List<PedidoxTela>();

    }
    public class PedidoxTela
    {     
       [Key]
       public int ID {get;set;}
       public int PedidoId {get;set;}   
       public int  TelaId {get;set;}
       public int Cantidad { get; set; }


  //Propiedades de navegaciòn
         [JsonIgnore]
         public Tela Tela {get;set;}
         public Pedido Pedido {get;set;}

     


    }

}