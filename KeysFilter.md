## 重构步骤

### 必备快捷键 (Mac OS X)
1. Find Action, Cmd + Shift + A
2. Next issue, F2
3. Show action List, Option + Enter


### 步骤
1. 移除标记参数 Remove Flag Argument / 已明确函数取代参数 Replace Parameter with Explicit Methods
2. 去除形如 `IList<string> marks1 = marks` 的代码
3. 消除看似非常重复的代码： 两个方法中keys的构建

### 第1步
1. 新建两个明确函数 `FilterGoldenKeys(IList<string> marks)` 和 `FilterSilverAndCopperKeys(IList<string> marks)`
2. 分别在新函数内调用原函数 `Filter(marks, true)` 或 `Filter(marks, false)`
3. 内联`Filter`函数, `Refactor | Inline`
4. 删除新函数中无法到达的代码 `Show action list | Romove not accessed local varaible`
5. 在Filter中调用两个新函数

### 第2步 
1. 在方法 `FilterSilverAndCopperKeys(IList<string> marks)` 中，使用 `Refactor | Inline`
2. 在方法 `FilterGoldenKeys(IList<string> marks)` 中，
   先使用 `改变函数签名，添加参数`，
   再使用 `改变函数签名，移除参数`，
   最后使用 `重命名`，将名字改为 `marks`。
   
### 第3步
1. 消除参数为空数组时对`keys`的引用。
2. 提取值`GoldenKey`为变量`sessionKey`。
3. 提取方法`GetMarksBySessionKey(string sessionKey)`
4. 对`FilterSilverAndCopperKeys`方法中的部分提取方法 `GetMarksBySessionKey(List<string> sessionKeys)`
5. 在方法`GetMarksBySessionKey(string sessionKey)`中调用方法`GetMarksBySessionKey(List<string> sessionKeys)`
6. 内联`GetMarksBySessionKey(string sessionKey)`方法
7. 删除`GetMarksBySessionKey(string sessionKey)`方法
8. 内联变量`sessionKey`或`sessionKeys`