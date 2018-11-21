#include <stdio.h>
#include <assert.h>
#define SIZE 200

int countingSort(int *array, int length)
{
    int frequency[SIZE] = {0};
    for (int i = 0; i < length; i++)
    {
        frequency[array[i] + SIZE / 2]++;
    }
    int position = 0;
    for (int num = 0; num < SIZE; num++)
    {
        for (int i = 0; i < frequency[num]; i++)
        {
            array[position] = num - SIZE / 2;
            position++;
        }
    }
    int maxfrequency = 0;
    int maxRepeatingElement = 0;
    for (int i = 0; i < SIZE; i++)
    {
        if (frequency[i] > maxfrequency)
        {
            maxfrequency = frequency[i];
            maxRepeatingElement = i - SIZE / 2;
        }
    }
    test(maxRepeatingElement, frequency);
    return maxRepeatingElement;
}

void test(int res, int *frequency)
{
    for (int i = 0; i < SIZE; i++)
    {
        assert(frequency[res + SIZE / 2] >= frequency[i]);
    }
}

int main()
{
    int length = 0;
    printf("Enter the length:\n");
    scanf("%d", &length);
    int *array = (int*) malloc(length * sizeof(int));
    printf("Enter the numbers, less than 100:\n");
    for (int i = 0; i < length; i++)
    {
        scanf("%d", &array[i]);
    }
    countingSort(array, length);
    for (int i = 0; i < length; i++)
    {
        printf("%d ", array[i]);
    }
    printf("\nThe most repeating element is %d ", countingSort(array, length));
    free(array);
    return 0;
}
