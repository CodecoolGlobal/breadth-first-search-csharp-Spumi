using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
                foreach (var friend in user.Friends)
                {
                    Console.WriteLine("\t - " + friend);
                }
            }

            Console.WriteLine(BFS.Search(users[1], users[3], users));

           
            var path = BFS.ShortestPath(users[1], users[3], users);

            foreach (var node in path)
                Console.Write(node + " ");

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
