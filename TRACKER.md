# DSA Interview Prep — Progress Tracker

## Mastery Criteria

A pattern is "done" only when you can:

1. Explain the data structure / pattern in your own words
2. Recognize when to use it in a new problem
3. Code it without syntax help
4. State the complexity and why

## Confidence Levels

- 🔴 Weak — needs fundamentals taught
- 🟡 Shaky — solved with heavy guidance, needs more practice
- 🟢 Solid — can solve independently

---

## Data Structure Foundations


| Data Structure       | Confidence | Notes                                                                 |
| -------------------- | ---------- | --------------------------------------------------------------------- |
| Arrays               | 🟡         | Comfortable with traversal, needs edge case discipline                |
| Dictionary/HashMap   | 🟢         | Used effectively in Two Sum and Sliding Window                        |
| Heap / PriorityQueue | 🟢         | Internals understood — insert/bubble up, remove/bubble down, O(log n) |
| Linked List          | 🟡         | Cycle I/II, Reverse, Merge solved; Fast & Slow notes complete         |
| Trees                | 🟡         | Prior solutions (Pre/Postorder, Symmetric) — needs reassessment       |
| Graphs               | 🟡         | First graph problem done — adjacency list + BFS (LC 2492)             |
| Stack / Queue        | 🟡         | Monotonic Deque used in Sliding Window Maximum                        |


---

## Pattern Progress


| #   | Pattern              | Confidence | Problems Solved                           | Target |
| --- | -------------------- | ---------- | ----------------------------------------- | ------ |
| 1   | HashMap Lookup       | 🟢         | Two Sum                                   | 3      |
| 2   | Sliding Window       | 🟢         | Longest Substring, Max Sum Subarray K, Min Window Substring, Sliding Window Maximum | 4 ✅   |
| 3   | Intervals + Heap     | 🟡         | Meeting Rooms II                          | 3      |
| 4   | Two Pointers         | 🟢         | Valid Palindrome, Container With Most Water, 3Sum, Two Sum II | 4 ✅   |
| 5   | Fast & Slow Pointers | 🟡         | Linked List Cycle, Linked List Cycle II, Reverse Linked List | 3 ✅   |
| 6   | Binary Search        | 🟢         | Binary Search, First Bad Version, Search in Rotated Sorted Array, Find Minimum in Rotated Sorted Array | 4 ✅   |
| 7   | Prefix Sum           | 🟢         | Subarray Sum Equals K, Product of Array Except Self, Range Sum Query | 3 ✅   |
| 8   | DFS / BFS            | 🟢         | Max Depth, Number of Islands, Level Order, Rotting Oranges, Max Area of Island | 5 ✅   |
| 9   | Backtracking         | 🔴         | —                                         | 4      |
| 10  | Greedy               | 🔴         | —                                         | 3      |
| 11  | Monotonic Stack      | 🟢         | Daily Temperatures, Next Greater Element I, Next Greater Element II | 3 ✅   |
| 12  | Dynamic Programming  | 🟡         | Climbing Stairs, House Robber, Unique Paths, Min Cost Climbing Stairs | 8      |
| 13  | Topological Sort     | 🔴         | —                                         | 2      |
| 14  | Union Find           | 🔴         | —                                         | 2      |


---

## Problems Log


| #   | Problem                                   | Pattern          | Difficulty | Confidence | Date       | Notes                                        |
| --- | ----------------------------------------- | ---------------- | ---------- | ---------- | ---------- | -------------------------------------------- |
| 1   | Two Sum                                   | HashMap          | Easy       | 🟢         | 2026-03-12 | Solved independently after guidance          |
| 2   | Longest Substring Without Repeating Chars | Sliding Window   | Medium     | 🟡         | 2026-03-12 | Needed guidance on Math.Max for left pointer |
| 3   | Meeting Rooms II                          | Intervals + Heap | Medium     | 🟡         | 2026-03-13 | Logic correct, heap internals still unclear  |
| 4   | Valid Palindrome                          | Two Pointers     | Easy       | 🟢         | 2026-03-14 | Solved independently                         |
| 5   | Container With Most Water                 | Two Pointers     | Medium     | 🟢         | 2026-03-14 | Solved with minor guidance                   |
| 6   | 3Sum                                      | Two Pointers     | Medium     | 🟡         | 2026-03-14 | Logic correct, needed help with duplicate skip |
| 7   | Binary Search                             | Binary Search    | Easy       | 🟢         | 2026-03-14 | Solved with minor guidance                     |
| 8   | First Bad Version                         | Binary Search    | Easy       | 🟢         | 2026-03-14 | Boundary template understood                   |
| 9   | Search in Rotated Sorted Array            | Binary Search    | Medium     | 🟡         | 2026-03-14 | Needed guidance on both-bounds check           |
| 10  | Max Sum Subarray of Size K                | Sliding Window   | Easy       | 🟢         | 2026-03-17 | Solved independently — fixed window            |
| 11  | Minimum Window Substring                  | Sliding Window   | Hard       | 🟢         | 2026-04-05 | Shrink logic verified + explained ✓ 2026-06-21 |
| 12  | Sliding Window Maximum                    | Sliding Window   | Hard       | 🟢         | 2026-04-06 | Deque verified + explained ✓ 2026-06-28        |
| 13  | Subarray Sum Equals K                     | Prefix Sum       | Medium     | 🟢         | 2026-04-12 | "Two Sum in disguise"; recall ✓ 2026-06-21     |
| 14  | Product of Array Except Self              | Prefix Sum       | Medium     | 🟡         | 2026-04-12 | Left×right product, O(1) extra space           |
| 15  | Linked List Cycle                         | Fast & Slow      | Easy       | 🟡         | 2026-04-12 | Notes done; prior soln (2025) revisited        |
| 16  | Linked List Cycle II                      | Fast & Slow      | Medium     | 🟡         | 2026-04-12 | Floyd's; A = C − B for cycle start             |
| 17  | Reverse Linked List                       | Fast & Slow      | Easy       | 🟡         | 2026-04-12 | 3-pointer reverse; prior soln revisited        |
| 18  | Daily Temperatures                        | Monotonic Stack  | Medium     | 🟡         | 2026-06-28 | Derived pattern solo; debugged to working; O(n) amortized |
| 19  | Next Greater Element I                    | Monotonic Stack  | Easy       | 🟢         | 2026-06-28 | Recognized pattern in new form; stack+HashMap, O(m+n) |
| 20  | Next Greater Element II                   | Monotonic Stack  | Medium     | 🟡         | 2026-06-29 | Circular: modulo + 2n traversal; needed structural redirect |
| 21  | Maximum Depth of Binary Tree              | DFS / BFS        | Easy       | 🟢         | 2026-06-30 | First recursion/DFS — base case + 1+max(L,R), first try |
| 22  | Number of Islands                         | DFS / BFS        | Medium     | 🟡         | 2026-07-01 | DFS flood fill on grid; sink-as-visited, 4-dir, bounds-first |
| 23  | Binary Tree Level Order Traversal         | DFS / BFS        | Medium     | 🟡         | 2026-07-03 | First BFS — queue + level-size snapshot (got trick, needed code scaffold) |
| 24  | Rotting Oranges                           | DFS / BFS        | Medium     | 🟡         | 2026-07-04 | Multi-source BFS, level=minute; fixed DFS-recursion instinct + -1 bounds; daytime session! |
| 25  | Max Area of Island                        | DFS / BFS        | Medium     | 🟢         | 2026-07-04 | Value-returning DFS (1 + sum of 4); applied framework himself; pattern → 🟢 |
| 26  | Min Score of Path Between Cities (Daily)  | DFS / BFS        | Medium     | 🟡         | 2026-07-04 | FIRST real graph — adjacency list + BFS; insight: min edge in component; O(V+E) |
| 27  | Range Sum Query — Immutable               | Prefix Sum       | Easy       | 🟢         | 2026-07-05 | Classic prefix array, logic first try; O(n) build → O(1) query; pattern → 🟢 |
| 28  | Two Sum II (Sorted)                       | Two Pointers     | Easy       | 🟢         | 2026-07-05 | First-try logic, zero bugs; sorted → two pointers over HashMap; pattern → 🟢 |
| 29  | Find Minimum in Rotated Sorted Array      | Binary Search    | Medium     | 🟢         | 2026-09-05 | Boundary template, first-try logic; mid-vs-right + right=mid; pattern → 🟢 |
| 30  | Climbing Stairs                           | DP               | Easy       | 🟢         | 2026-09-05 | FIRST DP! Derived recurrence himself from hand-counted cases; + O(1) space version |
| 31  | House Robber                              | DP               | Medium     | 🟢         | 2026-09-05 | 2nd DP; base cases + recurrence correct solo; "ways→sum, max→Math.Max" |
| 32  | Unique Paths                              | DP (top-down)    | Medium     | 🟢         | 2026-09-06 | Recursion foundations session; recursion first try, then memoization |
| 33  | Min Cost Climbing Stairs                  | DP               | Easy       | 🟡         | 2026-09-11 | arrive-vs-leave confusion (dp[i] vs cost[i]) — clicked after concrete walkthrough; late-night session |


---

## Prior Solutions (Pre-Program — 2025, not yet pattern-assessed)

These exist on disk from before the structured program. Real solutions, but not drilled or assessed under the current pattern framework — revisit when the relevant pattern comes up:

- **HashMap:** Group Anagrams, Valid Anagrams
- **Linked List:** Merge Two Sorted Lists
- **Binary Search:** Sqrt(x) / Find Square Root, Find Minimum in Rotated Sorted Array
- **Trees:** Binary Tree Preorder, Binary Tree Postorder, Symmetric Tree
- **Arrays:** Concatenation of Arrays, Subarray Sum (basic)

---

## System Design Progress


| #   | System              | Status      | Date |
| --- | ------------------- | ----------- | ---- |
| 1   | URL Shortener       | Not started | —    |
| 2   | Notification System | Not started | —    |
| 3   | Distributed Queue   | Not started | —    |
| 4   | Payment System      | Not started | —    |
| 5   | Rate Limiter        | Not started | —    |


---

## Weekly Goals

### Status (reconciled 2026-06-21)

- **17 program problems solved across 7 patterns** — HashMap, Sliding Window, Two Pointers, Binary Search, Intervals+Heap, Prefix Sum, Fast & Slow.
- Returning after a long gap (last active ~2026-04-12). Today: re-read NOTES, recall ✓ on Sliding Window Max, Container, Prefix Sum.
- All NOTES.md problems now have Hindi explanations + real-life analogies.

### Next up

- **Re-drill post-gap:** the Hard ones (Min Window Substring shrink logic, Sliding Window Maximum) + confirm Two Pointers / Binary Search still solid.
- **Not started:** DFS/BFS, Backtracking, Greedy, Monotonic Stack (concept seen via deque), DP, Topological Sort, Union Find.
- **System Design:** still 0 — pick the 1st (URL Shortener) when ready.

