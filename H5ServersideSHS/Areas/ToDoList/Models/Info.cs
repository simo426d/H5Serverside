using System;
using System.Collections.Generic;

#nullable disable

namespace H5ServersideSHS.Areas.ToDoList.Models
{
    public partial class Info
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
    }
}
