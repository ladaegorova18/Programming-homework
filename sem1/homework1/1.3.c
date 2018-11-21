#include <stdio.h>
#include <stdlib.h>
#include <assert.h>

void reverse(int begin, int end, int *array)
{
    end--;
    while (end - begin > 0)
    {
        const int t = array[begin];
        array[begin] = array[end];
        array[end] = t;
        begin++;
        end--;
    }
}

void exchange(int m, int n, int *array)
{
    reverse(0, m, array);
    reverse(m, n + m, array);
    reverse(0, m + n, array);
}

int main()
{
    test();
    printf("Enter m,n:\n");
    int m = 0;
    int n = 0;
    scanf("%d%d", &m, &n);
    int *array = (int*) malloc(m + n);
    printf("Enter the numbers:\n");
    for (int i = 0; i < m + n; i++)
    {
        scanf("%d", &array[i]);
    }
    exchange(m, n, array);
    for (int i = 0; i < m + n; i++)
    {
        printf("%d ", array[i]);
    }
    free(array);
    return 0;
}

int test()
{
    int TestArray1[5] = {1, 2, 3, 4, 5};
    exchange(2, 3, TestArray1);
    int TestArray2[5] = {3, 4, 5, 1, 2};
    for (int i = 0; i < 5; i++)
    {
        assert(TestArray1[i] == TestArray2[i]);
    }
    return 0;
}
