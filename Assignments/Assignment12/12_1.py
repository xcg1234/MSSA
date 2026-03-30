# 12.1, first question.

class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        # from collections import Counter if necessary
        c_ran = Counter(ransomNote)
        c_mag = Counter(magazine)

        for key, value in c_ran.items():
            if key not in c_mag:
                return False
            if key in c_mag and value > c_mag.get(key):
                return False
        return True
            

class Solution:
    def isPalindrome(self, head: Optional[ListNode]) -> bool:
        res = []
        curr = head
        while curr:
            res.append(curr.val)
            curr = curr.next
        return res == res[::-1]