namespace ReactiveRectangle.Infrastructure.Interfaces;

public interface IJsonStorage
{
    Task<T?> ReadAsync<T>();
    Task WriteAsync<T>(T value);
}