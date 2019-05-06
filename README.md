# LRUCache

LRU Cache implementation with unit tests

## Performance

This Least Recently Used (LRU) cache has O(1) insert and O(1) retrieval time complexity, and uses a Dictionary and a Doubly Linked List in conjunction for storing cache items.

Cache items values are stored in doubly linked list nodes, ordered from the most recently assessed to the least recently accessed. The dictionary maps nodes by their keys, allowing for efficient retrieval.

Space complexity is dependent upon the sum of the underlying data structures space complexities, i.e, the Dictionary and the Doubly Linked List, yielding in O(n).

## Licensing

This code is released under the MIT License:

Copyright (c) TCGV.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
