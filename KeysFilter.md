## 重构步骤

### 必备快捷键 (Mac OS X)
1. Find Action, Cmd + Shift + A
2. Next issue, F2
3. Show action List, Option + Enter


### 步骤
1. 移除标记参数 Remove Flag Argument / 已明确函数取代参数 Replace Parameter with Explicit Methods
2.

### 第1步
1. 新建两个明确函数 `FilterGoldenKeys(IList<string> marks)` 和 `FilterSilverAndCopperKeys(IList<string> marks)`
2. 分别在新函数内调用原函数 `Filter(marks, true)` 或 `Filter(marks, false)`
3. 内联Filter函数, `Refactor | Inline`
4. 删除新函数中无法到达的代码 `Show action list | Romove not accessed local varaible`
5. 在Filter中调用两个新函数
 
