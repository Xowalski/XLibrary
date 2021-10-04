﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace XLibrary.Core.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        [DisplayName ("PublicationYear Year")]
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        [DisplayName ("Is avaible")]
        public bool IsAvaible { get; set; }

        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}