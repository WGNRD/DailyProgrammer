# Author: Dominik Wagner
# Date: 07.01.2017
# Solution to the Reddit [2016-12-12] Challenge #295 [Easy] Letter by letter
# URL: https://www.reddit.com/r/dailyprogrammer/comments/5hy8sm/20161212_challenge_295_easy_letter_by_letter/

import random

fromStr = input()
toStr = input()

if len(fromStr) != len(toStr):
    print("Input-length must match, quitting")
    exit(1)

print(fromStr)

while fromStr != toStr:
    randint = random.randint(0, len(toStr)-1)
    if fromStr[randint] != toStr[randint]:
        fromStr = fromStr[:randint]+toStr[randint]+fromStr[randint+1:]
        print(fromStr)
