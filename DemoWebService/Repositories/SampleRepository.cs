using Dapper;

using DemoWebService.Database;
using DemoWebService.Entities;

namespace DemoWebService.Repositories;

public class SampleRepository 
{
    private readonly DatabaseContext _context;

    public SampleRepository(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public async Task<IEnumerable<Sample>> GetSamples()
    {
        var query = "SELECT * FROM Samples";

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryAsync<Sample>(query);
        }
    }

    public async Task<Sample> CreateSample(Sample sample)
    {
        var query = "INSERT INTO Samples (Value) VALUES(@Value); SELECT LAST_INSERT_ID();";

        using (var connection = _context.CreateConnection())
        {
            sample.Id = await connection.QuerySingleAsync<int>(query, new { sample.Value });

            return sample;
        }
    }

    public async Task<Sample?> GetSampleById(int id)
    {
        var query = "SELECT * FROM Samples WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<Sample>(query, new { Id = id });
        }
    }
}
