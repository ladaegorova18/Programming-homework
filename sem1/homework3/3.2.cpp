#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <assert.h>
#include <cstddef>

void tree(long int *array, int begin, int end)
{
    int maxChild = 0;
    int done = 0;
    while ((begin * 2 <= end) && (!done))
    {
        if (begin * 2 == end)
        {
            maxChild = begin * 2;
        }
        else if (array[begin * 2] > array[begin * 2 + 1])
        {
            maxChild = begin * 2;
        }
        else
        {
            maxChild = begin * 2 + 1;
        }
        if (array[begin] < array[maxChild])
        {
            const int temp = array[begin];
            array[begin] = array[maxChild];
            array[maxChild] = temp;
            begin = maxChild;
        }
        else
        {
            done = 1;
        }
    }
}

void heapSort(long int *array, int n)
{
    for (int i = (n / 2) - 1; i >= 0; i--)
        tree(array, i, n - 1);
    for (int i = n - 1; i >= 1; i--)
    {
        const int temp = array[0];
        array[0] = array[i];
        array[i] = temp;
        tree(array, 0, i - 1);
    }
}

bool binarySearch(long int *array, int begin, int end, long int number)
{
    if ((end == 0) || (array[0] > number) || (array[end - 1] < number))
    {
        return 0;
    }
    while (begin < end)
    {
        const int key = (begin + end) / 2;
        if (number <= array[key])
        {
            end = key;
        }
        else
        {
            begin = key + 1;
        }
    }
    if (number == array[end])
    {
        return 1;
    }
    else {
        return 0;
    }
}

void test()
{
    long int repeatingArray[5] = {3, 3, 3, 3, 3};
    tree(repeatingArray, 0, 5);
    assert(binarySearch(repeatingArray, 0, 5, 3) == 1);
    assert(binarySearch(repeatingArray, 0, 5, 4) == 0);
    long int oneMemberArray[1] = {7};
    tree(oneMemberArray, 0, 1);
    assert(binarySearch(oneMemberArray, 0, 1, 7) == 1);
    assert(binarySearch(repeatingArray, 0, 1, 10) == 0);
}

int main()
{
    test();
    int n = 0;
    printf("Enter n:\n");
    scanf("%d", &n);
    long int *array = (long int*) malloc(n * sizeof(long int));
    srand(time(nullptr));
    for (int i = 0; i < n; i++)
    {
        array[i] = rand() % 1000 + rand() % 1000 * 1000 + rand() % 1000 * 1000000;
    }
    heapSort(array, n);
    for (int i = 0; i < n; i++)
    {
        printf("%d ", array[i]);
    }
    long int k = 0;
    printf("\nEnter k:\n");
    scanf("%d", &k);
    for (int i = 0; i < k; i++)
    {
        int number = rand() % 1000 + rand() % 1000 * 1000 + rand() % 1000 * 1000000;
        printf("%d ", number);
        bool res = binarySearch(array, 0, n, number);
        if (res)
        {
            printf("true\n");
        }
        else
        {
            printf("false\n");
        }
    }
    free(array);
    return 0;
}
