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

            // Create the Quote with associated tags
            Quote quote = new Quote()
            {
                Text = newQuoteRequest.Text,
                Author = newQuoteRequest.Author,
                TagAssignments = existingTags.Select(tag => new TagAssignment { Tag = tag }).ToList()
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
        .Include(t => t.TagAssignments)
        .ThenInclude(qt => qt.Quote)
        .FirstOrDefault(t => t.Name == name);

            if (tag == null)
            {
                return NotFound($"Tag with name '{name}' not found.");
            }

            List<QuoteDto> quotes = tag.TagAssignments
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
                .Include(q => q.TagAssignments)
                .ThenInclude(qt => qt.Tag)
                .FirstOrDefault(q => q.Id == id);

            if (quote == null)
            {
                return NotFound($"Quote with ID '{id}' not found.");
            }

            List<TagDto> tags = quote.TagAssignments
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
                .Include(q => q.TagAssignments)
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
            quote.TagAssignments.Clear();
            foreach (var tagId in quoteDto.Tags)
            {
                var tag = _quotesContext.Tags.Find(tagId);
                if (tag != null)
                {
                    quote.TagAssignments.Add(new TagAssignment { Tag = tag });
                }
            }

            _quotesContext.SaveChanges();

            return Ok(quote.TagAssignments);
        }

        [HttpPost("addNewTag")]
        public async Task<ActionResult<Tag>> AddNewTag(Tag newTag)
        {
            if (string.IsNullOrWhiteSpace(newTag.Name))
            {
                return BadRequest("Tag name cannot be empty.");
            }

            // Check if the tag with the same name already exists
            if (await _quotesContext.Tags.AnyAsync(t => t.Name == newTag.Name))
            {
                return BadRequest("Tag with the same name already exists.");
            }

            // Add the new tag to the database
            _quotesContext.Tags.Add(newTag);
            await _quotesContext.SaveChangesAsync();

            return Ok(newTag);
        }

        [HttpGet("Likes")]
        public IActionResult GetAllLikes()
        {
            List<Like> allLikes = _quotesContext.Likes.ToList();
            return Ok(allLikes);
        }

        [HttpPost("Like/{quoteId}")]
        public IActionResult LikeQuote(int quoteId)
        {
            var quote = _quotesContext.Quotes.Find(quoteId);

            if (quote == null)
            {
                return NotFound();
            }

            var like = new Like { QuoteId = quoteId };
            _quotesContext.Likes.Add(like);
            _quotesContext.SaveChanges();

            return Ok();
        }

        [HttpGet("/quotes/MostLiked")]
        public IActionResult GetMostLikedQuotes()
        {
            var mostLikedQuotes = _quotesContext.Quotes.OrderByDescending(q => q.Likes.Count).Take(10).ToList();
            return Ok(mostLikedQuotes);
        }

        [HttpGet("tags/search")]
        public ActionResult<IEnumerable<Tag>> Search([FromQuery] string query)
        {
            try
            {
                // Filter tags based on the search query
                var matchingTags = _quotesContext.Tags
                    .Where(tag => tag.Name.ToLower().Contains(query.ToLower()))
                    .ToList();

                return Ok(matchingTags);
            }
            catch (System.Exception ex)
            {
                // Log the exception in a real application
                return StatusCode(500, new { error = "Internal Server Error" });
            }
        }

    }
}
