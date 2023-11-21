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

        //get quotes
        [HttpGet("/quotes")]
        public IActionResult GetAllQuotes()
        {
            List<Quote> quotes = _quotesContext.Quotes
                                 .ToList();
            return Ok(quotes);
        }

        //get tags
        [HttpGet("/tags")]
        public IActionResult GetTags()
        {
            List<Tag> tags = _quotesContext.Tags.ToList();
            return Ok(tags);
        }

        //add new quote to db
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


        //get quote by id
        [HttpGet("/quotes/{id}")]
        public IActionResult GetQuoteById(int id)
        {
            Quote quote = _quotesContext.Quotes.FirstOrDefault(t => t.Id == id);

            return Ok(quote);
        }

        //get quote by tag
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

        //get tag by quote id
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

        //edit quote
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

        //add new tags
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

        //get all likes
        [HttpGet("Likes")]
        public IActionResult GetAllLikes()
        {
            List<Like> allLikes = _quotesContext.Likes.ToList();
            return Ok(allLikes);
        }

        //like association from user
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

        //ten quotes most liked likes
        [HttpGet("/quotes/MostLiked")]
        public IActionResult GetMostLikedQuotes()
        {
            var mostLikedQuotes = _quotesContext.Quotes.OrderByDescending(q => q.Likes.Count).Take(10).ToList();
            return Ok(mostLikedQuotes);
        }

        //ten quotes least liked likes
        [HttpGet("/quotes/LeastLiked")]
        public IActionResult GetLeastLikedQuotes()
        {
            var leastLikedQuotes = _quotesContext.Quotes.OrderBy(q => q.Likes.Count).Take(10).ToList();
            return Ok(leastLikedQuotes);
        }

        //GET quotes that more than 15 likes
        [HttpGet("/quotes/15pluslike")]
        public IActionResult Get15PlusLikedQuotes()
        {
            var LikedQuotes = _quotesContext.Quotes
                .Where(q => q.Likes.Count > 15)
                .OrderBy(q => q.Likes.Count)
                .Take(10)
                .ToList();

            return Ok(LikedQuotes);
        }

        //Tag serach query but i've implemented this feature in frontend side.
        [HttpGet("tags/search")]
        public ActionResult<IEnumerable<Tag>> Search([FromQuery] string query)
        {
            var matchingTags = _quotesContext.Tags
                    .Where(tag => tag.Name.ToLower().Contains(query.ToLower()))
                    .ToList();

            return Ok(matchingTags);
        }

    }
}
