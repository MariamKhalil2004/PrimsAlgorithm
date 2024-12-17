using System;

class PrimsAlgorithm
{
    private static int V = 5;  // Number of vertices
    private static int INF = int.MaxValue;

    // Function to find the vertex with minimum key value
    static int MinKey(int[] key, bool[] mstSet)
    {
        int min = INF, minIndex = -1;
        for (int v = 0; v < V; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    // Function to implement Prim's algorithm
    static void Prim(int[,] graph)
    {
        int[] parent = new int[V];  // Array to store MST
        int[] key = new int[V];     // Key values to pick minimum weight edge
        bool[] mstSet = new bool[V]; // To represent vertices included in MST

        // Initialize all keys as infinity and mstSet as false
        for (int i = 0; i < V; i++)
        {
            key[i] = INF;
            mstSet[i] = false;
        }

        // Start with the first vertex
        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < V - 1; count++)
        {
            // Pick the minimum key vertex
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            // Update key values and parent index of adjacent vertices
            for (int v = 0; v < V; v++)
            {
                if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        // Print the MST
        PrintMST(parent, graph);
    }

    // Function to print the constructed MST
    static void PrintMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < V; i++)
        {
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
        }
    }

    static void Main()
    {
        // Example graph (Adjacency Matrix)
        int[,] graph = {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        // Run Prim's algorithm
        Prim(graph);
    }
}

