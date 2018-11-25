#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <time.h>

void sortArray(int *array, int len)
{
    int position = 1;
    for (int i = 1; i < len; i++)
    {
        if (array[i] < array[0])
        {
            int t = array[position];
            array[position] = array[i];
            array[i] = t;
            position++;
        }
    }
}

void test(int *array, int len)
{
    for (int i = 2; i < len; i++)
    {
        if (array[i - 1] >= array[0])
        {
            assert(array[i] >= array[0]);
        }
    /* проверяем, если какой-то элемент массива больше первого или равен ему, то все следующие за ним тоже должны должны быть таковыми*/
    }
}

int main()
{
    int len = 0;
    printf("Enter the length:\n");
    scanf("%d", &len);
    int *array = (int*) malloc(len * sizeof(int));
    srand(time(NULL));
    for (int i = 0; i < len; i++)
    {
        array[i] = rand() % 20;
        printf("%d ", array[i]);
    }
    sortArray(array, len);
    test(array, len);
    printf("\nResult after sorting:\n");
    for (int i = 0; i < len; i++)
    {
        printf("%d ", array[i]);
    }
    free(array);
    return 0;
}
