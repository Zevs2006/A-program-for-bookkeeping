using System.Collections.Generic;
using System.IO;
using A_program_for_bookkeeping;
using System.Xml;
using Newtonsoft.Json;

public class BookRepository
{
    private readonly string filePath = "books.json";

    public List<Book> LoadBooks()
    {
        if (!File.Exists(filePath))
        {
            return new List<Book>();
        }

        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Book>>(json);
    }

    public void SaveBooks(List<Book> books)
    {
        // Преобразуем список книг в JSON-строку
        string json = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);

        // Сохраняем JSON-строку в файл
        File.WriteAllText(filePath, json);
    }

}
