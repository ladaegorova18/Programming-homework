#pragma once

void reading()
{
    FILE *file = ("C://array.txt", "r");


}

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
