namespace TaskTrackerCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            var manager = new TaskManager();
            string command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "add":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("Erro: Descrição da tarefa não fornecida.");
                            Console.WriteLine("Uso: task-cli add \"Descrição da tarefa\"");
                            return;
                        }
                        manager.AddTask(args[1]);
                        break;

                    case "update":
                        if (args.Length < 3)
                        {
                            Console.WriteLine("Erro: ID e/ou descrição não fornecidos.");
                            Console.WriteLine("Uso: task-cli updtate <ID> \"Nova descrição\"");
                            return;
                        }
                        if (!int.TryParse(args[1], out int updateId))
                        {
                            Console.WriteLine("Erro: ID inválido.");
                            return;
                        }
                        manager.UpdateTask(updateId, args[2]);
                        break;

                    case "delete":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("Erro: ID não fornecido.");
                            Console.WriteLine("Uso: task-cli delete <ID>");
                            return;
                        }
                        if (!int.TryParse(args[1], out int deletedId))
                        {
                            Console.WriteLine("Erro: ID inválido.");
                            return;
                        }
                        manager.DeleteTask(deletedId);
                        break;

                    case "mark-done":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("Erro: ID não fornecido.");
                            return;
                        }
                        if (!int.TryParse(args[1], out int doneId))
                        {
                            Console.WriteLine("Erro: ID inválido.");
                            return;
                        }
                        manager.MarkDone(doneId);
                        break;

                    case "list":
                        if (args.Length == 1)
                        {
                            manager.ListAllTasks();
                        }
                        else
                        {
                            string status = args[1].ToLower();
                            manager.ListTasksByStatus(status);
                        }
                        break;

                    default:
                        Console.WriteLine($"Comando '{command}' não reconhecido.");
                        ShowHelp();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("=== Task Tracker CLI ===");
            Console.WriteLine("\nComandos disponíveis:");
            Console.WriteLine("  add <descrição>              - Adiciona nova tarefa");
            Console.WriteLine("  update <id> <descrição>      - Atualiza tarefa");
            Console.WriteLine("  delete <id>                  - Deleta tarefa");
            Console.WriteLine("  mark-in-progress <id>        - Marca como em progresso");
            Console.WriteLine("  mark-done <id>               - Marca como concluída");
            Console.WriteLine("  list                         - Lista todas as tarefas");
            Console.WriteLine("  list done                    - Lista tarefas concluídas");
            Console.WriteLine("  list todo                    - Lista tarefas pendentes");
            Console.WriteLine("  list in-progress             - Lista tarefas em progresso");
            Console.WriteLine("\nExemplos:");
            Console.WriteLine("  dotnet run add \"Comprar café\"");
            Console.WriteLine("  dotnet run update 1 \"Comprar café e pão\"");
            Console.WriteLine("  dotnet run mark-done 1");
        }
    }
}