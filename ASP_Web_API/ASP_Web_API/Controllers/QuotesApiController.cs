using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_Web_API.Models;

namespace ASP_Web_API.Controllers
{
    // Annotate this with the Api controller attr:
    [ApiController()]
    public class QuotesApiController : Controller
    {
        private QuotesContext _quotesContext;
        public QuotesApiController(QuotesContext quotesContext)
        {
            _quotesContext = quotesContext;
        }

        [HttpGet("/quotes")]
        public IActionResult GetAllQuotes()
        {
            List<Quote> quotes = _quotesContext.Quotes
                                 .ToList();
            return Ok(quotes);
        }
        [HttpGet("/tags")]
        public IActionResult GetTags()
        {
            List<Tag> tags = _quotesContext.Tags.ToList();
            return Ok(tags);
        }
        [HttpPost("/addNewQuote")]
        public IActionResult AddNewQuote([FromBody] NewQuoteRequest newQuoteRequest)
        {
            Tag tag = _quotesContext.Tags.Where(t=>t.Name == newQuoteRequest.Tag).FirstOrDefault();

            Quote quote = new Quote()
            {
                Text = newQuoteRequest.Text,
                Author = newQuoteRequest.Author,
                QuoteTags = new List<QuoteTag> { new QuoteTag { Tag = tag } }
            };

            _quotesContext.Quotes.Add(quote);
            _quotesContext.SaveChanges();

            return Ok(newQuoteRequest);
        }
    }
}
