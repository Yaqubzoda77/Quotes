namespace Infrustructure.Services;
using Domain.Models;
using Dapper;
using Npgsql;
public class QuoteServices
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=13577;";

  
    public List<Quote> GetQuotes()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM quotes ";
            var result = connection.Query<Quote>(sql);
            return result.ToList();
        }

    }
    
    public bool DeleteQuotesById(int  id)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"delete from Quotes where Id = {id}";
            var deleted = connection.Execute(sql);
            if (deleted > 0) return true;
            else return false;
        }
    }
    public bool UpdateQuotes(Quote quotes)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update Quotes set Author = '{quotes.Author}',  "+
                      $"QuoteText = '{quotes.QuoteText}',Category = '{quotes.Categoryid }' "+
                      $"where Id = {quotes.Id}";
            var updated = connection.Execute(sql);
            if (updated > 0) return true;
            else return false;
        }   
    }
    public List<Quote> GetAllQuotesByCategory(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = 
                $" select *"+
                $" from quotes q "+
                $" join Category c on c.id = q.categoryid " +
                $"where q.categoryid = {id};";
            var quotes = connection.Query<Quote>(sql);
            return quotes.ToList();
        }
    }
    public List<Quote> RandomQyotes()
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"select * from quotes order by random() limit 1;";
            var ByID = connection.Query<Quote>(sql);
            return ByID.ToList();
        }
    }
    
}
