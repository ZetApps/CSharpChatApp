using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Server
    {
        private static ServerHandler handler;
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день! Для начала необходимо запустить сервер с помощью команды /start");
            handler = new ServerHandler();
            waitCommand();
        }

        public static void waitCommand()
        {
            String line;
            do
            {
                line = Console.ReadLine();
                if (line.Substring(0, 1).Equals("/"))
                {
                    try
                    {
                        handler.commandWorker(line);
                    }
                    catch (CommandException e)
                    {
                        Console.WriteLine("Вы ввели неправильную команду, попробуйте еще раз");
                    }
                }
                else
                {
                    Console.WriteLine("Команда должна начинаться с /");
                }
            } while (!line.Equals("/exit"));
            System.Environment.Exit(0);
        }



    }
}
