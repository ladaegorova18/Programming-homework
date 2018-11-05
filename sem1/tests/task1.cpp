#include <stdio.h>
#include <stdlib.h>
#include <assert.h>

int maxSumOfNumbers(int array[10])
{
    int maxsum = 0;
    int sum = 0;
    int maxnumber = 0;
    for (int i = 0; i < 10; i++)
    {
        int number = array[i];
        while(number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        if (sum > maxsum)
        {
            maxsum = sum;
            maxnumber = i;
        }
        sum = 0;
    }
    return array[maxnumber];
}

int test(int array[10])
{
    assert((maxSumOfNumbers(array)) == 54);
    return 0;
}

int main()
{
    int array[10] = {16, 43, 30, 8, 6, 2, 54, 4, 6, 33};
    test(array);
    printf("%d ", maxSumOfNumbers(array));
    return 0;
}
