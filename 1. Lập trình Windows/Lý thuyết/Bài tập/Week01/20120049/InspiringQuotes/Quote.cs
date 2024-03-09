using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspiringQuotes
{
    class Quote
    {
        private string quote;
        private string image;

        public string getQuote()
        {
            return quote;
        }

        public string getImage()
        {
            return image;
        }

        public Quote()
        {
            quote = "";
            image = "";
        }

        public Quote(string quote, string image)
        {
            this.quote = quote;
            this.image = image;
        }
    }
}
