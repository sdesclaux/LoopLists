# LoopLists

Results with size = 1_000_000 & .net 8:
| Method     | Mean       | Error    | StdDev    | Median     | Allocated |
|----------- |-----------:|---------:|----------:|-----------:|----------:|
| For        |   961.8 us | 25.50 us |  73.15 us |   960.4 us |         - |
| ForEach    |   850.3 us | 24.97 us |  72.45 us |   826.8 us |         - |
| ForEachBis | 1,918.5 us | 71.67 us | 209.06 us | 2,003.6 us |      94 B |
| While      |   786.6 us | 14.17 us |  16.87 us |   785.0 us |         - |
| DoWhile    |   927.7 us | 30.31 us |  87.45 us |   920.7 us |         - |
| GoTo       |   927.4 us | 27.63 us |  77.92 us |   921.2 us |       1 B |
| Span       |   895.3 us | 27.12 us |  79.54 us |   892.0 us |         - |

Conclusions :
ForEachBis not interessting
Rest : equivalent
Span : fastest with drawbacks on .Net 9 ! Need to be tested !