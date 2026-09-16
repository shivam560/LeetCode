# Adaptive interview preparation

Updated: 2026-09-17, 01:08 IST. Goal: Google and other big-tech engineering interviews. This is persistent workspace context for future sessions, not a guarantee of cross-app memory or hiring outcomes.

## How to coach Shivam

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

Weekly default: roughly three focused learning/practice sessions, one mixed recall session, and one design/communication session if time permits. During foundation repair, prioritize recall and explanation. Rest and work obligations remain compatible with the plan.

Every weekly review: compare delayed recall, hints needed, repeated error types and independent transfer. If gaps persist, change instruction and problem selection. If recall is strong, reduce repetition and introduce variation. Never optimize only for solved count or streaks.

## Latest session handoff

Session crossed midnight from 2026-09-16 into 2026-09-17 IST.

Observed obstacles: confusing a suffix with the first candidate; growing words recursively instead of via the loop; confusing parent continuation with child movement; prefix length versus character index; requiring both a valid prefix and current dictionary word.

What helped: stable concrete input, explicit start/end indices, child call and parent return traced separately. What needs adjustment: fewer repetitive micro-prompts, more uninterrupted learner narration; do not change dictionaries silently or rush into LIS.

Recall note in Shivam's terms:
- Top-down Solve(start): start se end tak ki poori bachi string dictionary words mein tod sakte hain?
- Loop candidate ko bada karta hai; valid candidate mile toh child remaining suffix check karta hai.
- Child false: parent next candidate try karta hai. Child true: cache true and return. All candidates fail: cache false.
- Bottom-up dp[end]: first end characters breakable hain? Some dp[start] true AND substring(start, end - start) dictionary mein ho.

Next session: after sleep, ask for an unassisted top-down trace on one fresh small input. Keep the same input for the entire attempt; withhold a solution until the attempt. If stuck, model one complete branch and let Shivam narrate the rest. Then attempt a meaningful block of code without notes. Revisit bottom-up on a later session and sample one older pattern. LIS remains pending, not solved.

Provisional Word Break recall dates: Sep 18, Sep 20, Sep 24, Oct 1, Oct 17, 2026; adjust after actual attempts. These are review targets, not scheduled notifications.

## Rationale and resources

Spaced retrieval and feedback inform this plan; exact intervals and phase durations are adjustable coaching choices.

- Retrieval-practice researchers' spacing resource: https://www.retrievalpractice.org/spacing
- Feedback and metacognition resource: https://www.retrievalpractice.org/feedback

Local files are the shared source of truth. Other assistants must explicitly read or receive them; there is no automatic cross-assistant synchronization.
