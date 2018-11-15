#include <stdio.h>
#include <stdlib.h>
#include <locale>
#include <math.h>
#include <assert.h>
const int SIZE = 8;
const int MAX = 10;

void test()
{
    char binary127[SIZE] = "01111111";
    char binary1[SIZE] = "00000001";
    char binaryNegative127[SIZE] = "11111111";
    char binaryNegative100[SIZE] = "11100100";
}

char *conversion(int number)
{
    int bit = 0b10000000;
    char *binaryNumber = new char[SIZE]{};
    for (int j = 0; j < SIZE; j++)
    {
        binaryNumber[j] = ((number & bit) ? '1' : '0');
        bit = bit >> 1;
    }
    return binaryNumber;
}

char *decimaltobin(int number)
{
    if (number >= 0)
    {
        return conversion(number);
    }
    else if (number < 0)
    {
        int negativenum = MAX * 2 + number;
        return conversion(negativenum);
    }
}

void summary(char* first, char* second)
{
    int *result = new int[SIZE]{0};
    for (int i = SIZE - 1; i > -1; i--)
    {
        if ((first[i] == '1') || (second[i] == '1'))
        {
            if (first[i] == second[i])
            {
               result[i - 1] = 1;
            }
            else
            {
                if (result[i] == 1)
                {
                    result[i] = 0;
                    result[i - 1] = 1;
                }
                else
                {
                    result[i] = 1;
                }
            }
        }
    }
    for (int i = 0; i < SIZE; i++)
    {
        printf("%d", result[i]);
    }
}

void invertion(char* binnumber)
{
    for (int i = 0; i < SIZE; i++)
    {
        if (binnumber[i] == '1')
        {
            binnumber[i] = '0';
        }
        else
        {
            binnumber[i] = '1';
        }
    }
}

int binarytodecimal(char* binnumber)
{
    int decimalnumber = 0;
    for (int i = 0; i < SIZE; i++)
    {
        if (binnumber[i] == '1')
        {
            decimalnumber += pow(2.0, (SIZE - i - 1));
        }
    }
    if (decimalnumber > MAX)
    {
        decimalnumber = (decimalnumber - MAX * 2);
    }
    return decimalnumber;
}

int main()
{
    setlocale(LC_ALL, "Russian");
    int thefirstnumber = 0;
    int thesecondnumber = 0;
    printf("Введите числа в десятичной системе счисления:\n");
    scanf("%d %d", &thefirstnumber, &thesecondnumber);
    char *firstbinary = new char[SIZE];
    char *secondbinary = new char[SIZE];
    firstbinary = decimaltobin(thefirstnumber);
    secondbinary = decimaltobin(thesecondnumber);
    printf("В двоичной системе:\n%s\n%s\n", firstbinary, secondbinary);
    printf("Сумма в двоичной системе счисления:\n");
    summary(firstbinary, secondbinary);
    printf("\nЧисла в десятичной системе счисления:\n%d\n%d\nСумма в десятичной системе счисления: %d", binarytodecimal(firstbinary), binarytodecimal(secondbinary), binarytodecimal(firstbinary) + binarytodecimal(secondbinary));
    return 0;
}
