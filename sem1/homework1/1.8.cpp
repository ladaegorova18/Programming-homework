#include <iostream>
#include <stdio.h>
using namespace std;
int main(){
    int n=0;
    int k=0;
    printf("Input size of array:\n");
    scanf("%d",&n);
    int *arr=new int[n];
    printf("Input elements of array:\n");
    for(int i=0;i<n;i++){
        scanf("%d",&arr[i]);
    }
    for(int i=0;i<n;i++){
        if(arr[i]==0) k++;
    }
    printf("Number of zeros is %d",k);
    delete[] arr;
    return 0;
}
