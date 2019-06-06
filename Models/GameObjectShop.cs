using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class GameObjectShop
    {
        public int Id { get; set; }
        public int GameObjectId { get; set; }
        public Shop Shop { get; set; }
        public double Price { get; set; }
    }
}
