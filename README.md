# TDD_0819_Homework

利用`CollectionAggregator.Aggregate(ICollection<T> source, int chunkSize, string property)`切 partition 後加總
* `ICollection<T> source` : 資料來源
* `int chunkSize` : 每組筆數
* `string property` : 欄位名稱

---
# `AggregatorTests`

### 測試資料
Id|Cost|Revenue|SellPrice
---|---|---|---
1|1|11|21
2|2|1|22
3|3|13|23
4|4|14|24
5|5|15|25
6|6|16|26
7|7|17|27
8|8|18|28
9|9|19|29
10|10|20|30
11|11|21|31

### 測試案例
1. 輸入 `11筆`，`3筆` 一組，計算 `Cost` 總和，預期取得 `{ 6, 15, 24, 21 }`
2. 輸入 `11筆`，`4筆` 一組，計算 `Revenue` 總和，預期取得 `{ 50, 66, 60 }`
3. 每組筆數輸入 `負數`，預期拋出 `ArgumentException`
4. `欄位` 不存在，預期拋出 `ArgumentException`
5. 每組筆數輸入 `0`，預期取得 `{ 0 }`