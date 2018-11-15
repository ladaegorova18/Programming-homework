#include <stdio.h>
#include <string.h>
int main() {
    printf("Enter a string:\n");
    char str[100];
    scanf("%s", str);
    int k = 0;
    for(int i = 0; i < strlen(str); i++) {
        if(str[i] == '(')
            k++;
        if(str[i] == ')')
            k--;
        if(k < 0) {
            printf("false"); /*проверяем вложенность скобок на каждом этапе цикла*/
            return 0;
        }
    }
    if(k == 0) {
        printf("true");
    } else {
        printf("false");
    }
    /*проверяем равенство открывающих и закрывающих скобок*/
    return 0;
}
