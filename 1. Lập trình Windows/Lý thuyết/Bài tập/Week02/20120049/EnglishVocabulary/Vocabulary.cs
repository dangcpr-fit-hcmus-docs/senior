using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVocabulary
{
    class Vocabulary
    {
        private string vocab;
        private string image;

        public string getVocab()
        {
            return vocab;
        }

        public string getImage()
        {
            return image;
        }

        public Vocabulary()
        {
            vocab = "";
            image = "";
        }

        public Vocabulary(string vocab, string image)
        {
            this.vocab = vocab;
            this.image = image;
        }
    }
}
