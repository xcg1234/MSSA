def maxProfit(self, prices: List[int]) -> int:
        res = 0
        low = 100000
        for p in prices:
            low = min(low, p)
            res = max(res, p - low)
        return res

def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        slow, fast = None, head
        while fast:
            original_next = fast.next
            fast.next = slow
            slow = fast
            fast = original_next
        return slow