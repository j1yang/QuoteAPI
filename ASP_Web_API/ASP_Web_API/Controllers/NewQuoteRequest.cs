﻿namespace ASP_Web_API.Controllers
{
    public class NewQuoteRequest
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public List<int> Tags { get; set; }
    }
}
