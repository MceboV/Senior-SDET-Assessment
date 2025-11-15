# Senior-SDET-Assessment

This repository contains the technical assessment for the Senior Software Development Engineer in Test (SDET) role. It includes coding tasks, API automation tests, manual and automated test cases, debugging exercises, and framework design documentation.

---

## Repository Structure



---

## How to Use

### 1. Coding Task
- Implement business logic in `coding-task/src/`.
- Write unit tests in `coding-task/tests/`.
- Run tests via Visual Studio, `dotnet test`, or preferred IDE.

### 2. API Automation
- Implement API automation in `api-automation/tests/`.
- Use `ApiClient.cs` for API requests.
- Run tests via `dotnet test` or IDE.

### 3. Test Cases
- Manual and automated test cases are documented under `test-cases/`.

### 4. Debugging
- Analyze flaky tests in `debugging/`.
- Document fixes in `analysis-and-fix.md`.

### 5. Framework Design
- Automation framework design and strategy in `framework-design/`.

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or later (or JetBrains Rider)
- Git
- Optional: API testing tools (Postman, REST Client)

---

## How to Run

```bash
# Clone repository
git clone https://github.com/YourUsername/Senior-SDET-Assessment.git
cd Senior-SDET-Assessment

# Run coding task tests
cd coding-task
dotnet test

# Run API automation tests
cd ../api-automation
dotnet test
