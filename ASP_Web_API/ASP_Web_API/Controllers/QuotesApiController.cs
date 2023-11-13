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
            // Check if Text is null or empty
            if (string.IsNullOrWhiteSpace(newQuoteRequest.Text))
            {
                return BadRequest("Text cannot be null or empty.");
            }

            Tag tag = _quotesContext.Tags.FirstOrDefault(t => t.Name == newQuoteRequest.Tag);
            if (tag == null)
            {
                return BadRequest("Tag not found.");
            }

            // Create the Quote
            Quote quote = new Quote()
            {
                Text = newQuoteRequest.Text,
                Author = newQuoteRequest.Author,
                QuoteTags = new List<QuoteTag> { new QuoteTag { Tag = tag } }
            };

            // Add and save the new quote
            _quotesContext.Quotes.Add(quote);
            _quotesContext.SaveChanges();

            return Ok(newQuoteRequest);
        }


        [HttpGet("/quotes/{id}")]
        public IActionResult GetQuoteById(int id)
        {
            Quote quote = _quotesContext.Quotes.FirstOrDefault(t => t.Id == id);

            return Ok(quote);
        }
        [HttpGet("/quotes/tag={name}")]
        public IActionResult GetQuoteByTag(string name)
        {
            Tag tag = _quotesContext.Tags
        .Include(t => t.QuoteTags)
        .ThenInclude(qt => qt.Quote)
        .FirstOrDefault(t => t.Name == name);

            if (tag == null)
            {
                return NotFound($"Tag with name '{name}' not found.");
            }

            List<QuoteDto> quotes = tag.QuoteTags
                .Select(qt => new QuoteDto
                {
                    Id = qt.Quote.Id,
                    Text = qt.Quote.Text,
                    Author = qt.Quote.Author
                    // Add more properties as needed
                })
                .ToList();

            return Ok(quotes);
        }
    }
}
