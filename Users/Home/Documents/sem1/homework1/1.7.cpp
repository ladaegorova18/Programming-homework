#include <stdio.h>
#include <math.h>

int main() {
    int n;
    printf("Enter a number:\n");
    scanf("%d", &n);
    printf("Prime numbers are:\n");
    for (int i = 2; i <= n; i++) {
        bool k = false;
        for (int j = 2; j <= (int) sqrt((double) i); j++) {
            if (i % j == 0) {
                k = true;
            }
        }
        if (!k) {
            printf("%d\n", i);
        }
    }
    return 0;
}

