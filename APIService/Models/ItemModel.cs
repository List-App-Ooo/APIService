using System;

namespace APIService.Models
{
    public abstract class ItemModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid ListId { get; set; }
    }
}