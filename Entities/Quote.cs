using System;

namespace Entities
{
    public class Quote
    {
        public uint Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}