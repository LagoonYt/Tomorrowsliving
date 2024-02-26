using System;
using System.IO;

namespace TomorrowsLiving
{
    public class ServerManager
    {
        private readonly string _basePath;

        public ServerManager(string basePath)
        {
            _basePath = basePath;
        }

        // Method to create a new server
        public void CreateServer()
        {
            Console.WriteLine("What is the name of your server?");
            var serverName = Console.ReadLine();

            var serverPath = Path.Combine(_basePath, serverName);

            if (Directory.Exists(serverPath))
            {
                Console.WriteLine("That server already exists.");
            }
            else
            {
                Directory.CreateDirectory(serverPath);
                Console.WriteLine($"{serverName} has been created.");
            }
        }

        // Method to edit an existing server
        public void EditServer()
        {
            Console.WriteLine("What is the name of the server you would like to edit?");
            var serverName = Console.ReadLine();

            var serverPath = Path.Combine(_basePath, serverName);

            if (Directory.Exists(serverPath))
            {
                Console.WriteLine("Would you like to rename or delete the server?");
                var userChoice = Console.ReadLine()?.Trim().ToLower();

                switch (userChoice)
                {
                    case "rename":
                        RenameServer(serverPath, serverName);
                        break;
                    case "delete":
                        DeleteServer(serverPath);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Server does not exist.");
            }
        }

        // Method to rename a server
        private void RenameServer(string serverPath, string oldName)
        {
            Console.WriteLine("What would you like to rename the server to?");
            var newName = Console.ReadLine();

            var newPath = Path.Combine(Path.GetDirectoryName(serverPath) ?? string.Empty, newName);

            if (!Directory.Exists(newPath))
            {
                Directory.Move(serverPath, newPath);
                Console.WriteLine($"{oldName} has been renamed to {newName}.");
            }
            else
            {
                Console.WriteLine("A server with this name already exists.");
            }
        }

        // Method to delete a server
        public void DeleteServer(string serverPath)
        {
            Console.WriteLine("Are you sure you want to delete this server? (yes/no)");
            var confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes" && Directory.Exists(serverPath))
            {
                Directory.Delete(serverPath, true);
                Console.WriteLine("Server has been deleted.");
            }
            else
            {
                Console.WriteLine("Server does not exist or deletion cancelled.");
            }
        }
    }
}
