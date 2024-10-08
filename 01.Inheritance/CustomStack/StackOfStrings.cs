﻿namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public StackOfStrings()
        {

        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }
        }
    }
}
