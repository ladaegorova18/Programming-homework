#include <stdio.h>
#include <stdlib.h>
#include <locale>

int main()
{
    setlocale(LC_ALL, "Russian");
    int thefirstnumber = 0;
    int thesecondnumber = 0;
    printf("¬ведите числа:");
    scanf("%d %d", &thefirstnumber, &thesecondnumber);



    return 0;
}
