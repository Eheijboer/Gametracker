using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GameObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public Shop Shop { get; set; }
        public ObjectType ObjectType { get; set; }
        public Device Device { get; set; }
        public List<GameObjectShop> GameObjectShop { get; set; }
    }
    public enum Status
    {
        Tobuy, Purchased, Sold
    }
    public enum ObjectType
    {
        Accessory, Game
    }
}
