namespace Blind75.Questions;

// LeetCode 253: Meeting Rooms II
// Given a list of meeting intervals [start, end], find the minimum number of conference rooms required.
// Overlap condition: A.end > B.start AND B.end > A.start
// Key insight: Sort by start time, use min-heap to track earliest ending room. If new meeting starts after earliest ends, reuse it.
// Example: [[0,30],[5,10],[15,20]] → 2

public class MeetingRoomsII
{
    // Pattern: Intervals + Min-Heap
    // Time: O(n log n) | Space: O(n)
    public int MinMeetingRooms(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        var minHeap = new PriorityQueue<int, int>();

        foreach (var interval in intervals)
        {
            if (minHeap.Count > 0 && minHeap.Peek() <= interval[0])
                minHeap.Dequeue();

            minHeap.Enqueue(interval[1], interval[1]);
        }

        return minHeap.Count;
    }
}
