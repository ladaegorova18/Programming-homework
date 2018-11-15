#include <stdio.h>
#include <math.h>
unsigned long long int factorial(int n) {
    unsigned long long int res = 1;
    if (n == 0)
        res = 1;
    for (int i = 1; i <= n; i++) {
        res *= i;
    }
    return res;
}
unsigned long long int func(unsigned long long int sum) {
    if (sum <= 9) {
        sum = factorial(sum + 2) / (factorial(sum) * 2);
    } else if (sum >= 14) {
        sum = func(27 - sum);
    }
    else {
        sum = factorial(sum + 2) / (2 * factorial(sum)) - (3 * func(sum - 10));
    }
    return sum;
}
int main(){
    int arr[28];
    for (int i = 0; i <= 27; i++) {
        arr[i] = func(i);
    }
    int sum = 0;
    for (int i = 0; i <= 27; i++) {
        sum += arr[i] * arr[i];
    }
    printf("sum is %d", sum);

    return 0;
}
