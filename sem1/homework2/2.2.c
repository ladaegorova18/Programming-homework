#include <stdio.h>
#include <assert.h>

int simplePow(long int n, int power)
{
    if (power == 0)
    {
        return 1;
    }
    long int res = n;
    for (int i = 1; i < power; i++)
    {
        res *= n;
    }
    return res;
}

int effectivePow(long int n, int power)
{
    if (power == 0)
    {
        return 1;
    }
    if (power % 2 == 1)
    {
        return effectivePow(n, power - 1) * n;
    }
    else
    {
        const int halfPower = effectivePow(n, power / 2);
        return  halfPower * halfPower;
    }

}

int test()
{
    assert(simplePow(2, 5) == 32);
    assert(effectivePow(3, 3) == 27);
    assert(simplePow(5, 1) == 5);
    assert(effectivePow(8, 2) == 64);
    assert(simplePow(1, 2) == 1);
    assert(effectivePow(0, 2) == 0);
    return 0;
}

int main()
{
    test();
    printf("Enter a number:\n");
    long int n = 0;
    scanf("%d", &n);
    printf("Enter a power:\n");
    int power = 0;
    scanf("%d", &power);
    if (((n < 0) || (power < 0)) || ((n == power) && (power == 0)))
    {
        printf("Please enter other numbers\n");
        return 0;
    }
    printf("The simple way: %d\n", simplePow(n, power));
    printf("The fast way: %d\n", effectivePow(n, power));
    return 0;
}
