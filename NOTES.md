# DSA Session Notes — Revision Guide

---

## Big O Complexity

| Complexity | Meaning | Example |
|---|---|---|
| O(1) | Constant — doesn't grow with input | HashMap lookup, array index |
| O(log n) | Halves the problem each step | Binary search, heap ops |
| O(n) | Single pass through input | One for loop |
| O(n log n) | Sort, or n heap operations | Array.Sort, processing n items with a heap |
| O(n²) | Nested loops | Brute force two sum |

**What is log n?** "How many times can I divide n by 2 before hitting 1?"
- n = 1,000 → ~10
- n = 1,000,000 → ~20
- n = 1,000,000,000 → ~30

---

## Pattern 1: HashMap Lookup

**Problem:** Two Sum
**Core trick:** Store `element → index` in a dictionary. For each element, compute complement `target - nums[i]` and check if it exists in O(1).
**Key insight:** Check before adding to dict — prevents an element matching itself.
**Complexity:** O(n) time, O(n) space
**When to use:** Need to find pairs, check existence, or trade O(n) search for O(1) lookup.

---

## Pattern 2: Sliding Window (Variable Size)

**Problem:** Longest Substring Without Repeating Characters
**Core trick:** Right pointer expands window, left pointer shrinks when condition is violated. `left = Math.Max(left, dict[char] + 1)` — never move left backwards.
**Key formula:** Window size = `right - left + 1`. Track best with `Math.Max(maxLen, right - left + 1)`.
**Complexity:** O(n) time, O(n) space
**When to use:** "longest/shortest subarray or substring" + a condition that must hold across the window.
**Fixed vs Variable:** Fixed = window size stays same (e.g., max sum of size K). Variable = window grows/shrinks based on condition.

---

## Pattern 3: Intervals + Min-Heap

**Problem:** Meeting Rooms II
**Core trick:** Sort by start time. Min-heap tracks end times of active rooms. If `heap.Peek() <= current.start` → reuse room (Dequeue). Always Enqueue current end time. Heap size = rooms needed.
**Overlap condition:** Two intervals overlap if `A.end > B.start AND B.end > A.start`
**Complexity:** O(n log n) time, O(n) space
**When to use:** Interval scheduling, resource allocation, "minimum number of X needed" problems.

---

## Data Structure: Heap / PriorityQueue

### What is it
- Binary tree stored as an **array**
- Min-heap rule: **parent is always smaller than both children** (no left/right ordering rule)
- Smallest element is always at index 0 (root)

### Index Math
```
Parent:      (i - 1) / 2
Left child:  2i + 1
Right child: 2i + 2
```

### Operations
| Operation | How | Complexity |
|---|---|---|
| Insert (Enqueue) | Add to end, **bubble up** — swap with parent while smaller | O(log n) |
| Remove (Dequeue) | Replace root with last, **bubble down** — swap with smaller child | O(log n) |
| Peek | Read index 0 | O(1) |

### Why O(log n)
Maximum swaps = height of tree = log₂(n). A million elements → ~20 swaps max.

### C# API
```csharp
var heap = new PriorityQueue<TElement, TPriority>();
heap.Enqueue(element, priority);  // insert
heap.Peek();                       // read min
heap.Dequeue();                    // remove min
heap.Count;                        // size
```

---

## Pattern 4: Two Pointers

**Core idea:** Two pointers at strategic positions, move based on a condition. Avoids nested loops.
**When to use:** Sorted arrays, palindromes, pair/triplet finding, container problems.
**Signature complexity:** O(n) time, O(1) space (except 3Sum which is O(n²) due to outer loop).

### Valid Palindrome (LeetCode 125)
- Left at 0, right at end, move inward
- Skip non-alphanumeric with `continue`, compare with `char.ToLower`
- O(n) time, O(1) space

### Container With Most Water (LeetCode 11)
- Area = `Math.Min(height[left], height[right]) * (right - left)`
- Always move the **shorter** pointer — width shrinks, so only taller height can help
- O(n) time, O(1) space

### 3Sum (LeetCode 15)
- Sort first → duplicates are adjacent → easy to skip
- Fix one number, Two Pointers on the rest → reduces to Two Sum
- Skip `i` duplicates: `if (i > 0 && nums[i] == nums[i-1]) continue;` — compare backward to skip second occurrence, not first
- After finding triplet: skip duplicate lefts and rights with while loops, then `left++; right--;`
- O(n²) time, O(1) space

---

## Pattern 5: Binary Search

**Core idea:** Halve the search space each step → O(log n). Works anytime you can answer a yes/no question that splits the space in half.
**When to use:** Sorted arrays, boundary finding, rotated arrays, search space problems.

### Complexity Rule
- Halving + O(1) per step → **O(log n)**
- Halving + O(n) per step → **O(n log n)**

### Two Templates

| | Classic Search | Boundary Search |
|---|---|---|
| Goal | Find exact target | Find first/last that satisfies condition |
| When found | Return immediately | Keep searching — `right = mid` |
| Loop condition | `left <= right` | `left < right` |
| Pointer move | `left = mid + 1`, `right = mid - 1` | `left = mid + 1`, `right = mid` |
| Return | `mid` or `-1` | `left` |

### Classic Binary Search (LeetCode 704)
- Sorted array, find target index
- `left <= right`, return `mid` when found
- O(log n) time, O(1) space

### First Bad Version (LeetCode 278)
- Boundary search — find where false flips to true
- `right = mid` (not `mid - 1`) because mid might be the answer
- `left < right` (not `<=`) to avoid infinite loop
- O(log n) time, O(1) space

### Search in Rotated Sorted Array (LeetCode 33)
- Array is sorted but rotated at some pivot
- Key insight: at any mid, **one half is always sorted**
- Check which half is sorted: `nums[left] <= nums[mid]` → left half sorted
- Check if target falls within the sorted half's range, search accordingly
- O(log n) time, O(1) space

---

## Array of Arrays — int[][]

```csharp
int[][] intervals = new int[][] {
    new int[] {0, 30},     // intervals[0] → [0, 30]
    new int[] {5, 10},     // intervals[1] → [5, 10]
};

intervals.Length      → number of rows
intervals[i][0]       → first value (e.g., start time)
intervals[i][1]       → second value (e.g., end time)
```
