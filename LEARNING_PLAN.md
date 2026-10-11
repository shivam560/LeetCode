# Adaptive interview preparation

Updated: 2026-10-11, 18:06 IST. Goal: Google and other big-tech engineering interviews. This is persistent workspace context for future sessions, not a guarantee of cross-app memory or hiring outcomes.

## How to coach Shivam

- Derivation-first teaching (explicit request Oct 11): show the straightforward guarded implementation before moving its condition into a loop bound. Derive remaining subproblem, valid indices, and boundaries; distinguish loop direction from loop limits. Example: currentSum-currentNumber >= 0 implies currentSum >= currentNumber; descending order separately prevents same-index reuse.
- Give meaningful uninterrupted attempts, not prolonged micro-questions or repeated full-method copying. Repeated misunderstanding requires a different representation (actual subsets, complete tables, or traces), then a fresh independent attempt. Distinguish syntax repairs from conceptual assistance.
- Do not infer active study time from chat timestamps. Keep saved artifacts current; explicitly distinguish chat-reviewed code, source saved on disk, executed tests, and platform acceptance. Use HANDOFF.md for portable current context.

- Solution-file convention (explicit user request Oct 7): every question solution must include top comments describing the problem and at least one concrete input/output example. Keep these above implementation, preserve existing useful headers, and apply to future saved solutions too. Do not confuse pedagogical assumptions with platform constraints.

- Explain from basics in Hinglish, retain English problem vocabulary, and use C#.
- Begin with a short independent attempt. Ask what the state means before asking for a recurrence.
- Keep the example and dictionary fixed during a trace. Show each call's own start/end values and the suspended parent when needed.
- If the same misunderstanding recurs twice, explain directly using a complete worked example, a call-stack sketch, or a debugger. Then ask for a new independent trace. Avoid prolonged leading yes/no questions.
- Distinguish conceptual errors from C# syntax mistakes. Explain syntax briefly; assess reasoning separately.
- Fade assistance: worked example, partially supported attempt, independent attempt, delayed recall, unfamiliar variation.
- Use feedback to adjust pacing. Do not interpret fast prompted answers as mastery or difficulty as a judgment of ability.
- Measure what happened, including help used. If time was not measured, record it as unmeasured.

## Session structure

Default session: about 45–60 minutes when available; shorten to 15–20 minutes of review on low-energy days. This is a starting proposal, not a fixed daily obligation.

1. Check local date/time and read the latest handoff. Select one due recall item.
2. Spend 5–10 minutes recalling without notes; ask for reasoning and a complete trace, not just blanks.
3. Spend 25–35 minutes on one focused problem or misconception, adjusting support as needed.
4. Ask for an independent explanation or implementation and meaningful edge cases.
5. Discuss complexity, including actual C# operations. Save a short session note and next task.

Review after roughly 1, 3, 7, 14, and 30 days. If recall fails, provide corrective explanation and revisit sooner. If a session is missed, reassess on return; do not accumulate a punitive backlog. No reminder automation is implied.

## Performance record

Use these categories separately: state/problem understanding; approach derivation; implementation; testing and complexity; delayed recall; transfer to an unfamiliar variation.

For each category use: untested, guided, one hint, independent. Record the date and evidence. Avoid a combined numerical score until sufficient independent evidence exists.

Assistance levels: H0 = no hints or notes; H1 = one conceptual hint; H2 = repeated hints or scaffold; H3 = worked solution shown. A later same-session reconstruction after H3 remains practice, not a cold H0 attempt.

Session record fields: date/time, problem/variant, assistance, observed result, recurring mistake, explanation adjustment, next recall, next action. Record solve time only if measured. Track whether code was read, run, or accepted as distinct outcomes.

Working mastery gate: independently explain state/invariant, derive and implement, test edge cases, justify complexity, recall after a gap, and solve at least one unfamiliar variation. This is our coaching criterion, not a company's hiring rubric.

## Current baseline

Historical tracker contains 34 logged problems before Word Break. They provide useful exposure evidence; current retention across old patterns needs sampling rather than wholesale relearning.

| Area | Evidence | Current assessment |
| --- | --- | --- |
| Word Break bottom-up | Correct complete method reconstructed after extensive practice; explained prefix validity and both split conditions | Guided success; delayed recall and transfer untested |
| Word Break top-down | Eventually explained suffix meaning and traced child failure/parent continuation with help | Guided; independent control-flow trace needed |
| C# mechanics | Earlier bool-array size, casing, loop bounds and Substring length mistakes; later corrected | Continue short contextual checks |
| Complexity | Recognized n states times n endings and linear DP storage after prompts | Guided; C# cost explanation needs independent recall |
| Older patterns | Prior logs cover hashing, windows, pointers, binary search, prefix sums, stacks, linked lists, trees/graphs and introductory DP | Historical status; sample delayed recall |
| System design and behavioral | No assessed performance in this session | Untested |

Do not label Word Break mastered. No program execution or LeetCode acceptance was verified in this session.

## Roadmap: adaptable six-month horizon

The six-month horizon reflects Shivam's stated goal, not a promised finish date. Phase durations are planning estimates; adjust every week from evidence and available time. Specific hiring processes must be verified when an interview is scheduled.

| Phase | Approximate window | Work | Progress gate |
| --- | --- | --- | --- |
| Consolidate foundations | Weeks 1–3 | Word Break cold recall; recursion frames and returns; sample Coin Change, House Robber, binary search and BFS/DFS | Independent trace and code on familiar material after a gap; identify actual weak spots |
| Broaden pattern coverage | Weeks 4–9 | Address gaps in linked lists, intervals/heaps, backtracking, greedy, topological sort, union find; keep old-pattern recall | Explain why a pattern applies and solve a representative variation with decreasing help |
| Extend DP and combine patterns | Weeks 10–15 | LIS after readiness check; selected 2D DP; mixed graph/tree/window tasks without pattern labels | Derive states and transitions on unfamiliar tasks; test alternatives and edge cases |
| Interview practice | Weeks 16–20 | Gradually timed mixed coding; communicate, test, debug; practice design and behavioral discussions | Increasing independence across several representative sessions, not one lucky solve |
| Targeted readiness and applications | Weeks 21–26 | Mock interviews, recurring-gap repair, resume/project stories, role-specific preparation | Review several recent mocks together; identify remaining gaps and choose application timing |

Parallel track: begin one system-design or behavioral session per week once sustainable, replacing a DSA slot rather than automatically adding hours. For backend roles, practice requirements, API/data models, capacity estimates, caching, queues, consistency and failure tradeoffs. Prepare concrete project stories about ownership, collaboration, conflict, failures and impact. Confirm target role/level and realistic weekly availability naturally before increasing workload; do not assume old schedule or years of experience are current.

Confirmed availability (2026-09-17): Shivam can sustainably study 7–10 focused hours per week. Use 7 hours as the baseline; the extra 3 hours are optional, not an obligation or catch-up debt.

Seven-hour weekly allocation: 3 hours focused DSA learning/problem solving, 2 hours spaced recall and independent re-solving, 1 hour mixed assessment plus feedback, and 1 hour system design or behavioral communication. Initially assessments can be untimed; introduce interview timing gradually. Optional hours go toward demonstrated gaps, not arbitrary extra problem counts. Distribute around work and rest rather than imposing fixed daily times.

Agreed curriculum: NeetCode 150 is the main problem checklist; use Striver A2Z selectively for foundation explanations and additional practice. Preserve existing completed work and assess retention; do not restart both lists from scratch. Solutions remain in C#.

Readiness estimate is provisional: the prior 4–6 month discussion was a planning range, not an assessed forecast. Reassess after 2–3 weeks of independent attempts, delayed recall and available design evidence. Extend the horizon if needed; do not infer readiness from hours or checklist completion alone.

Every weekly review: compare delayed recall, hints needed, repeated error types and independent transfer. If gaps persist, change instruction and problem selection. If recall is strong, reduce repetition and introduce variation. Never optimize only for solved count or streaks.

## Latest session handoff

Current handoff — 2026-10-11, 18:06 IST: Target Sum (LC 494) 2D and 1D practiced. 2D full algorithm reconstructed without new code hints on Oct 10 after extensive prior scaffolding; one missing semicolon, state still described as boolean, two of three initial test predictions correct. Oct 11 correctly recalled count-state, P=1 and four sign assignments for [0,1,1], target 0. 1D method completed with H2/H3 assistance: base initialization, return type, naming and total-sum/current-sum lookup repaired. Whole trace [0,1,1] eventually correct. Later fresh [0,0,2], target -2 trace independently gave P=0, [1]->[2]->[4]->[4], loop skip and answer 4; last written sign expression needed -2 correction. This is positive independent trace evidence, not independent full-method mastery. Runtime/acceptance not verified. Recent Target Sum implementations and LIS optimized implementation exist in chat but are not yet saved as source files; avoid claiming otherwise.

Exact next task: user agreed to begin System Design, URL Shortener; problem statement given, no answer yet. Ask for the two core user actions and behavior for an unknown short link. Begin with requirements, then request flow, APIs, and storage tradeoffs; do not jump to caches/sharding or assume design competence. URL Shortener remains introduced/awaiting first attempt. Revisit Target Sum full 1D implementation and count-state after a gap, not another immediate repeat. Plan a focused source-save/test task for the chat-only solutions. No automatic commit/push or reminders; current request authorizes artifact commit only.

Oct 8–11 synthesis: LIS optimized cold reconstruction on Oct 9 had correct algorithm and supplied-case traces; tails invariant/boundary explanation still needed correction. Partition recall required state, odd-total, loop-bound and complexity help; learner disclosed consulting the inner loop. Count Subsets repeatedly mixed boolean/count, row/index and zero-column semantics; enumerated subsets and tables helped. See NOTES.md and TRACKER.md for assistance-level evidence. These entries supersede all older next-task instructions below.

Latest stopping point — 2026-10-07 late evening: user ended LIS recall to rest. Same nums=[3,1,2,5,4]. Exact-ending state needed correction from prefix-best; eligible predecessor 3 omitted; comparison reversed and dp[i]++ used; then confused VALUE 3 with INDEX 3 in dp access. Explicit corrections supplied (H2/H3). Current 4 is index4; previous value3 is index0, candidate dp[0]+1=2; dp[3] belongs to value5. Sequence examples correct after full problem example was supplied, not independent discovery. Next resume with visible indices/values and complete worked current-4 candidate table, then whole learner trace before code; no endless micro-drills. No code, complexity reassessment or tests completed this recall. Respect stop/rest, no guilt backlog. Supersedes earlier next-task guidance below.

Latest handoff — 2026-10-07, 22:16 IST: Count Subsets positive-input 2D completed and saved in SubsetSumCounter.cs. Initial derivation heavily guided (count vs bool/count++, skip column); then Oct 7 return recalled valid subsets and addition rationale. Empty-subset base wording corrected before code. Full method reconstructed correctly without code hints except formatting backticks; complexity and rationale correct. This is improved code recall after a base reminder, not wholly cold H0 mastery; closed-notes compliance unverified. Tests discussed mentally, no build/run/acceptance. Preserve integer count semantics, index-based duplicates and exact target; no total-halving needed. User declined platform practice after GFG/LC494 suggestion; LC494 not taught. Next: brief fresh delayed LIS assessment (state/full DP trace), not more repetitive tiny counting prompts. Counting recall in ~2-3 days/adaptive, and Partition 1D independent recall remains pending. No auto commit/push. Supersedes older next-task guidance below.

Latest handoff — 2026-10-06, 22:20 IST: Partition 1D guided completion. Worked ascending/descending example explicitly requested and shown. First loop had > instead of >= and wrong destination dp[currentNumber]; corrected. Subsequent full method core DP correct but odd-total guard missing, local sum name conflict and backticks corrected. Time O(N*T), space O(T), and explanation of same-element reuse correct. Saved CanPartitionOptimized alongside original 2D method, not built/run, no mastery claim (H2/H3). Next delayed attempt around Oct 7-9/adaptive: write complete method without hints, predict odd-total [1,2], reuse trap [2,6], duplicate [2,2], justify descending invariant. Then brief older-pattern/LIS recall. No need to restart DP or prolong tiny prompts on success. This supersedes the earlier paused introduction below.

Latest stopping point — 2026-10-06: user tired, explicitly postponed until tomorrow. Partition recall for [2,3,7]: total 12, target 6, impossible and state meaning all correct without hints in this recall attempt. Introduced two-row O(T) space and single-array descending updates. On isolated number 2 with tracked sums 0..4, user correctly identified that left-to-right reuse of updated dp[2] could count the same 2 twice. Assistant showed descending j=4,3,2 trace. Next resume with a brief reason-for-descending recap, then have user write the inner loop from target down to currentNumber with OR update. Loop/full 1D method not yet attempted; do not mark optimization mastered or saved as implementation. Preserve 2D solution; no new source changes or tests for this step. No automatic reminders or catch-up pressure. This supersedes earlier next-task instructions below.

Latest handoff — 2026-10-05, 23:58 IST: Partition Equal Subset Sum guided 2D completion across Oct 3-5 (H2/H3 overall). Repeated repair of empty subset sum 0, row count vs current number, remaining-sum take lookup, and guard against negative indices. Full CanPartition implementation algorithm correct with only semicolon correction; j starts at 0, so dp[0,0]=true propagates correctly without separate zero-column initialization. User correctly clarified that OR-ing dp[i,j] is valid after copying skip first. Use selected subsets in diagrams to explain choices; user asked for mental picture, not reconstruction feature. Complexity O(N*T) both correct; [2,2,3,5] false and no reuse of 2 in [1,2,5] correct. Interview wording refined to subset of first i, current sum j and <= permitting both options. Saved PartitionEqualSubsetSum.cs, no compile/run/acceptance verification. Not independent delayed mastery. Oct 3 Knapsack recall: full algorithm correct with naming/indexing syntax fixes, but A-only row initially contained B's value; retention improving. Next cold Partition attempt nums=[2,3,7]: target/state/table including sum 0/answer, equal-number take base, then code and tests. Brief delayed LIS check as energy permits, no backlog. No 1D optimization taught yet. Supersedes older handoffs below.

Latest handoff — Oct 1/2 session, saved Oct 3 after interrupted write: Knapsack guided 2D completion (H2/H3). Full-table visualization materially helped; user explicitly requested it after excessive small prompts. Distinguish state INPUT capacity from final unused capacity after selecting remaining items: user's 3 after skipping B and taking A was valid final leftover, whereas dp[1,5] starts with capacity 5 and returns value 30. Subsequent cell choices and if/else correct; full method algorithm correct with C# rectangular array syntax, names and punctuation corrected by assistant. Complexity O(N*W) time/space correct, rationale refined. Zero-capacity and single-use tests correct; overweight case initially wrong value despite correct else, then corrected. Saved ZeroOneKnapsack.cs, no build/run. No independent delayed mastery. Next cold attempt: weights [2,3], values [4,5], capacity 4; state/table/code/tests/complexity, then brief delayed LIS recall as energy permits. Show complete tables before translating into code; no endless leading questions. User requests firm accountability toward Google and aspirational 60 LPA base, with no guarantees or shame. Supersedes older handoffs below.

Latest stopping point — 2026-09-24, 02:01 IST: Knapsack progressed to 2D table and partial implementation. Fixed A=(2,30), B=(3,40), C=(4,50), capacity 5. Initial take/skip recall correct; after guidance supplied A+B and A+B+C table rows correctly. Needed repeated explanations of item-count versus single item, output value versus state inputs, zero-capacity base, zero-inclusive dimensions, and unchanged capacity on skip. Nested loop bounds correct; symbolic transition confused i/j with global itemCount/capacity. Correct fit/transition/else block was explicitly shown (H2/H3). User requested rest before substitution exercise i=3,j=5,weight=4. Resume by mapping one complete cell to available items and remaining capacity, then a whole independent trace/code block; avoid another prolonged series of tiny leading questions. No full method, runtime verification or complexity assessment yet; not solved. LIS recall remains around Sep 25, adaptive. This supersedes the Sep 22 stopping point below.

Final stopping point — 2026-09-22: after LIS revision, user requested a little new material despite feeling sleepy. Completed only a short 0/1 Knapsack introduction: capacity 5, A=(weight 2,value 30), B=(3,40), C=(4,50). Correct A+B selection and guided take/skip reasoning; overweight item must be skipped. User agreed to pause. Next session resume this same example, derive available-items/remaining-capacity state and motivate 2D DP. No recurrence, code or complexity taught; Knapsack is introduced, not solved. Keep LIS delayed recall around Sep 25. This stopping point supersedes the earlier next-session plan below.

Newest handoff — 2026-09-22: LIS recall initially confused best-so-far with exact-ending state and missed a predecessor; explicit explanation/table required (H2/H3). Then correctly traced `[1,2,6,3,4]`, reconstructed the full method without more algorithm hints, and recalled complexity. Corrected reasoning that j runs to i-1 rather than end of array. Closed-notes compliance not verified. Treat as improvement after guidance, not independent delayed mastery. Next brief delayed recall around Sep 25: state plus fresh full trace. Permit new material between spaced reviews. No new source changes or executions this session; detailed evidence in NOTES.md. Older handoffs below are historical.

Current handoff — 2026-09-20: LIS was introduced and the O(n²) bottom-up solution completed with guidance. Full code assembled correctly; duplicates and complexity correct. Assistance needed on exact-ending state, nums[j] < nums[i], dp[j] + 1 counting elements, and j starting at zero. Record guided completion, not independent mastery. Solution saved in Blind75/Questions/LongestIncreasingSubsequence.cs and session notes in NOTES.md; no runtime verification yet. Next: one fresh, uninterrupted LIS DP trace after a gap, then independent implementation. Binary-search optimization not taught. Preserve Word Break/House Robber spaced review without requiring perfection before all new topics.

Recent review evidence: Word Break prefix/suffix and multiword-prefix meaning needed re-teaching on Sep 19; full bottom-up reconstruction and complexity subsequently correct. House Robber numerical examples mostly correct, code needed boundary and rolling-update fixes. Sep 20 warm-up initially missed last house; corrected with one hint, then full DP array correct. These are observed help levels, not failures of motivation. The older handoff below is historical and superseded where it conflicts with this update.

Session crossed midnight from 2026-09-16 into 2026-09-17 IST.

Observed obstacles: confusing a suffix with the first candidate; growing words recursively instead of via the loop; confusing parent continuation with child movement; prefix length versus character index; requiring both a valid prefix and current dictionary word.

What helped: stable concrete input, explicit start/end indices, child call and parent return traced separately. What needs adjustment: fewer repetitive micro-prompts, more uninterrupted learner narration; do not change dictionaries silently or rush into LIS.

Recall note in Shivam's terms:
- Top-down Solve(start): start se end tak ki poori bachi string dictionary words mein tod sakte hain?
- Loop candidate ko bada karta hai; valid candidate mile toh child remaining suffix check karta hai.
- Child false: parent next candidate try karta hai. Child true: cache true and return. All candidates fail: cache false.
- Bottom-up dp[end]: first end characters breakable hain? Some dp[start] true AND substring(start, end - start) dictionary mein ho.

Latest stopping point (2026-09-17, user ended for sleep): both original approaches are now saved in Blind75/Questions/WordBreak.cs, not compiled/run or committed in this session. User asked about optimizing bottom-up. Explained skipping substring creation when dp[start] is false and limiting candidate length to the longest dictionary word. User correctly said a 5-character candidate cannot match dictionary ["cat", "dog"]. This is guided evidence only; optimization code is not implemented.

Next session: resume the unfinished optimization question: with end = 8 and maxWordLength = 3, where should start begin? Previously shown formula: Math.Max(0, end - maxWordLength). Let Shivam derive the boundary and explain it, then combine with skipping invalid prefixes. Explain O(n * L^2) substring-based work (dictionary setup separate), where L is bounded by n; Trie was mentioned only as a future option, not taught. Do not launch into Trie or LIS yet.

After resuming the requested topic, retain a short unassisted top-down trace on a fresh small input as the next recall assessment. Keep its input stable and allow uninterrupted narration; if stuck, model one complete branch before another independent attempt. Independent delayed recall remains untested.

Provisional Word Break recall dates: Sep 18, Sep 20, Sep 24, Oct 1, Oct 17, 2026; adjust after actual attempts. These are review targets, not scheduled notifications.

## Rationale and resources

Spaced retrieval and feedback inform this plan; exact intervals and phase durations are adjustable coaching choices.

- Retrieval-practice researchers' spacing resource: https://www.retrievalpractice.org/spacing
- Feedback and metacognition resource: https://www.retrievalpractice.org/feedback

Local files are the shared source of truth. Other assistants must explicitly read or receive them; there is no automatic cross-assistant synchronization.
