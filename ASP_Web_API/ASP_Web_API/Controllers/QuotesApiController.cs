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

            // Retrieve existing tags from the database
            List<Tag> existingTags = _quotesContext.Tags
                   .Where(t => newQuoteRequest.Tags.Contains(t.Id))
                   .ToList();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(existingTags);

            //// Check if any requested tags are not found
            //if (existingTags.Count != newQuoteRequest.Tags.Count)
            //{
            //    return BadRequest("One or more tags not found.");
            //}

            // Create the Quote with associated tags
            Quote quote = new Quote()
            {
                Text = newQuoteRequest.Text,
                Author = newQuoteRequest.Author,
                QuoteTags = existingTags.Select(tag => new QuoteTag { Tag = tag }).ToList()
            };

            // Add and save the new quote
            _quotesContext.Quotes.Add(quote);
            _quotesContext.SaveChanges();

            return Ok(existingTags);
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

        [HttpGet("/tags/quote={id}")]
        public IActionResult GetTagByQuoteId(int id)
        {
            Quote quote = _quotesContext.Quotes
                .Include(q => q.QuoteTags)
                .ThenInclude(qt => qt.Tag)
                .FirstOrDefault(q => q.Id == id);

            if (quote == null)
            {
                return NotFound($"Quote with ID '{id}' not found.");
            }

            List<TagDto> tags = quote.QuoteTags
                .Select(qt => new TagDto
                {
                    Id = qt.Tag.Id,
                    Name = qt.Tag.Name
                })
                .ToList();

            return Ok(tags);
        }
        [HttpPut("quotes/edit/{id}")]
        public IActionResult EditQuote(int id, [FromBody] EditedQuoteDto quoteDto)
        {
            if (id != quoteDto.Id)
            {
                return BadRequest("Mismatched IDs.");
            }

            var quote = _quotesContext.Quotes
                .Include(q => q.QuoteTags)
                .ThenInclude(qt => qt.Tag)
                .FirstOrDefault(q => q.Id == id);

            if (quote == null)
            {
                return NotFound();
            }

            // Update quote properties
            quote.Text = quoteDto.Text;
            quote.Author = quoteDto.Author;

            // Update associated tags
            quote.QuoteTags.Clear();
            foreach (var tagId in quoteDto.Tags)
            {
                var tag = _quotesContext.Tags.Find(tagId);
                if (tag != null)
                {
                    quote.QuoteTags.Add(new QuoteTag { Tag = tag });
                }
            }

            _quotesContext.SaveChanges();

            return Ok(quote.QuoteTags);
        }

    }
}
