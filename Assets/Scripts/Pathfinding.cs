using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pathfinding
{
    private static Position end;
    private static Room room;

    class Node : IComparable
    {
        public Position position;
        public int depth;
        public double cost;
        public Node parent;

        public Node(Position position, Node parent, int depth)
        {
            this.position = position;
            this.parent = parent;
            this.depth = depth;
        }

        public int CompareTo(object obj)
        {
            return (int) (cost - ((Node)obj).cost * 1000);
        }
    }

    public static void Search(Position init, Position end, Room room)
    {
        Node first = new Node(init, null, 0);
        Pathfinding.end = end;
        Pathfinding.room = room;

        first.cost = Cost(first);

        Node node = AStarAlgorithm(first);

        Debug.Log("Path:");
        while (node != null)
        {
            Debug.Log("? " + node.position);
            node = node.parent;
        }
    }

    private static Node AStarAlgorithm(Node init)
    {
        PriorityQueue<Node> minHeap = new PriorityQueue<Node>();
        List<Node> visited = new List<Node>();

        minHeap.Enqueue(init);
        while (minHeap.Count != 0)
        {
            Node cur = minHeap.Dequeue();

            if (cur.position.Equals(end)) return cur;

            if (room.getMatrix()[cur.position.x, cur.position.y] is not EmptySpace || Contains(visited, cur)) continue;

            visited.Add(cur);
            Debug.Log(cur.position + " " + (cur.parent is null ? "null" : cur.parent.position) + " " + cur.cost);

            if (cur.position.x > 0)
            {
                Node next = new Node(new Position(cur.position.x - 1, cur.position.y), cur, cur.depth + 1);

                next.cost = Cost(next);
                minHeap.Enqueue(next);
            }
            if (cur.position.y < room.ROOMSIZE - 1)
            {
                Node next = new Node(new Position(cur.position.x, cur.position.y + 1), cur, cur.depth + 1);

                next.cost = Cost(next);
                minHeap.Enqueue(next);
            }
            if (cur.position.x < room.ROOMSIZE - 1)
            {
                Node next = new Node(new Position(cur.position.x + 1, cur.position.y), cur, cur.depth + 1);

                next.cost = Cost(next);
                minHeap.Enqueue(next);
            }
            if (cur.position.y > 0)
            {
                Node next = new Node(new Position(cur.position.x, cur.position.y - 1), cur, cur.depth + 1);

                next.cost = Cost(next);
                minHeap.Enqueue(next);
            }
        }

        return null;
    }

    private static double Cost(Node cur)
    {
        if (cur.parent is null) return Distance(cur.position);
        return Math.Max(Cost(cur.parent), cur.depth + Distance(cur.position));
    }

    private static double Distance(Position position)
    {
        return Math.Sqrt(Math.Pow(end.x - position.x, 2) + Math.Pow(end.y - position.y, 2));
    }

    private static bool Contains(List<Node> list, Node node)
    {
        foreach (Node n in list)
        {
            if (n.position.Equals(node.position)) return true;
        }
        return false;
    }
}