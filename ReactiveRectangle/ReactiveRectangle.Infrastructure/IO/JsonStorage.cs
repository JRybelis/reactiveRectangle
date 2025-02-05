using System.Text.Json;
using ReactiveRectangle.Infrastructure.Interfaces;

namespace ReactiveRectangle.Infrastructure.IO;

public class JsonStorage : IJsonStorage
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public JsonStorage(string filePath)
    {
        _filePath = filePath;
    }
    
    public async Task<T?> ReadAsync<T>()
    {
        await _semaphore.WaitAsync();
        try
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task WriteAsync<T>(T value)
    {
        await _semaphore.WaitAsync();
        try
        {
            var json = JsonSerializer.Serialize(value);
            await File.WriteAllTextAsync(_filePath, json);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}