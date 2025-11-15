public class FlakyAlertCreationTest
{
    [Fact]
    public async Task CreateAlert_FlakyTest()
    {
        // Common causes of flakiness:
        // 1. Stale data from previous test runs
        // 2. Race conditions in parallel execution
        // 3. Persistence delays in database
        // 4. Missing test data cleanup
        // 5. Timing issues with async operations

        // Solutions:
        // 1. Implement proper test isolation
        // 2. Use unique identifiers for each test
        // 3. Add retry logic with exponential backoff
        // 4. Implement proper cleanup in test teardown
        // 5. Use polling instead of fixed delays
    }
}
