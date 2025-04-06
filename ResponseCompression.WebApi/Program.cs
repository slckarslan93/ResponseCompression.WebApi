var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => 
{
    List<int> numbers = new();
	for (int i = 0; i < 1000; i++)
	{
		numbers.Add(i);
	}

    return numbers;
});

app.Run();
