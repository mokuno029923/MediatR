## 假設情境

- 系統要新增一個新的客戶

## 單元測試案例

- `CustomerCreationHandlerTests.cs` 內含假設情境的單元測試案例，目的在測試 `Handler` 是否正常運行與處理例外
- 測試案例以 `{欲測試的方法}_{條件/情境}_{預期結果}` 的規則命名
- 測試案例採用 3A 原則撰寫

## 檔案與資料夾結構說明

- `Domain` 資料夾存放 Domain Layer 相關的檔案，實務上須依不同權責的專案或資料夾去配置相關的檔案
  - `Customer.cs` 代表客戶實體，對應資料庫中的 Customer Table，未來可以作為 ORM 框架的 Mapping Entity
  - `CustomerRepository.cs` 代表客戶存放庫，負責與資料庫進行溝通，未來可以作為 ORM 框架的 Repository
  - `CustomerDomainService.cs` 代表客戶領域服務，負責處理 Domain 相關的邏輯
  - `ICustomerRepository.cs` 代表 `CustomerRepository.cs` 的介面
  - `ICustomerDomainService.cs` 代表 `CustomerDomainService.cs` 的介面
- `Requests` 資料夾存放與 MediatR 相關的檔案，實務上須依不同權責的專案或資料夾去配置相關的檔案
  - `CustomerCreationRequest.cs` 代表一個新增客戶的請求
  - `CustomerCreationRequestHandler.cs` 代表當新增客戶的請求發生時，應該要做什麼樣的處理，這邊以呼叫 `CustomerDomainService.CreateAsync()` 作範例，意即要新增一個客戶至資料庫當中
  - `CustomerCreationExceptionHandler.cs` 代表 MediatR 處理 Request 時會經過的其中一個 Exception Pipeline，負責新增客戶請求的錯誤處理
