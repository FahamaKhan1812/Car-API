using System;
using System.Collections.Generic;

#nullable disable

namespace CARAPI.Models
{
    public partial class Picture
    {
        public int PicturesId { get; set; }
        public int CarId { get; set; }
        public string Path { get; set; }
    }
}
