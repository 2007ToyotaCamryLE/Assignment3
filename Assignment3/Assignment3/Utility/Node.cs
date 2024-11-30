using System;

namespace Assignment3
{
    [Serializable]
    public class Node
    {
        public User Data { get; set; }
        public Node Next { get; set; }

        public Node(User data)
        {
            Data = data;
            Next = null;
        }
    }
}
