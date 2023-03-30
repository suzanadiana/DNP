using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";

    private DataContainer? dataContainer;
    //
    // public ICollection<Todo> Todos
    // {
    //     get
    //     {
    //         LazyLoadData();
    //         return dataContainer!.Todos;
    //     }
    // }

    public ICollection<User> Users
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Users;
        }
    }

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;
        
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                // Todos = new List<Todo>(),
                Users = new List<User>()
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}