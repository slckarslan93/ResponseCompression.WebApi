using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
	options.Providers.Add<BrotliCompressionProvider>(); //Default ve hizli guclu
	//options.Providers.Add<GzipCompressionProvider>(); //eski browserlar için
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    //options.Level = System.IO.Compression.CompressionLevel.Optimal; 
    options.Level = System.IO.Compression.CompressionLevel.Fastest; 
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseResponseCompression();

app.MapGet("getList", () => 
{
    List<int> numbers = new();
	for (int i = 0; i < 1000; i++)
	{
		numbers.Add(i);
	}

    return numbers;
});

app.Run();
