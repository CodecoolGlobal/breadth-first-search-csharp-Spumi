using BFS_c_sharp.Model;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    class BFS
    {
        public static int Search(UserNode start, UserNode goal, List<UserNode> users)
        {
            Queue<UserNode> q = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            var distance = new Dictionary<UserNode, int>();
            int dist = 0;
            q.Enqueue(start);
            
            while (q.Count > 0) {
                dist++;
                UserNode u = q.Dequeue();
                visited.Add(u);
                if (u == goal)
                    return distance[u];

                foreach (UserNode _u in u.Friends) {
                    if (!visited.Contains(_u))
                        q.Enqueue(_u);
                    distance[_u] = dist;
                }
                
            }
            return 0;
        }

        public static IList ShortestPath(UserNode start, UserNode goal, List<UserNode> users) {
            Queue<UserNode> q = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            var parent = new Dictionary<UserNode, UserNode>();
            var distance = new Dictionary<UserNode, int>();
            int dist = 0;
            q.Enqueue(start);

            while (q.Count > 0)
            {
                dist++;
                UserNode u = q.Dequeue();
                visited.Add(u);
                if (u != goal)
                {
                    foreach (UserNode _u in u.Friends)
                    {
                        //if (parent.ContainsKey(_u))
                        //    continue;
                        if (!visited.Contains(_u))
                        {
                            q.Enqueue(_u);
                            parent[_u] = u;
                        }
                        
                        distance[_u] = dist;
                    }
                }
            }
            var dummyObject = new UserNode(); 
            List<UserNode> path = new List<UserNode>();
            var _current = goal;
            while (parent.TryGetValue(_current, out _current))
            {
                path.Add(_current);
            }
            path.Add(start);
            path.Reverse();

            return path;
        }
    }
}
