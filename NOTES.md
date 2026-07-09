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

## Pattern Recognition — Signal → Tool

Problem solving = **pehchaan-na, invent karna nahi.** Problem ke keywords dekho, tool yaad karo. Toolbox jitna bada, utni aasaani.

| Problem bolti hai... | Tool |
|---|---|
| "pair summing to target", existence check | HashMap |
| "longest/shortest subarray/substring + condition" | Sliding Window |
| "next greater / smaller element", "next warmer day" | Monotonic Stack |
| **"circular / wrap / ring / round" array** | **Modulo `% n` + array ko 2x traverse (`2*n` loop)** |
| "kth largest/smallest", "top k" | Heap |
| "subarray sum", "range sum", "how many subarrays sum to X" | Prefix Sum |
| sorted array, "find target / boundary" | Binary Search |
| "cycle in linked list", "middle of list" | Fast & Slow Pointers |
| sorted array, "pair/triplet", palindrome | Two Pointers |

**Technique — Circular Array:** Index ko `i % n` se access karo → end ke baad automatically `0` pe wrap ho jaata hai. Agar har element ko poora circular view chahiye, loop `2*n` baar chalao (ek baar kaafi nahi — last element wrap karke hi apna answer pa sakta hai; do baar sab cover ho jaate hain). "Not found" ke liye result ka **default** set karo (e.g. `-1`).

**Kaise derive karein (agar modulo na pata ho):** "Index `n` ya upar chala gaya, par array sirf `0..n-1`. Jab over jaaye, `n` ghata do." → baar-baar `n` ghatana = remainder = **modulo `% n`**. Zaroorat khud tool tak le aati hai.

**Yaad rakhne ka rule:** Har problem ke baad likho — "yeh kis SIGNAL pe kaunsa TOOL maang rahi thi." Wahi intuition build karta hai.

---

## How to Attack a New Problem (Interview Framework)

Nervousness aati hai "mujhe answer pata hona chahiye" se. Sach: answer **invent** nahi karte, **derive** karte hain — ek process se. **Process = calm + safety net.** Interviewer answer se zyada tera **process** dekhta hai.

**Jab koi problem aaye, blank mat baith — yeh 6 step BOL ke chal:**

1. **Restate + chhota example haath se solve** — problem samjho, ek choti misaal khud nikaalo.
2. **Brute force pehle bolo** — dumb O(n²) tareeka. Safety net hai, aur interviewer ko bhi chahiye.
3. **Signal → Tool pehchaano** — keywords se pattern recall karo (upar wali cheatsheet): "connected cells" → DFS/BFS, "next greater" → Monotonic Stack, "circular" → modulo, "subarray sum" → Prefix Sum...
4. **Recursion/DFS ho toh 2 sawaal:**
   - **"Kab RUKU?" (base case)** — invalid cases dhoondho (out of bounds, galat type, khaali input).
   - **"Ek step kya + kahan recurse?"** — baaki subproblem solved maan ke combine karo.
5. **Dry run** chhote example pe — verify.
6. **Complexity** — time + space.

**Base case derive karne ka rule:** "Main kab kuch NAHI kar sakta?" — wahi base case. (e.g. Number of Islands: grid ke bahar, ya cell `'0'`.)

**Modeling derive karne ka rule:** Problem ke **shabdon ko technique mein translate** karo. "Connected horizontally/vertically" = "reachable" = DFS/BFS ka kaam. "Wrap around" = modulo. Zaroorat khud tool batati hai.

**Nervousness ka ilaaj:** answers nahi, **process** practice karo. Har problem pe yeh 6 step **bol ke** karo. 30-40 problems baad automatic — aur jab process pe bharosa ho, nerves apne aap girte hain.

---

## Pattern 1: HashMap Lookup

**Problem:** Two Sum
**Core trick:** Store `element → index` in a dictionary. For each element, compute complement `target - nums[i]` and check if it exists in O(1).
**Key insight:** Check before adding to dict — prevents an element matching itself.
**Complexity:** O(n) time, O(n) space
**When to use:** Need to find pairs, check existence, or trade O(n) search for O(1) lookup.

**Hindi mein samjho:**
Socho ek shaadi mein tumhe do log dhoondhne hain jinki umar milake exactly `target` ho. Har naye bande ke liye socho — "mujhe kitni umar wala chahiye?" = `target - iski umar` (complement). Phir apni diary (dictionary) mein dekho kya woh banda pehle mil chuka hai. Mil gaya → pair ready! Diary mein **add karne se pehle check karo, phir daalo** — warna banda khud se hi match kar lega. Diary mein dekhna O(1) hota hai, isliye poora O(n).

---

## Pattern 2: Sliding Window (Variable Size)

**Problem:** Longest Substring Without Repeating Characters
**Core trick:** Right pointer expands window, left pointer shrinks when condition is violated. `left = Math.Max(left, dict[char] + 1)` — never move left backwards.
**Key formula:** Window size = `right - left + 1`. Track best with `Math.Max(maxLen, right - left + 1)`.
**Complexity:** O(n) time, O(n) space
**When to use:** "longest/shortest subarray or substring" + a condition that must hold across the window.
**Fixed vs Variable:** Fixed = window size stays same (e.g., max sum of size K). Variable = window grows/shrinks based on condition.

**Hindi mein samjho:**
Socho tum ek gali se guzar rahe ho aur tumhe sabse lambi aisi gali chahiye jahan koi ghar (character) repeat na ho. Right pointer aage badh ke naye ghar window mein add karta hai. Jaise hi koi character dobara dikhe, left pointer ko us repeat wale character ke **just baad** tak le jao — taaki window mein sab unique rahein. left ko **kabhi peeche mat le jao** (`Math.Max`), warna purane repeats dobara ginne lagoge. Har step pe `right - left + 1` = current window size; usme se sabse bada yaad rakho.

### Max Sum Subarray of Size K
- Fixed window — compute sum of first k elements, then slide
- Slide: `sum = sum - nums[i - k] + nums[i]` (subtract leaving, add entering)
- Key thinking: "What can I reuse from the previous step?" → don't recalculate, just update
- O(n) time, O(1) space

**Hindi mein samjho:**
Socho tumhe lagatar `k` din ki kamai ka maximum total nikalna hai. Har baar poore `k` din dobara jodne ki zaroorat nahi — bas jo din window se **bahar gaya usko ghata do**, jo **naya din aaya usko jod do**: `sum = sum - nums[i-k] + nums[i]`. Window aage slide karti rehti hai aur purana kaam reuse hota hai. Real-life: chalti train ki khidki — ek dabba peeche jaata hai, ek naya aage aata hai, par tum poori train dobara nahi ginte.

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

**Hindi mein samjho:**
Socho medical store se ek combo chahiye — 1 paracetamol, 1 crocin, 1 vitamin (yeh `need` hai). Tum ek thaila (window) lekar shelf pe chalte ho aur saaman uthate jaate ho (right expand). Jaise hi thaile mein **poora combo** aa gaya (`matched == need.Count`), ab **left se faltu saaman hatana** shuru karo — sabse chhota valid thaila banane ke liye (shrink). Jab tak combo poora hai, hatate raho aur abhi tak ka **sabse chhota thaila yaad rakho** (`minStart`, `minLen`). `matched` ek single number hai jisse turant pata chalta hai combo poora hua ya nahi — har step pe poori list compare karne ki zaroorat nahi.

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

**Hindi mein samjho:**
Socho ek line mein log khade hain aur tum sirf `k` logo ki khidki ke through dekh rahe ho — usme sabse lamba kaun? Deque mein hum sirf woh log rakhte hain jo "abhi tak ke dabang" hain — front pe sabse lamba. Jab naya aadmi aata hai jo peeche khade chhoton se bada hai, woh chhote **kabhi answer nahi banenge** (kyunki naya unse bada bhi hai aur baad tak rahega bhi) — unhe deque se nikaal do. Jo aadmi khidki se bahar nikal gaya (purana index) usko front se hata do. Front hamesha current khidki ka sabse lamba. Rule yaad rakho: **"Main tujhse bada bhi hu aur tere baad bhi aaya — tu kabhi answer nahi banega, nikal."**

---

## Pattern 6: Prefix Sum

**Core idea:** Build a running total so you can answer "what's the sum from index i to j?" in O(1) instead of re-adding every time.

```
nums   = [2, 4, 1, 3, 5]
prefix = [0, 2, 6, 7, 10, 15]   ← start with 0 to avoid edge cases
```

**Formula:** sum from index i to j = `prefix[j+1] - prefix[i]`

**When to use:** Any problem asking about subarray sums, range sums, or "how many subarrays sum to X."

### Range Sum Query — Immutable (LeetCode 303) — the classic prefix array

**The problem:** Array diya; **baar-baar** queries: "index i se j tak ka sum?" (hazaaron queries ho sakti hain).

**Brute force:** har query pe loop = O(n) **per query** → q queries = O(q×n). Slow.

**The trade — "pehle thodi mehnat, phir har sawaal muft":**
- Constructor mein **ek baar** prefix array banao (O(n))
- Har query = **ek subtraction** = **O(1)** ⚡

**Build (bank-balance analogy):** `prefix[k]` = "pehle k elements ka total" (ab tak ka balance). Size **n+1**, `prefix[0] = 0` (pehle 0 elements ka total).
```csharp
prefix = new int[n + 1];
for (int k = 0; k < n; k++)
    prefix[k + 1] = prefix[k] + nums[k];
```

**Query:** `sum(i..j) = prefix[j+1] - prefix[i]` — "aaj tak ka balance − us din tak ka balance = beech ki kamai."

**Dry run:** `nums = [-2,0,3,-5,2,-1]` → `prefix = [0,-2,-2,1,-4,-2,-3]`
`sumRange(2,5) = prefix[6] - prefix[2] = -3 - (-2) = -1 ✓`

**C# note:** `prefix` **class field** hona chahiye (constructor bharta hai, SumRange padhta hai) — local variable doosre method ko nahi dikhta (wahi rows/cols wala lesson).

**Interview line yaad rakh:** *"Preprocess once in O(n), answer each query in O(1)."*

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

### Product of Array Except Self (LeetCode 238)

**The problem:** Array diya hai, har element ke liye baaki sab ka product return karo. Division use nahi kar sakte.
Example: `nums = [1, 2, 3, 4]` → `[24, 12, 8, 6]`

**Brute force:** Har element ke liye baaki sab multiply karo. O(n²).

**The trick — left product × right product:**
Har index ka answer do parts mein tod sakte ho:
- Left side ka product = mere se pehle sab ka product
- Right side ka product = mere baad sab ka product
- Answer = left × right

**Kaise banayein — two passes:**
1. Left to right: running product rakhte jao, **pehle store karo, phir multiply karo** (taaki current element include na ho)
2. Right to left: same cheez ulta, directly result mein multiply karo

**Space trick:** Alag left aur right array mat banao. Result array mein left pass daalo, phir right pass directly uspe multiply karo. O(1) extra space.

**Real-life analogy:** Socho tum ek line mein khade ho. Tumhe jaanna hai ki tumhare **bina** sabke heights ka product kya hai. Toh pehle left se sabka product note karo (tumse pehle wale), phir right se (tumhare baad wale). Dono combine karo — tumhare bina sabka product mil gaya.

**Dry Run:** `nums = [1, 2, 3, 4]`

```
Left pass (prod = 1):
  i=0: result[0] = 1,  prod = 1×1 = 1    ← mere left mein kuch nahi, toh 1
  i=1: result[1] = 1,  prod = 1×2 = 2    ← left mein sirf nums[0]=1
  i=2: result[2] = 2,  prod = 2×3 = 6    ← left mein 1×2 = 2
  i=3: result[3] = 6,  prod = 6×4 = 24   ← left mein 1×2×3 = 6

result = [1, 1, 2, 6]  ← har index ke LEFT side ka product

Right pass (prod = 1):
  j=3: result[3] = 6×1 = 6,   prod = 1×4 = 4     ← right mein kuch nahi, toh ×1
  j=2: result[2] = 2×4 = 8,   prod = 4×3 = 12    ← right mein sirf nums[3]=4
  j=1: result[1] = 1×12 = 12, prod = 12×2 = 24   ← right mein 4×3 = 12
  j=0: result[0] = 1×24 = 24, prod = 24×1 = 24   ← right mein 4×3×2 = 24

result = [24, 12, 8, 6] ✓
```

**Yaad rakhne ka rule:** "Pehle store, phir multiply" — taaki current element apne answer mein include na ho.

**Complexity:** O(n) time — two passes. O(1) space — sirf output array.

---

## Pattern 7: Fast & Slow Pointers

**Core idea:** Do pointers — slow 1 step, fast 2 steps. Agar cycle hai toh milenge, nahi hai toh fast null pe pahunch jayega.
**When to use:** Cycle detection, middle of linked list, happy number, palindrome linked list.
**Real-life analogy:** Circular track pe do runners — ek slow, ek fast. Agar track circular hai toh fast slow ko zaroor lap karega aur dono milenge.

### Linked List Cycle (LeetCode 141)

**The problem:** Linked list mein cycle hai ya nahi?
**Approach:** Slow 1 step, fast 2 steps. Agar `slow == fast` → cycle hai. Agar fast `null` pe pahuncha → no cycle.
**Why check `fast.next != null`?** Kyunki fast 2 steps leta hai — `fast.next.next` call karne se pehle `fast.next` exist karna chahiye warna crash.

```csharp
while (fast != null && fast.next != null)
{
    slow = slow.next;
    fast = fast.next.next;
    if (slow == fast) return true;
}
return false;
```

**Complexity:** O(n) time, O(1) space.

### Linked List Cycle II (LeetCode 142)

**The problem:** Cycle detect toh kar liya. Ab batao cycle **kahan se** start hoti hai?

**Phase 1:** Same as above — slow aur fast chalao jab tak milein.

**Phase 2 — the math trick:**
Jab slow aur fast milte hain:
1. Ek pointer **head** pe bhejo
2. Doosra **meeting point** pe rehne do
3. Dono ko **1-1 step** se chalao
4. Jahan milenge → **wahi cycle start hai**

**Kaam kyun karta hai?**
```
A = head se cycle start tak ka distance
B = cycle start se meeting point tak
C = cycle ki length

Slow ne travel kiya: A + B
Fast ne travel kiya: A + B + C (ek extra round)
Fast double speed: 2(A + B) = A + B + C
Solve: A = C - B
```
Matlab: head se cycle start = meeting point se cycle start. Isliye dono 1-1 step se chalao → cycle start pe milenge.

**Dry Run:** `1 → 2 → 3 → 4 → 5 → 3 (cycle at node 3)`

```
A = 2 (head se cycle start: 1→2→3)
Cycle = 3→4→5→3 (length C = 3)

Phase 1 — find meeting point:
  Step 0: slow = 1, fast = 1
  Step 1: slow = 2, fast = 3
  Step 2: slow = 3, fast = 5
  Step 3: slow = 4, fast = 4   ← MILGAYE! Meeting point = node 4

Phase 2 — find cycle start:
  pointer1 = head (node 1)
  pointer2 = meeting point (node 4)
  
  Step 1: pointer1 = 2, pointer2 = 5
  Step 2: pointer1 = 3, pointer2 = 3   ← MILGAYE! → Node 3 = cycle start ✓
```

**Hindi mein samjho:**
Socho do dost hain. Ek sadak ke shuru se chalta hai, doosra us jagah se jahan pehle race mein mile the. Dono same speed se chalte hain. Jahan milenge — wahi woh jagah hai jahan sadak circular track se milti hai. Wahi cycle ka start hai.

**Complexity:** O(n) time, O(1) space.

### Reverse Linked List (LeetCode 206)

**The problem:** Linked list reverse karo. `1 → 2 → 3 → null` → `3 → 2 → 1 → null`

**Why 3 pointers?** Agar tum directly `curr.Next = prev` kar do, toh agla node lost ho jata hai. Isliye pehle `next` mein save karo.

**The 4 steps inside the loop:**
```
next = curr.Next      ← save the path forward (warna lost ho jayega)
curr.Next = prev      ← reverse the arrow
prev = curr           ← prev aage badhao
curr = next           ← curr aage badhao
```

**Why `while (curr != null)` not `curr.Next != null`?**
Agar condition `curr.Next != null` ho, toh last node (jiska next null hai) reverse hi nahi hoga. Hamesha `curr != null` use karo.

**Return kya karoge?** `prev` — kyunki jab loop exit hota hai, `curr = null` aur `prev` last node pe hota hai (jo naya head hai).

**Dry Run:** `1 → 2 → 3 → null`

```
Initial: prev = null, curr = 1

Step 1: next = 2, curr.Next = null, prev = 1, curr = 2
        State: null ← 1    |    2 → 3 → null

Step 2: next = 3, curr.Next = 1, prev = 2, curr = 3
        State: null ← 1 ← 2    |    3 → null

Step 3: next = null, curr.Next = 2, prev = 3, curr = null
        State: null ← 1 ← 2 ← 3

Loop ends. Return prev = 3. ✓
```

**Real-life analogy:** Ek line mein log khade hain, sab aage dekh rahe hain. Tum chahte ho sab peeche dekhein. Har person ke paas jao, usko peeche mudne bolo — lekin pehle **agla person kaun hai yaad rakh lo**, warna line mein kahan hai pata nahi chalega.

**Complexity:** O(n) time, O(1) space.

---

## Pattern 3: Intervals + Min-Heap

**Problem:** Meeting Rooms II
**Core trick:** Sort by start time — you can't assign rooms if meetings arrive out of order. Think of it like a queue: first to arrive gets handled first. Min-heap tracks when each room becomes free. If the earliest free room is free before this meeting starts → reuse it (Dequeue). Otherwise → open a new room. Heap size at the end = total rooms needed.
**Overlap condition:** Two intervals overlap if `A.end > B.start AND B.end > A.start`
**Complexity:** O(n log n) time, O(n) space
**When to use:** Interval scheduling, resource allocation, "minimum number of X needed" problems.

**Hindi mein samjho:**
Socho tum ek hotel ke manager ho aur meetings ki list hai (har ek ka start–end time). Batana hai **kitne kamre** chahiye taaki koi meeting bina kamre ke na rahe. Pehle sab meetings **start time se sort** karo (jo pehle aaya, pehle settle hoga). Min-heap mein rakho har kamre ka "kab khaali hoga" time. Nayi meeting aaye toh dekho — jo kamra sabse pehle khaali ho raha hai (heap ka top), kya woh is meeting ke **start se pehle** khaali ho gaya? Haan → wahi kamra reuse karo (Dequeue, phir naya end Enqueue). Nahi → **naya kamra** kholo (Enqueue). Aakhir mein heap ka size = total kamre chahiye.

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

**Hindi mein samjho:** Palindrome matlab aage se aur peeche se same padhe (jaise "NITIN" ya "MALAYALAM"). Do ungli rakho — ek shuru pe, ek aakhir pe — andar ki taraf badhao aur har step pe compare karo. Beech mein jo spaces/special characters aayein unhe `continue` se skip karo, aur case ignore karne ke liye `char.ToLower`. Real-life: do log ek kitaab ke dono kinaron se ek-ek page padhte hue beech mein milte hain — agar har page match hua toh palindrome.

### Container With Most Water (LeetCode 11)
- Area = `Math.Min(height[left], height[right]) * (right - left)`
- Always move the **shorter** pointer — width shrinks, so only taller height can help
- O(n) time, O(1) space

**Hindi mein samjho:** Socho do deewarein hain aur unke beech paani bharna hai. Paani ki height = **chhoti waali deewar** (kyunki badi deewar usse zyada paani rok nahi sakti — upar se overflow ho jayega). Width = dono ke beech ki doori. Do pointer rakho — ek bilkul shuru, ek bilkul aakhir (sabse zyada width). Ab **hamesha chhoti deewar waala pointer aage badhao**. Kyun? Width toh har step pe ghategi hi — toh area sirf tabhi badh sakta hai jab height badhe, aur height tabhi badhegi jab **chhoti** deewar hatao. Badi deewar hatane ka koi fayda nahi, kyunki paani toh chhoti deewar hi decide kar rahi thi.
> ⚠️ **Yeh tera weak spot hai — pakka yaad rakh: CHHOTA hatao, bada nahi.**

### Two Sum II — Sorted (LeetCode 167)

**The problem:** Two Sum hi hai — do numbers, sum = target — par array **SORTED** hai. (Answer 1-indexed — return mein `+1`!)

**Signal → Tool ka lesson:** "Sorted" ne tool badal diya. HashMap ab bhi chalega (O(n) space), par sorted + **pair** dhoondhna → **Two Pointers → O(1) space.** ("Sorted" ki do ghantiyan: ek target → Binary Search; pair/triplet → Two Pointers.)

**Rule:**
```
sum > target  →  right--   (chhote number ki taraf, sum ghatega)
sum < target  →  left++    (bade number ki taraf, sum badhega)
sum == target →  mil gaya
```
**Sorted hi kyun chahiye:** left++ *guaranteed* badhaata hai, right-- *guaranteed* ghataata hai — deterministic navigation. Unsorted mein yeh guarantee nahi → wahan HashMap.

**⚠️ Complexity misconception (interview trap):** "beech mein milte hain toh O(log n)"? **NAHI.** Do dost sadak ke dono ends se **chal ke** beech mein milte hain — milte beech mein hain, par **poori sadak** chalte hain. Har step ek pointer ek kadam → gap har baar 1 ghatta hai → **O(n).** O(log n) tab jab har step **aadha space phenko** (Binary Search kudta hai). **Rule: "Ek-ek kadam = O(n). Aadha-aadha phenko = O(log n)."**

**Complexity:** O(n) time, O(1) space.

**Hindi mein samjho:** Sorted line mein sabse halka (left) aur sabse bhaari (right) bande ko jodi banao. Jodi ka wazan zyada → bhaari waale ko halke se badlo (right--). Kam → halke waale ko bhaari se badlo (left++). Har baar exactly ek hi samajhdaar move hai — yahi sorted ka jaadoo.

### 3Sum (LeetCode 15)
- Sort first → duplicates are adjacent → easy to skip
- Fix one number, Two Pointers on the rest → reduces to Two Sum
- Skip `i` duplicates: `if (i > 0 && nums[i] == nums[i-1]) continue;` — compare backward to skip second occurrence, not first
- After finding triplet: skip duplicate lefts and rights with while loops, then `left++; right--;`
- O(n²) time, O(1) space

**Hindi mein samjho:** Teen number dhoondhne hain jinka sum 0 ho. Pehle array **sort** karo — isse same numbers aas-paas aa jaate hain (skip karna easy). Ab ek number **fix** karo (outer loop), baaki do ke liye problem Two Sum ban gayi — `left` aur `right` pointer chalao. Sum zyada hai toh `right--` (chhota karo), kam hai toh `left++` (bada karo), exact 0 mila toh triplet add karo. Duplicate numbers skip karo warna same triplet baar-baar aayega. Real-life: ek dost ko fix karo, phir baaki dosto mein se aise do dhoondho jo us pehle dost ke saath milke total 0 bana dein.

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

**Hindi mein samjho:** Dictionary mein word dhoondhne jaisa — beech se kholo. Jo dhoond rahe ho woh `mid` se aage hai ya peeche? Jis taraf nahi hai woh **aadha hissa hata do**, baaki aadhe mein wahi dohrao. Har step pe search space aadha — isliye O(log n). `mid = left + (right - left) / 2` likho (seedhe `(left+right)/2` se overflow ho sakta hai). Mil gaya → `mid` return; nahi mila → `-1`.

### First Bad Version (LeetCode 278)
- Boundary search — find where false flips to true
- `right = mid` (not `mid - 1`) because mid might be the answer
- `left < right` (not `<=`) to avoid infinite loop
- O(log n) time, O(1) space

**Hindi mein samjho:** Socho versions ki line hai — pehle sab theek (good), phir ek point ke baad sab kharab (bad). Tumhe **pehla kharab** version dhoondhna hai. `mid` check karo: kharab hai? Toh answer yahi ya isse pehle ho sakta hai → `right = mid` (`mid` ko mat chhodo, woh khud answer ho sakta hai). Theek hai? Toh answer aage hai → `left = mid + 1`. `left < right` use karo warna infinite loop. Real-life: doodh ki bottles ki line — kahaan se kharab milna shuru hua, wahi **pehli kharab bottle** dhoondhni hai.

### Search in Rotated Sorted Array (LeetCode 33)
- Array is sorted but rotated at some pivot
- Key insight: at any mid, **one half is always sorted**
- Check which half is sorted: `nums[left] <= nums[mid]` → left half sorted
- Check if target falls within the sorted half's **range** (both bounds!) — not just one side
- O(log n) time, O(1) space

**Hindi mein samjho:** Socho ek sorted list thi `(1,2,3,4,5,6,7)` par kisi ne usse kahin se **ghuma diya (rotate)** — ab woh aisi `(4,5,6,7,1,2,3)`. Phir bhi jab tum beech (`mid`) pe dekhte ho, **ek na ek half hamesha properly sorted hota hai**. Pehle pata karo kaunsa half sorted hai (`nums[left] <= nums[mid]` → left half sorted). Phir dekho tumhara target us sorted half ki **range ke andar** aata hai ya nahi (**dono bounds** check karo!) — haan toh udhar jao, nahi toh doosre half mein. Real-life: ghadi (clock) ke numbers ko kahin se kaat ke ghuma diya — phir bhi aadha hissa sequence mein rahega, usi sorted half ko anchor banao.

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

## Pattern 8: Monotonic Stack

**Core idea:** Ek stack jo hamesha sorted rehta hai (increasing ya decreasing). Jab naya element aata hai jo purane "bekaar" elements ko obsolete kar deta hai, unhe pop kar do. Wahi "bekaar ko nikaal do" soch jo Monotonic Deque (Sliding Window Max) mein thi — bas yahan ek hi end (stack / LIFO).
**When to use:** "Next greater/smaller element", "next warmer day", "kitni door tak wait" — jab har element ke liye aage/peeche ka pehla bada/chhota dhoondhna ho.
**Real-life analogy:** Logo ki line jo apne "garam din" ka wait kar rahi hai. Jab ek garam din aata hai, woh peeche khade saare thande dino ka wait **ek-ek karke, sabse haal wale se** khatam karta hai (LIFO). Jo kisi garam din ke intezaar mein reh gaye → unka answer 0.

### Daily Temperatures (LeetCode 739)

**The problem:** Har din ke liye batao kitne din baad garam din aayega. Aage koi garam nahi → 0.
Example: `[73,74,75,71,69,72,76,73]` → `[1,1,4,2,1,1,0,0]`

**Brute force:** Har din se aage scan karo jab tak garam na mile. O(n²) (decreasing array mein har `i` poora aage scan karega).

**The trick — perspective ulto:** "Har din apna garam din dhoondhe" ki jagah socho "aaj ka garam din kin **pichle** dino ka wait khatam karta hai." Waiting days hamesha **decreasing order** mein hote hain (agar koi pichla din aaj se thanda nahi hota toh woh pehle hi resolve ho gaya hota). Naya garam din **recent (top)** se resolve karta hai → **Stack**.

**Store INDICES, not temperatures** — kyunki answer `i - k` (kitne din ka gap) chahiye, jo sirf index se nikalta hai. (Wahi SW Max wali seekh: value batati hai "kaun", index batata hai "kahan / kitna door".)

**The algorithm:**
1. `for` har din `i` pe
2. `while` stack ka top aaj se thanda hai (`temps[stack.Peek()] < temps[i]`): pop karo `k`, phir `result[k] = i - k`
3. `stack.Push(i)`
4. Jo stack mein reh gaye → answer `0` (default array value)

**Dry Run:** `temps = [73, 74, 75, 71, 69, 72, 76, 73]`

```
i=0 (73): stack khaali → push 0.                          stack=[0]
i=1 (74): top=73 < 74 → pop 0, result[0]=1-0=1. push 1.   stack=[1]
i=2 (75): top=74 < 75 → pop 1, result[1]=2-1=1. push 2.   stack=[2]
i=3 (71): top=75 < 71? nahi → push 3.                     stack=[2,3]
i=4 (69): top=71 < 69? nahi → push 4.                     stack=[2,3,4]
i=5 (72): top=69<72 → pop 4, result[4]=1; top=71<72 → pop 3, result[3]=2;
          top=75<72? nahi → push 5.                       stack=[2,5]
i=6 (76): top=72<76 → pop 5, result[5]=1; top=75<76 → pop 2, result[2]=4;
          push 6.                                         stack=[6]
i=7 (73): top=76 < 73? nahi → push 7.                     stack=[6,7]

result = [1, 1, 4, 2, 1, 1, 0, 0]  ✓  (indices 6,7 stack mein reh gaye → 0)
```

**Complexity:** O(n) time — har index ek baar push, ek baar pop (amortized; nested `while` dikhne ke bawajood O(n²) NAHI). O(n) space — stack worst case saare indices (strictly decreasing array).

**Yaad rakhne ka rule:** "Naya bada/garam element aaya → peeche ke chhote/thande ka hisaab chukta kar do (pop) — unka answer abhi `i - k` hai."

### Next Greater Element I (LeetCode 496)

**The problem:** `nums1` (jo `nums2` ka subset hai) ke har element ke liye, `nums2` mein uske **right ka pehla bada** element. Na mile → `-1`.
Example: `nums1=[4,1,2]`, `nums2=[1,3,4,2]` → `[-1, 3, -1]`

**The twist — do array:** Stack **`nums2`** pe chalao (next greater wahin dhoondhna hai). Har element ka next greater nikaal ke ek **HashMap** mein daalo: `{value → next greater}`. Phir `nums1` sirf **O(1) lookup**. (nums2 distinct hai → saaf key→value map, koi clash nahi.)

**Daily Temps se farak:** wahan **distance** (`i-k`) chahiye tha → stack mein **index**. Yahan **value** chahiye + nums2 distinct → stack mein seedhe **value** daal sakte ho.

**`-1` kaise:** Jo elements stack mein reh gaye (koi next greater nahi) woh map mein aate hi nahi → `nums1` lookup pe `dict.ContainsKey` false → `-1`. (Leftover ko alag se -1 map karne ki zaroorat nahi.)

**Complexity:** O(m + n) time (m=nums2, n=nums1 — stack pass amortized O(m) + lookups O(n)). O(m) space.

### Next Greater Element II (LeetCode 503) — circular

**The problem:** Single **circular** array — har element ka next greater (end ke baad shuru se wrap karke). Na mile → `-1`.
Example: `[1,2,1]` → `[2,-1,2]` (aakhri `1` wrap karke `2` paata hai)

**Daily Temps / NGE I se farak:** ek hi array (HashMap nahi chahiye — `result[idx]` seedha bharo), aur **circular**.

**Circular trick:** Loop `2*n` baar, `idx = i % n` (end ke baad wrap to 0). Do passes taaki har element ko apna wrapped next-greater dhoondhne ka mauka mile. **Push sirf pehle pass mein** (`i < n`) — second pass ke elements naye nahi, wahi purane jo already stack pe hain; unhe sirf resolve karna hai. Default `result = -1` (`Array.Fill`).

**Dry Run:** `nums = [1, 2, 1]`, n=3, loop 0..5

```
result = [-1,-1,-1]
i=0 (idx0, 1): stack empty → push 0.              stack=[0]
i=1 (idx1, 2): nums[0]=1<2 → pop 0, result[0]=2. push 1.   stack=[1]
i=2 (idx2, 1): nums[1]=2<1? no → push 2.          stack=[1,2]
i=3 (idx0, 1): nums[2]=1<1? no. i<3? no.          stack=[1,2]
i=4 (idx1, 2): nums[2]=1<2 → pop 2, result[2]=2. nums[1]=2<2? no. i<3? no.   stack=[1]
i=5 (idx2, 1): nums[1]=2<1? no. i<3? no.          stack=[1]

result = [2, -1, 2]  ✓   (index 1 ka 2 → koi bada nahi → -1)
```

**Complexity:** O(n) time — loop `2n` = O(n) (constant drop), har index ek baar push/pop. O(n) space.

---

## Pattern 9: DFS / BFS (Tree & Graph Traversal)

**Mental model — sab kuch GRAPH hai (yeh sabse zaroori samajh):**
DFS/BFS **trees** ke baare mein NAHI — **graphs** ke baare mein hai. Tree aur grid **dono** graph ke roop hain. Graph = **nodes + neighbors (connections)**. DFS/BFS ka kaam ek hi: *"apne node pe khade ho, apne **neighbors** explore karo."* Har problem mein sirf **"neighbors kaun?"** badalta hai:

| Structure | Node | Neighbors kaise milte hain |
|---|---|---|
| **Tree** | ek TreeNode | `node.left`, `node.right` (children) |
| **Grid** | ek cell `(r,c)` | 4 adjacent: `(r±1,c)`, `(r,c±1)` |
| **Graph** | ek vertex | adjacency list `adj[node]` |

Grid ko tree mein "badalne" ki koshish **mat** karo — dono ko **graph** samjho. Number of Islands ke 4 `dfs` calls = "4 neighbors visit karo" = tree ke `dfs(left); dfs(right)` ka hi grid-version. Farak: grid mein **cycle** ho sakti hai → `visited` chahiye; tree mein nahi.

**Core idea:** Ek structure (tree/graph) ke saare nodes "explore" karna. Do strategies:
- **DFS (Depth-First):** Ek raasta end tak jao, dead-end pe backtrack. Tool: **Stack ya Recursion** (recursion khud system ka call-stack use karta hai). Analogy: maze (bhulbhulaiya) solve karna.
- **BFS (Breadth-First):** Level-by-level phailo (paas wale pehle). Tool: **Queue (FIFO)**. Analogy: paani mein patthar → ripples. **Shortest path** ke liye best.

**Traversal order — tree example:**
```
        1
       / \
      2   3
     / \   \
    4   5   6
```
- **BFS** (level by level): `1 2 3 4 5 6`
- **DFS** (preorder — node, phir left subtree pura, phir right): `1 2 4 5 3 6`
- **Rule:** kisi node tak uske **parent ke through** hi pahunchte ho → preorder mein parent hamesha pehle (isliye `6` se pehle uska parent `3`).

**Trees vs Graphs — the `visited` set:**
- Trees mein **cycle nahi** (har node ka ek parent). Graphs mein **cycle ho sakta** hai (A→B→C→A).
- Bina track kiye graph pe DFS/BFS = **infinite loop**.
- Fix: ek **`visited` set (HashSet)** rakho. Node process karne se pehle: `if (visited.Contains(node)) skip; else visited.Add(node)` phir explore. HashSet = O(1) "pehle dekha kya?" check.

**When to use:** Tree/graph traversal, connected components, **shortest path (BFS)**, "does a path exist", flood fill / number of islands, level-order.

### Maximum Depth of Binary Tree (LeetCode 104)

**The problem:** Tree ki max depth = root se sabse door leaf tak kitne nodes.

**DFS recursion — "maan le subproblem solved hai":**
- **Base case:** `node == null` → depth `0`
- **Combine:** poore tree ki depth = `1 + max(left subtree depth, right subtree depth)`. Woh `1` current node ko gin-ta hai (warna ek akela leaf node `0` aa jaata).
- "Magic jo X aur Y deta hai" = function ka **khud ko call karna**: `MaxDepth(node.left)`, `MaxDepth(node.right)`. Recursion = subproblem solved maan ke combine karo.

```csharp
public int MaxDepth(TreeNode root)
{
    if (root == null) return 0;
    return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
}
```

**Complexity:** O(n) time (har node ek baar visit). O(h) space — recursion ka call-stack tree ki **height** tak jaata hai (balanced → O(log n), skewed → O(n)).

### Number of Islands (LeetCode 200)

**The problem:** Grid of `'1'` (zameen) / `'0'` (paani). Kitne islands (4-directionally judi zameen) count karo.

**Approach — DFS flood fill:**
- Har cell pe loop. Jab ek **nayi unvisited `'1'`** mile → naya island → `count++`, phir us cell se DFS.
- DFS poore judi hui island ko **"sink"** kar deta hai (`'1'` → `'0'`) taaki dobara na gine.
- `count` = kitni baar **naya DFS shuru** hua.

**DFS helper:**
- **Base case (ORDER matters!):** bounds PEHLE, phir `'0'` check:
  `if (r<0 || r>=rows || c<0 || c>=cols || grid[r][c]=='0') return;`
  (bounds pehle warna out-of-bounds pe `grid[r][c]` access → IndexOutOfRange crash)
- Sink: `grid[r][c] = '0';` (base case ke baad cell pakka `'1'` hai, koi `if` nahi chahiye)
- Recurse **4 directions** (up/down/left/right — **diagonal NAHI**)

**Kab rukta hai / poori grid ek island kyun nahi:** Paani (`'0'`) har island ki deewar hai — DFS paani pe return karta hai, doosre island tak nahi pahunchta. Visited land ko `'0'` bana diya → dobara process nahi (no infinite loop).

**Gotcha — char:** grid `char[][]` hai → `'1'`/`'0'` **quotes** ke saath. `'1'` ki value `49` hai, `1` nahi — int se compare kabhi match nahi karega.

**Complexity:** O(m×n) time (har cell constant baar). O(m×n) space worst case — agar poori grid ek hi island ho, recursion stack saap ki tarah saare cells tak gehra ja sakta hai (m+n nahi).

### Binary Tree Level Order Traversal (LeetCode 102) — BFS

**The problem:** Har level ke nodes ek alag list mein. `[[3],[9,20],[15,7]]`.

**BFS + level-size snapshot (yahi trick hai):**
- Queue mein root daalo.
- `while` queue khaali nahi:
  - **`int levelSize = queue.Count;`** ← level ke shuru mein queue mein **sirf us level ke nodes** hote hain, toh count = us level ki node-ginti. **Loop se PEHLE snapshot lo** (loop ke andar children enqueue karne se `queue.Count` badhta hai).
  - `for i in 0..levelSize`: dequeue → `val` ek `level` list mein → non-null children enqueue (= agla level).
  - `result.Add(level);` — poora level = **ek entry** (`AddRange` NAHI — woh level ke ints ko result mein daal deta, par result list-of-lists hai).

**DFS vs BFS — ek hi algorithm:** bas **queue ↔ stack** ka farak. Queue (FIFO) → level-by-level (BFS). Stack (LIFO) → deep-first (DFS). Isi code mein queue ki jagah stack daal do → DFS ban jayega. (DFS recursion mein woh stack = system ka call-stack.)

**Complexity:** O(n) time (har node ek baar enqueue/dequeue). O(n) space — queue worst case sabse **chaudा level** (~n/2 nodes, complete tree ka last level).

### Rotting Oranges (LeetCode 994) — Multi-source BFS

**The problem:** Grid: `0` khaali, `1` fresh, `2` rotten. Har minute rotten apne 4 padosi fresh ko rot karta hai. Kitne minutes mein sab rot? Kabhi nahi → `-1`.

**Multi-source BFS (naya concept):** Level Order mein queue ek root se shuru hui thi. Yahan **saare shuru ke rotten (`2`) ek saath** queue mein — kai starting points, sab ek saath failte hain. Har **BFS level = 1 minute** (wahi `levelSize` snapshot).

**3 phases:**
1. **Scan:** har `2` → queue mein **position** `(r,c)` daalo (tuple); har `1` → `freshCount++`
2. **BFS:** `while (queue.Count > 0 && freshCount > 0)`: `minutes++`, snapshot, har dequeued cell ke **4 padosi seedha** dekho — valid + fresh → rot (`=2`), `freshCount--`, **enqueue**
3. **Result:** `freshCount == 0 ? minutes : -1`

**⚠️ DFS-instinct wali galti (khud ki thi, yaad rakhna):** padosi pe **recursion mat lagao** — woh flood fill (DFS) hai, ek hi minute mein sab rot jaayega. BFS mein padosi ko sirf **queue mein daalo** — failane ka kaam queue karegi, **agle** minute mein. **Queue hi BFS ka "recursion" hai.**

**⚠️ Bounds ka rule (har direction ka EK khatarnaak side):**
- `+1` wale (down/right) → upar se bahar ja sakte ho → check `r+1 < rows` / `c+1 < cols`
- `-1` wale (up/left) → **0 se neeche** gir sakte ho → check `r-1 >= 0` / `c-1 >= 0` (`< rows` likhna bekaar — hamesha true)

**Edge cases (freshCount guard se free mein handle):** koi fresh hi nahi → while nahi chala → `0`. Fresh hai par rotten nahi → queue khaali → `-1`.

**Complexity:** O(m×n) time (scan + har cell max ek baar enqueue/dequeue). O(m×n) space (worst case sab rotten, sab queue mein).

**Hindi mein samjho:** Aag jaisi hai — kai jagah ek saath lagi hai (multi-source). Har minute mein aag **sirf ek ghar** aage badhti hai, chaaron taraf. Recursion lagate toh poora mohalla ek minute mein jal jaata (galat). Queue mein daalne ka matlab: "yeh ghar ab jal raha hai, agle minute yeh apne padosiyon ko jalaayega." Ginti rakho kitne ghar bache — end mein bache toh wahan aag kabhi pahunchi hi nahi (`-1`).

### Max Area of Island (LeetCode 695)

**The problem:** Grid `0`/`1` (**int** — chars nahi is baar!). Sabse bade island ka **area** (cell count). Koi nahi → 0.

**Do purane problems ka sangam:** Number of Islands (flood fill) + Max Depth (**value-returning recursion**).

**Core — dfs ab int LAUTATA hai:**
- Base case: bounds ke bahar YA `0` (paani/visited) → `return 0`
- Sink pehle (`grid[i][j] = 0`) — taaki padosi wapas poochhe toh 0 mile (no double-count, no infinite loop)
- `return 1 + dfs(niche) + dfs(upar) + dfs(right) + dfs(left)`
  - **`1`** = main khud ek cell
  - **SUM, Max nahi** — area = saare cells ka TOTAL. (Max Depth mein `Math.Max` tha kyunki wahan sabse LAMBA raasta chahiye tha. Yahan sab jodna hai.)
- **Recursion samajh:** har dfs call bas ek **number** lautati hai ("us taraf itne cells the") — use variable mein pakdo, jodo. Andar ki calls apna kaam khud sambhalti hain — tu sirf apna level soch.

**Main loop:** har `1` pe `area = dfs(i,j)` → `maxArea = Math.Max(maxArea, area)`. (dfs ke **andar SUM** — ek island ka total; **main mein MAX** — islands ke beech sabse bada.)

**⚠️ C# traps (aaj ke):**
- `if (condition);` ← **semicolon after if** = khaali statement; neeche wala block HAR BAAR chalega. Compile ho jaata hai, chupchaap galat. Kabhi `;` mat lagao `if` ke baad.
- Class field `int rows = grid.Length;` nahi ban sakta — `grid` method ka parameter hai, field use nahi dekh sakta. Fields khaali declare karo, method ke andar assign karo.

**Complexity:** O(m×n) time, O(m×n) space (worst case recursion stack — poori grid ek island).

### Min Score of a Path Between Two Cities (LeetCode 2492) — FIRST GRAPH

**The problem:** n cities, bidirectional weighted roads `[a, b, dist]`. Path ka score = us path ki **sabse chhoti** road. Roads/cities **dobara use allowed**. 1 se n ka minimum possible score?

**The insight (derive karo, ratto mat):** "Same road multiple times allowed" → tu **kahin bhi ghoom ke wapas aa sakta hai.** Toh 1 se REACHABLE har road tere path mein aa sakti hai (jao → cross karo → wapas → phir n tak). 1 aur n same component mein hain (guaranteed) →
> **Answer = city 1 ke connected component ki sabse chhoti edge. Path-finding ki zaroorat hi nahi!**

**Adjacency List (naya concept — graph ka "phone book"):**
- Roads edge-list mein aate hain; DFS/BFS ko chahiye "is node ke padosi kaun?" → adjacency list banao.
- **Almari analogy:** `new List<(int,int)>[n+1]` = **array** (almari, fixed n+1 drawers — end ka `[n+1]` array banata hai, `List<>` sirf element ka type). Har drawer mein **List** (expandable file). `n+1` kyunki cities 1..n aur array 0-indexed — slot 0 waste, par `city-1` ke bugs se bachao.
- **Do steps:** (1) array banao — slots NULL hote hain; (2) loop se har slot mein `new List<(int,int)>()` — warna `.Add` null pe crash.
- Har road **dono pages** pe: `adj[a].Add((b,d)); adj[b].Add((a,d));` (bidirectional).

**BFS over DFS-recursion kyun:** n = 1e5 tak → line-jaisa graph = 1e5 deep recursion → **StackOverflow.** Queue heap pe hoti hai — safe.

**Edge-check placement:** `minScore = Math.Min(minScore, dist)` **HAR padosi entry pe** — chahe padosi visited ho (sadak ka distance count hona chahiye). Sirf **enqueue** visited-check ke peeche hai.

**Complexity — GRAPH ka formula (naya):** **O(V + E)** time (V=cities, E=roads) — har city ek baar dequeue, har road ki 2 entries ek-ek baar scan. `+` isliye kyunki dono alag-alag ginti hain. Space O(V + E).

**C# traps (aaj ke):**
- **Array → `.Length`; List/Queue/HashSet/Dictionary → `.Count`**
- Tuple kholna: `var (city, dist) = ...` (`var`, `int` nahi)
- `return` loop ke ANDAR chala gaya tha (braces!) → **indentation rakho, brace bugs khud dikhte hain**

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
