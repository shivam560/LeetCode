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

### Max Sum Subarray of Size K
- Fixed window — compute sum of first k elements, then slide
- Slide: `sum = sum - nums[i - k] + nums[i]` (subtract leaving, add entering)
- Key thinking: "What can I reuse from the previous step?" → don't recalculate, just update
- O(n) time, O(1) space

### Minimum Window Substring (LeetCode 76) — HARD

**The problem:** Given strings `s` and `t`, find the smallest substring of `s` that contains ALL characters of `t`.
Example: `s = "ADOBECODEBANC"`, `t = "ABC"` → `"BANC"`

**Why is it harder than Longest Substring?**
In Longest Substring you just tracked duplicates. Here your window needs to contain specific characters with specific frequencies.

**The setup — two dictionaries:**
- `need` = what `t` requires. For `t = "ABC"` → `{A:1, B:1, C:1}`
- `window` = what your current window has. Updated as you expand/shrink.

**The trick — a `matched` counter:**
Comparing two whole dictionaries every step is slow. Instead, keep one number: `matched`.
- When `window[char]` reaches `need[char]` for a character → `matched++`
- When `matched == need.Count` → your window has everything. It's valid!
- This way you check one number instead of comparing entire dictionaries.

**The two phases:**
1. **Expand** — move `right` forward, add char to `window`, check if it completes a match
2. **Shrink** — once valid, keep moving `left` forward to find the smallest valid window

**Why a `while` loop for shrinking (not just `if`)?**
Your first valid window might have junk on the left. `"ADOBEC"` is valid but `"BANC"` is smaller. The while loop keeps removing from the left until the window breaks. Every time it's still valid, you check if it's the new smallest.

**Shrink logic — order matters:**
1. Record the answer if this window is smaller than the best so far
2. Decrease `window[s[left]]` by 1 (don't remove the key — char might appear multiple times)
3. Check if that broke a match: `window[s[left]] < need[s[left]]` → `matched--`
4. Move `left++`

**Why `<` not `==` for breaking a match?**
After decrementing, if `window[char] == need[char]`, the match still holds. It only breaks when it drops BELOW what's needed.

**Why track `minStart` and `minLen` (not just length)?**
At the end you need to return the actual substring: `s.Substring(minStart, minLen)`. If you only tracked length, you'd know the answer is 4 chars but not WHICH 4.

**How to think your way to this solution (don't memorise, follow these questions):**
1. "Find smallest substring" → sliding window
2. What's the brute force? → check every substring O(n²) — too slow
3. What am I recomputing? → almost the same window each step, just update the diff
4. How to track validity cheaply? → two dictionaries + one counter
5. Expand → validate → shrink → record best

**Complexity:** O(n) time — each char visited at most twice (once by right, once by left). O(n) space — two dictionaries.

### Sliding Window Maximum (LeetCode 239) — HARD

**The problem:** Given an array and integer `k`, return the max of every window of size `k`.
Example: `nums = [1,3,-1,-3,5,3,6,7]`, `k = 3` → `[3,3,5,5,6,7]`

**Why can't you just track the max?**
When the current max **leaves** the window, you don't know the next max without rescanning the whole window. Tracking one max isn't enough — you need the second biggest, third biggest, etc.

**Why not a heap?**
A heap gives you the max in O(1), BUT you can't remove a specific element from the middle efficiently. When an element leaves the window, you're stuck.

**The answer: Monotonic Decreasing Deque**
A deque (double-ended queue) where elements go from biggest at the front to smallest at the back. Always decreasing, never increasing — that's why it's called "monotonic."

**What is a Deque?**
Like a queue but you can add/remove from BOTH ends in O(1).
```
FRONT [5, 3, 1] BACK
 ↑                 ↑
 biggest           smallest
 (the max)         (new elements enter here)
```

**C# Deque = `LinkedList<T>`:**
```
d.AddLast(value)     — add to back
d.RemoveLast()       — remove from back
d.AddFirst(value)    — add to front
d.RemoveFirst()      — remove from front
d.First.Value        — peek front
d.Last.Value         — peek back
d.Count              — size
```

**We store INDICES in the deque, not values.** Why? Because we need indices to check if an element is still inside the window.

**The four steps inside the loop:**

1. **Remove useless elements from back.** If the new element is bigger than the back, the back will never be the max — kick it out. Keep kicking until the back is bigger or deque is empty.
   `while (d.Count > 0 && nums[d.Last.Value] < nums[right]) → RemoveLast()`

2. **Add new element to back.**
   `d.AddLast(right)`

3. **Remove expired element from front.** If the front index is outside the window, remove it.
   `if (d.First.Value <= right - k) → RemoveFirst()`
   Why `right - k`? If `right = 4` and `k = 3`, window is `[2,3,4]`. Oldest valid index is `right - k + 1 = 2`. So anything at index `1` or less is expired. `<= right - k` catches exactly that.

4. **Record the answer.** Once the window is full (`right >= k - 1`), the front of the deque is the max.
   `result[right - k + 1] = nums[d.First.Value]`

**Key insight to remember:** "If I'm bigger than you AND I arrived after you — you'll never be the answer. Get out." That's the whole algorithm.

**Complexity:** O(n) time — each element enters and leaves the deque at most once. O(k) space — deque holds at most k elements.

---

## Pattern 6: Prefix Sum

**Core idea:** Build a running total so you can answer "what's the sum from index i to j?" in O(1) instead of re-adding every time.

```
nums   = [2, 4, 1, 3, 5]
prefix = [0, 2, 6, 7, 10, 15]   ← start with 0 to avoid edge cases
```

**Formula:** sum from index i to j = `prefix[j+1] - prefix[i]`

**When to use:** Any problem asking about subarray sums, range sums, or "how many subarrays sum to X."

### Subarray Sum Equals K (LeetCode 560)

**The problem:** Given array `nums` and integer `k`, count how many contiguous subarrays sum to `k`.
Example: `nums = [1, 1, 1]`, `k = 2` → `2`

**Brute force:** Two nested loops, check every subarray. O(n²).

**The trick — it's Two Sum in disguise:**
- Keep a running `sum` (your prefix sum)
- At each step ask: "Is `sum - k` in my dictionary?"
- If yes → there's a subarray between that earlier prefix sum and now that equals `k`
- Same logic as Two Sum: `complement = target - current`

**Why `dict[0] = 1` at the start?**
If `sum` itself equals `k`, then `sum - k = 0`. You need `0` in the dictionary to count this case. It means "a subarray from the very start sums to k."

**Why `count += dict[sum - k]` and not just `count++`?**
The same prefix sum can appear multiple times. If `sum - k` shows up 3 times in the dictionary, that means 3 different subarrays ending here sum to `k`.

**Why `dict[sum]++` and not `dict[sum] = 1`?**
Same prefix sum can occur multiple times (especially with negative numbers). You need to track HOW MANY times, not just that it exists.

**Complexity:** O(n) time — one pass. O(n) space — dictionary.

**Dry Run:** `nums = [1, 1, 1]`, `k = 2`

```
Start: sum = 0, count = 0, dict = {0: 1}

i=0: sum = 0 + 1 = 1
     sum - k = 1 - 2 = -1 → not in dict → nothing
     add sum to dict → dict = {0:1, 1:1}

i=1: sum = 1 + 1 = 2
     sum - k = 2 - 2 = 0 → found in dict! dict[0] = 1 → count += 1 → count = 1
     (matlab index 0 se 1 tak ka subarray [1,1] sum = 2 hai ✓)
     add sum to dict → dict = {0:1, 1:1, 2:1}

i=2: sum = 2 + 1 = 3
     sum - k = 3 - 2 = 1 → found in dict! dict[1] = 1 → count += 1 → count = 2
     (matlab index 1 se 2 tak ka subarray [1,1] sum = 2 hai ✓)
     add sum to dict → dict = {0:1, 1:1, 2:1, 3:1}

Return count = 2 ✓
```

**Hindi mein samjho:**
Socho tumhare paas ek running total hai — jaise tum aage badhte ho, sum badhta jaata hai. Ab har step pe tum puchho: "Kya pehle kabhi aisa hua tha ki sum `sum - k` tha?" Agar haan — toh uske baad se lekar ab tak ka subarray ka sum exactly `k` hai. Yeh Two Sum jaisa hi hai — complement dhoondho dictionary mein. `dict[0] = 1` isliye rakhte ho kyunki agar starting se hi sum = k ho gaya, toh `sum - k = 0` dictionary mein milna chahiye.

---

## Pattern 3: Intervals + Min-Heap

**Problem:** Meeting Rooms II
**Core trick:** Sort by start time — you can't assign rooms if meetings arrive out of order. Think of it like a queue: first to arrive gets handled first. Min-heap tracks when each room becomes free. If the earliest free room is free before this meeting starts → reuse it (Dequeue). Otherwise → open a new room. Heap size at the end = total rooms needed.
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
- Check if target falls within the sorted half's **range** (both bounds!) — not just one side
- O(log n) time, O(1) space

**Why both bounds matter:**
```
nums = [4, 5, 6, 7, 0, 1, 2], target = 5

left=0, right=6, mid=3 → nums[mid]=7
nums[left]=4 <= nums[mid]=7 → left half [4,5,6,7] is sorted

Is target in left half? Check BOTH bounds:
  target >= nums[left]  →  5 >= 4  ✓
  target < nums[mid]    →  5 < 7   ✓
  Both true → search left half: right = mid - 1
```

```
nums = [4, 5, 6, 7, 0, 1, 2], target = 1

left=0, right=6, mid=3 → nums[mid]=7
nums[left]=4 <= nums[mid]=7 → left half [4,5,6,7] is sorted

Is target in left half?
  target >= nums[left]  →  1 >= 4  ✗
  Fails first check → target is NOT in left half → search right: left = mid + 1
```

**The four conditions:**
```
If left half sorted (nums[left] <= nums[mid]):
  target >= nums[left] && target < nums[mid]  → search left (right = mid - 1)
  otherwise                                    → search right (left = mid + 1)

If right half sorted:
  target > nums[mid] && target <= nums[right]  → search right (left = mid + 1)
  otherwise                                    → search left (right = mid - 1)
```

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
