#include <stdio.h>
#include <assert.h>
#define SIZE 200

void bubbleSort(int *array, int length)
{
    for (int i = 0; i < length - i; i++)
    {
        for (int j = 1; j < length; j++)
        {
            if (array[j - 1] > array[j])
            {
                int const t = array[j - 1];
                array[j - 1] = array[j];
                array[j] = t;
            }
        }
    }
}

void countingSort(int *array, int length)
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
}

void test()
{
    int countTestArray[5] = {4, 3, 4, 2, 0};
    int testArray[5] = {0, 2, 3, 4, 4};
    countingSort(countTestArray, 5);
    for (int i = 0; i < 5; i++)
    {
        assert(countTestArray[i] == testArray[i]);
    }
    int bubbleTestArray[5] = {88, 0, 0, 28, 16};
    bubbleSort(bubbleTestArray, 5);
    int testArray1[5] = {0, 0, 16, 28, 88};
    for (int i = 0; i < 5; i++)
    {
        assert(bubbleTestArray[i] == testArray1[i]);
    }
}

int main()
{
    test();
    int length = 0;
    printf("Enter the length:\n");
    scanf("%d", &length);
    int *array = (int*) malloc(length * sizeof(int));
    printf("Enter the numbers, less than 100:\n");
    for (int i = 0; i < length; i++)
    {
        scanf("%d", &array[i]);
    }
    printf("\nChoose a type of sort: bubble(b) or counting(c):\n");
    char key;
    scanf(" %c", &key);
    if (key == 'b')
    {
        bubbleSort(array, length);
        printf("Bubble sort worked!\n");
    }
    else if (key == 'c')
    {
        countingSort(array, length);
        printf("Counting sort worked!\n");
    }
    for (int i = 0; i < length; i++)
    {
        printf("%d ", array[i]);
    }
    free(array);
    return 0;
}
