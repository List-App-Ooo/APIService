using System;
using System.Collections.Generic;

namespace APIService.Models
{
    public class ListUIModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public int TotalItems { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}