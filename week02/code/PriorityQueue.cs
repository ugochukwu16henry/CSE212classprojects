public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    /// <summary>
    /// Adds an item to the back of the queue with the specified priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var item = new PriorityItem(value, priority);
        _queue.Add(item);
    }

    /// <summary>
    /// Removes and returns the item with the highest priority.
    /// If multiple items have the same highest priority, the first one (FIFO) is returned.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        int highestPriorityIndex = 0;
        int highestPriority = _queue[0].Priority;

        for (int i = 1; i < _queue.Count; i++)
        {
            // Only update if we find a HIGHER priority (not equal)
            // This ensures FIFO behavior for equal priorities
            if (_queue[i].Priority > highestPriority)
            {
                highestPriority = _queue[i].Priority;
                highestPriorityIndex = i;
            }
        }

        // Remove and return the highest priority item
        string value = _queue[highestPriorityIndex].Value;
        _queue.RemoveAt(highestPriorityIndex);
        return value;
    }
}

public class PriorityItem
{
    public string Value { get; set; }
    public int Priority { get; set; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }
}