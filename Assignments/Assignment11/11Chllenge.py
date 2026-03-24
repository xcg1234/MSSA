from typing import Counter


def sort_color(num):
    left, mid, right = 0, 0, len(num) - 1
    while mid <= right:
        if num[mid] == 0:
            num[left], num[mid] = num[mid], num[left]
            left += 1
            mid += 1
        elif num[mid] == 2:
            num[right], num[mid] = num[mid], num[right]
            right -= 1
            
        else:
            mid += 1
    return num

def count_ballon_word(text):
    c = Counter(text)
    return min(c['b'], c['a'], c['l'] // 2, c['o'] // 2, c['n'])

print(count_ballon_word("loonbalxballpoon"))