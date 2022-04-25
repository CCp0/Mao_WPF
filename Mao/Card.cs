using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class Card
    {
            public string CardName { get; set; }
            public string CardFace { get; set; }
            public string CardSuit { get; set; }
            public int CardValue { get; set; }

        public override string ToString()
        {
            return $"{CardName}";
        }
    }
    }
