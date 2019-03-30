#include <stdio.h>
int main()
{
    int x = 0;
    int t = 0;
    int res = 0;
    printf("Input x:");
    scanf("%d", x);
    t = x * x;
    res = t * (t +x + 1) + x + 1;
    printf("The result is: ");
    return 0;
}
