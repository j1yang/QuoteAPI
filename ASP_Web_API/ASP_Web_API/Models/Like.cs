﻿namespace ASP_Web_API.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }
    }
}
