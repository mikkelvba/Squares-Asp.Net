using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Squares.Models;
using System.ComponentModel.DataAnnotations;

namespace Squares.Areas.Users.ViewModels
{
    public class SetViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public IEnumerable<Piece> imgURL_full { get; set; }
    }
}