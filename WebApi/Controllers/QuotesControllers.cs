using Domain.Models;
using Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class QuotesControllers :ControllerBase
{
    private QuoteServices _quoteServices;

    public QuotesControllers()
    {
        _quoteServices = new QuoteServices();
    }

    [HttpGet("GetQuotes")]
    public List<Quote> GetQuotes()
    {
    return  _quoteServices.GetQuotes();
      
    }
    [HttpPut("Update")]
    public bool UpdateQuotes(Quote quote)
    {
        return  _quoteServices.UpdateQuotes(quote);
      
    }
    [HttpPut("GEtALLQuotestBYID")]
    public List<Quote> GetAllQuotesByCategory(int id)
    {
        return  _quoteServices.GetAllQuotesByCategory(id);
      
    }
    
    [HttpPut("Random")]
    public List<Quote> RandomQyotes()
    {
        return  _quoteServices.RandomQyotes();
      
    }
     
}