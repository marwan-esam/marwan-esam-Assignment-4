# Benchmark Analysis

## Benchmark Results

| Method                     | Iterations | Mean                | Error             | StdDev            | Gen0          | Gen1          | Gen2          | Allocated       |
|--------------------------- |----------- |--------------------:|------------------:|------------------:|--------------:|--------------:|--------------:|----------------:|
| StringConcatenation        | 100        |         11,157.2 ns |         158.02 ns |         131.95 ns |       24.3835 |        0.4578 |             - |       248.95 KB |
| StringBuilderConcatenation | 100        |            676.4 ns |           8.81 ns |           7.81 ns |        0.8402 |             - |             - |         8.59 KB |
| StringConcatenation        | 1000       |      1,169,706.2 ns |      12,088.91 ns |       9,438.23 ns |     2386.7188 |      279.2969 |             - |     24462.82 KB |
| StringBuilderConcatenation | 1000       |          4,870.6 ns |          41.20 ns |          34.40 ns |        6.2332 |        0.7782 |             - |        63.74 KB |
| StringConcatenation        | 10000      |    188,943,901.0 ns |   1,318,275.14 ns |   1,100,819.45 ns |   739333.3333 |   734333.3333 |   733333.3333 |   2442135.09 KB |
| StringBuilderConcatenation | 10000      |         42,478.9 ns |         563.28 ns |         499.33 ns |       49.1943 |       30.6396 |             - |       503.21 KB |
| StringConcatenation        | 100000     | 42,154,539,353.7 ns | 631,120,373.75 ns | 590,350,389.46 ns | 30149000.0000 | 30122000.0000 | 30121000.0000 | 244154709.82 KB |
| StringBuilderConcatenation | 100000     |        472,174.4 ns |       2,850.48 ns |       2,526.87 ns |      480.4688 |      455.5664 |             - |      4913.59 KB |

## Analysis

**Which approach was faster with 100 iterations?**  
The `StringBuilderConcatenation` method was significantly faster even at 100 iterations (676.4 ns vs 11,157.2 ns).

**Which approach was faster with 100,000 iterations?**  
The `StringBuilderConcatenation` method remained massively faster at 100,000 iterations (taking less than half a millisecond compared to over 42 seconds for standard string concatenation).

**Which approach allocated more memory?**  
The `StringConcatenation` method allocated drastically more memory. At 100,000 iterations, it allocated over 244 Gigabytes of memory, whereas `StringBuilder` allocated less than 5 Megabytes.

**What happened to string concatenation performance as the loop size increased?**  
The performance of standard string concatenation degraded exponentially as the loop size increased, becoming severely bogged down by memory allocation and garbage collection.

**Why does repeated string concatenation create additional allocations?**  
In C#, `string` objects are **immutable**, meaning their values cannot be modified after they are created. Every time an addition (`+=`) happens, the Common Language Runtime (CLR) must allocate a completely new string in memory, copy the old string's contents, and append the new addition, then mark the old string for garbage collection.

**Why does `StringBuilder` usually perform better when text is repeatedly appended?**  
`StringBuilder` is **mutable**. It maintains a dynamic buffer under the hood, allowing it to modify strings and append text directly in-place without needing to constantly create new objects in memory.

**Is `StringBuilder` always better than normal string operations? Explain.**  
No, `StringBuilder` is not always better. For very small or one-off concatenations (e.g., combining two or three short strings), standard string concatenation or interpolation is often faster and much more readable. This is because `StringBuilder` has a small initial setup overhead (allocating its internal buffer) which isn't justified for trivial operations.
