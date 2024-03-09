using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    public class Book : INotifyPropertyChanged
    {
        public string? Name {  get; set; }

        public string? CoverImage { get; set; }

        public string? Author { get; set; }

        public int PublishedYear { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
