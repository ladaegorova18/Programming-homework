#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <assert.h>

void test(long int *array, int n, long int number, int res)
{
    for (int i = 0; i < n; i++)
    {
        if (number == array[i])
        {
            assert(res == 1);
        }
        else
        {
            assert(res == 0);
        }
    }
}

void tree(long int *array, int begin, int end)
{
  int maxChild;
  int done = 0;
  while ((begin * 2 <= end) && (!done))
  {
    if (begin * 2 == end)
      maxChild = begin * 2;
    else if (array[begin * 2] > array[begin * 2 + 1])
      maxChild = begin * 2;
    else
      maxChild = begin * 2 + 1;
    if (array[begin] < array[maxChild])
    {
      int temp = array[begin];
      array[begin] = array[maxChild];
      array[maxChild] = temp;
      begin = maxChild;
    }
    else
      done = 1;
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

int binarySearch(long int *array, int begin, int end, long int number)
{
    if ((end == 0) || (array[0] > number) || (array[end - 1] < number))
    {
        printf("false \n");
        return 0;
    }
    while (begin < end)
    {
        int key = begin + (end - begin) / 2;
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
        printf("true \n");
        return 1;
    }
    else {
        printf("false \n");
        return 0;
    }
}

int main()
{
    int n = 0;
    printf("Enter n:\n");
    scanf("%d", &n);
    long int *array = (long int*) malloc(n * sizeof(long int));
    srand(time(NULL));
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
        int res = binarySearch(array, 0, n, number);
        test(array, n, number, res);
    }
    free(array);
    return 0;
}
