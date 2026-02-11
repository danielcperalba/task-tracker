using System.Net.Http.Headers;
using System.Text.Json;
using Name;

namespace TaskTrackerCLI
{
    public class TaskManager
    {
        private const string FileName = "tasks.json";
        private List<TaskItem> tasks;

        public TaskManager()
        {
            tasks = LoadTasks();
        }

        //Obtendo tarefas do arquivo JSON
        private List<TaskItem> LoadTasks()
        {
            if(!File.Exists(FileName))
            {
                return new List<TaskItem>();
            }

            try
            {
                string jsonContent = File.ReadAllText(FileName);

                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    return new List<TaskItem>();
                }

                var loadedTasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonContent);
                return loadedTasks ?? new List<TaskItem>();
            }
            catch(JsonException ex)
            {
                Console.WriteLine($"Erro ao ler arquivo JSON: {ex.Message}");
                return new List<TaskItem>();
            }
        }

        private void SaveTasks()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true //deixando o json formatado e legível
                };

                string jsonContent = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(FileName, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar tarefas: {ex.Message}");
            }
        }

        public void AddTask(string description)
        {
            int newId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;

            var newTask = new TaskItem
            {
                Id = newId,
                Description =  description,
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            tasks.Add(newTask);
            SaveTasks();

            Console.WriteLine($"Task adicionada com sucesso (ID: {newId})");
        }

        public void UpdateTask(int id, string newDescription)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Erro: Tarefa com ID {id} não encontrada.");
                return;
            }

            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            SaveTasks();

            Console.WriteLine($"Task {id} updated successfully.");
        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Erro: Tarefa com ID {id} não encontrada.");
                return;
            }

            tasks.Remove(task);
            SaveTasks();

            Console.WriteLine($"Task {id} deleted successfully.");
        }

        public void MarkInProgress(int id)
        {
            UpdateTaskStatus(id, "in-progress");
        }

        public void MarkDone(int id)
        {
            UpdateTaskStatus(id, "done");
        }

        private void UpdateTaskStatus(int id, string status)
        {
            var task = tasks. FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Erro: Tarefa com ID {id} não encontrada.");
                return;
            }

            task.Status = status;
            task.UpdatedAt =  DateTime.Now;
            SaveTasks();

            Console.WriteLine($"Task {id} marked as {status}");
        }

        public void ListAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var task in tasks)
            {
                PrintTask(task);
            }
        }

        public void ListTasksByStatus(string status)
        {
            var filteredTasks = tasks.Where(t => t.Status == status).ToList();

            if (filteredTasks.Count == 0)
            {
                Console.WriteLine($"Nenhuma tarefa com status '{status}' encontrada.");
                return;
            }

            foreach (var task in filteredTasks)
            {
                PrintTask(task);
            }
        }

        private void PrintTask(TaskItem task)
        {
            Console.WriteLine($"[{task.Id}] {task.Description}");
            Console.WriteLine($"Status: {task.Status}");
            Console.WriteLine($"Criado em: {task.CreatedAt:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Atualizado: {task.UpdatedAt:dd/MM/yyyy HH:mm}");
            Console.WriteLine();
        }
    }
}