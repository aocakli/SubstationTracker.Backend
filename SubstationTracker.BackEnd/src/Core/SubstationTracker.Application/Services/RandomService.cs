using System.Text;

namespace SubstationTracker.Application.Services;

public class RandomService
{
    private readonly Random _random;

    public RandomService(Random random)
    {
        _random = random;
    }

    public string GenerateCode(int length)
    {
        StringBuilder sb = new();

        for (var i = 1; i <= length; i++)
        {
            var generatedChar = (char)_random.Next(65, 90);
            sb.Append(generatedChar);
        }

        return sb.ToString();
    }
}