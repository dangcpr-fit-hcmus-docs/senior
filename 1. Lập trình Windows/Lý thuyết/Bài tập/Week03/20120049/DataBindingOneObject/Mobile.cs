using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingOneObject
{
    public class Mobile : INotifyPropertyChanged
    {
        public string? PhoneName { get; set; }

        public string? Image {  get; set; }

        public string? Manufacturer { get; set; }

        public float? Price { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
