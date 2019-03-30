#include <iostream>
#include <stdio.h>
using namespace std;
int main(){
    int a,b,i,m,res,min1;
    printf("Input a,b:\n");
    scanf("%d %d",&a,&b);

    min1=1;
    if (b<0){
        b = -b;
        min1 = -min1;
    }
    m=b;
    if (a<0){
        a=-a + m;
        min1=-min1;
    }

    if (a<b) {
        printf("0");
        return 0;
    }
    if (b==0) {
        printf("Don't divide by zero");
        return 0;
    }

    for (i=1;b<=a;i++) {
        if(b==a) res = 1;
        b += m;
        if(b>a) res=i*min1;
    }
    printf("res = %d ",res);

    return 0;
}
