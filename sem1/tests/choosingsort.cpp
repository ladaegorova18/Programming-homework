#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#define LEN 10

void test(int array[LEN])
{
    for (int i = 0; i < LEN - 1; i++)
    {
    assert(array[i] <= array[i + 1]);
    }
    printf("Test passed\n");

}

void choosingSort(int array[LEN])
{
    for (int j = 0; j < LEN - 1; j++)
    {
        int min = j;
        for (int i = j + 1; i < LEN; i++)
        {
            if (array[i] < array[min])
            {
                min = i;
            }
        }
        int t = array[j];
        array[j] = array[min];
        array[min] = t;
        min++;
    }
}

int main()
{
    int array[LEN];
    printf("Enter the elemets of the array;\n");
    for (int i = 0; i <= LEN - 1; i++)
    {
        scanf(" %d", &array[i]);
    }
    choosingSort(array);
    test(array);
    for (int i = 0; i < LEN; i++)
    {
        printf("%d ", array[i]);
    }
    return 0;
}
