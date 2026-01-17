using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in priority order (highest first): "High", "Medium", "Low"
    // Defect(s) Found: None - the implementation correctly dequeues items in priority order.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order: "First", "Second", "Third"
    // Defect(s) Found: None - the implementation correctly maintains FIFO order for equal priorities.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of different and same priorities
    // Expected Result: Should dequeue highest priority first, then FIFO within same priority
    // Expected order: "Urgent1", "Urgent2", "High", "Medium", "Low1", "Low2"
    // Defect(s) Found: None - the implementation correctly handles mixed priorities with FIFO for equal values.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High", 7);
        priorityQueue.Enqueue("Urgent1", 10);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("Urgent2", 10);
        priorityQueue.Enqueue("Low2", 1);

        Assert.AreEqual("Urgent1", priorityQueue.Dequeue());
        Assert.AreEqual("Urgent2", priorityQueue.Dequeue());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
        Assert.AreEqual("Low2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - the implementation correctly throws the proper exception with the correct message.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue interleaved operations
    // Expected Result: Should maintain correct priority ordering throughout: "A", "C", "B"
    // Defect(s) Found: None - the implementation maintains correct ordering with interleaved operations.
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());

        priorityQueue.Enqueue("C", 7);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Single item enqueue and dequeue
    // Expected Result: Should successfully enqueue and dequeue the single item: "OnlyItem"
    // Defect(s) Found: None - the implementation handles single items correctly.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 1);

        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Items with priority 0 and negative priorities
    // Expected Result: Should handle all priority values correctly, highest first: "Positive", "Zero", "Negative"
    // Defect(s) Found: None - the implementation correctly handles zero and negative priorities.
    public void TestPriorityQueue_ZeroAndNegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Negative", -5);
        priorityQueue.Enqueue("Zero", 0);
        priorityQueue.Enqueue("Positive", 5);

        Assert.AreEqual("Positive", priorityQueue.Dequeue());
        Assert.AreEqual("Zero", priorityQueue.Dequeue());
        Assert.AreEqual("Negative", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Large number of items to stress test the implementation
    // Expected Result: All items should be dequeued in correct priority order
    // Defect(s) Found: None - the implementation correctly handles larger datasets.
    public void TestPriorityQueue_LargeDataset()
    {
        var priorityQueue = new PriorityQueue();

        // Add items in random priority order
        priorityQueue.Enqueue("P1-Item1", 1);
        priorityQueue.Enqueue("P5-Item1", 5);
        priorityQueue.Enqueue("P3-Item1", 3);
        priorityQueue.Enqueue("P5-Item2", 5);
        priorityQueue.Enqueue("P1-Item2", 1);
        priorityQueue.Enqueue("P3-Item2", 3);
        priorityQueue.Enqueue("P5-Item3", 5);

        // Should dequeue all P5 items first (FIFO), then P3 items (FIFO), then P1 items (FIFO)
        Assert.AreEqual("P5-Item1", priorityQueue.Dequeue());
        Assert.AreEqual("P5-Item2", priorityQueue.Dequeue());
        Assert.AreEqual("P5-Item3", priorityQueue.Dequeue());
        Assert.AreEqual("P3-Item1", priorityQueue.Dequeue());
        Assert.AreEqual("P3-Item2", priorityQueue.Dequeue());
        Assert.AreEqual("P1-Item1", priorityQueue.Dequeue());
        Assert.AreEqual("P1-Item2", priorityQueue.Dequeue());
    }
}