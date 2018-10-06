#include <stdio.h>
#include <stdlib.h>

void shellSort(int *array, int begin, int end)
{
    int steps[] = {701, 301, 132, 57, 23, 10, 4, 1};
    int j = 0;
    while (steps[j] > end)
    {
        j++;
    }
    int step = steps[j];
    while (step > 0)
    {
        for (int i = begin; i < end; i++)
        {
            const int key = array[i];
            int j = i - step;
            while ((j >= 0) && (array[j] > key))
            {
                array[j + step] = array[j];
                j -= step;
            }
            array[j + step] = key;
        }
        j++;
        step = steps[j];
    }
}


int maxRepeating(int *array, int end)
{
    int frequency = 1;
    int maxfrequency = 0;
    int number = 0;
    for (int i = 1; i < end; i++)
    {
        if (array[i] == array[i - 1])
        {
            frequency++;
        }
        else if (frequency > maxfrequency)
        {
            maxfrequency = frequency;
            frequency = 1;
            number = i - 1;
        }
    }
    return array[number];
}

int main()
{
    int size = 0;
    printf("Enter the size:\n");
    scanf("%d", &size);
    int *array = (int*) malloc(size * sizeof(int));
    printf("Enter the elements:\n");
    for (int i = 0; i < size; i++)
    {
        scanf("%d", &array[i]);
    }
    shellSort(array, 0, size);
    for (int i = 0; i < size; i++)
    {
        printf("%d ", array[i]);
    }
    printf("\nThe first most popular element is %d", maxRepeating(array, size));
    free(array);
    return 0;
}
