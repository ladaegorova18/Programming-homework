#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <ctype.h>

int recursion(int number)
{
    if (number > 2)
    {
        return recursion(number - 1) + recursion(number - 2);
    }
    else
    {
        return 1;
    }
}

int iteration(int number)
{
    int previousFibonacciNumber = 1;
    int prePreviousFibonacciNumber = 1;
    for (int i = 2; i < number; i++)
    {
        int fib = previousFibonacciNumber + prePreviousFibonacciNumber;
        prePreviousFibonacciNumber = previousFibonacciNumber;
        previousFibonacciNumber = fib;
    }
    return previousFibonacciNumber;
}

void test()
{
    assert(recursion(3) == 2);
    assert(iteration(5) == 5);
    assert(recursion(7) == 13);
    assert(recursion(1) == 1);
    assert(recursion(0));
    assert(recursion(-1));
}

int main()
{
    test();
    printf("Enter a number:\n");
    int number = 0;
    scanf("%d", &number);
    if (isdigit(number))
    {
        printf("it should be a number");
        return 0;
    }
    if (number < 1)
    {
        printf("it should be a positive number");
        return 0;
    }
    printf("Рекурсивный алгоритм:%d\n", recursion(number));
    printf("Итеративный алгоритм:%d\n", iteration(number));
    return 0;
}
