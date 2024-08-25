using System.Collections;

namespace ScadaAPITest.TestData;

/// <summary>
/// Test Data object for Books API test.
/// </summary>
public class BooksCountTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [1, 100];
        yield return [2, 200];
        yield return [3, 300];
        yield return [4, 400];
        yield return [5, 500];
        yield return [6, 600];
        yield return [7, 700];
        yield return [8, 800];
        yield return [9, 900];
        yield return [10, 1000];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}