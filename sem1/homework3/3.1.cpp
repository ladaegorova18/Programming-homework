#include <stdio.h>
#include <stdlib.h>
const int LIM = 10;

int partition(int *array, int begin, int end)
{
    int key = array[end];
    int i = begin;
    for (int j = begin; j < end; j++)
    {
        if (array[j] <= key)
        {
            const int t = array[i];
            array[i] = array[j];
            array[j] = t;
            i++;
        }
    }
}

void insertionSort(int *array, int begin, int end)
{
    for (int i = begin + 1; i <= end; i++)
    {
        const int key = array[i];
        int j = i - 1;
        while ((j >= 0) && (array[j] > key))
        {
            array[j + 1] = array[j];
            j--;
        }
        array[j + 1] = key;
    }
}

void quickSort(int *array, int begin, int end)
{
    if (begin < end)
    {
        const int pivot = partition(array, begin, end);
        {
            quickSort(array, pivot + 1, end);
        }
        if ((pivot - 1 - begin) < LIM)
        {
            insertionSort(array, begin + 1, pivot - 1);
        }
        else
        {
            quickSort(array, begin, pivot - 1);
        }
    }
}

int main()
{
    int size = 0;
    printf("Enter size of array:\n");
    scanf("%d", &size);
    int *array = new int[size]{};
    printf("Enter the elements:\n");
    for (int i = 0; i < size; i++)
    {
        scanf("%d", &array[i]);
    }
    quickSort(array, 0, size);
    printf("The result after sorting:\n");
    for (int i = 0; i < size; i++)
    {
        printf("%d ", array[i]);
    }
    free(array);
    return 0;
}
