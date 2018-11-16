#include <stdio.h>
#include <stdlib.h>
#include <locale>
#include <math.h>
#include <assert.h>
const int SIZE = 8;
const int MAX = 10;

void test()
{
    bool binary127[SIZE] = {0, 1, 1, 1, 1, 1, 1, 1};
    bool binary1[SIZE] = {0, 0, 0, 0, 0, 0, 0, 1};
    bool binaryNegative127[SIZE] = {1, 1, 1, 1, 1, 1, 1, 1};
    bool binaryNegative100[SIZE] = {1, 1, 1, 0, 0, 1 ,0 ,0};
}

bool *conversion(int number)
{
    int bit = 0b10000000;
    bool *binaryNumber = new bool[SIZE]{};
    for (int j = 0; j < SIZE; j++)
    {
        binaryNumber[j] = ((number & bit) ? 1 : 0);
        bit = bit >> 1;
    }
    return binaryNumber;
}

bool *decimalToBin(int number)
{
    if (number >= 0)
    {
        return conversion(number);
    }
    else if (number < 0)
    {
        int negativeNum = MAX * 2 + number;
        return conversion(negativeNum);
    }
}

void summary(bool* first, bool* second)
{
    int *result = new int[SIZE]{0};
    for (int i = SIZE - 1; i > -1; i--)
    {
        if ((first[i] == 1) || (second[i] == 1))
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

void invertion(bool* binNumber)
{
    for (int i = 0; i < SIZE; i++)
    {
        if (binNumber[i] == 1)
        {
            binNumber[i] = 0;
        }
        else
        {
            binNumber[i] = 1;
        }
    }
}

int binaryToDecimal(bool* binNumber)
{
    int decimalNumber = 0;
    for (int i = 0; i < SIZE; i++)
    {
        if (binNumber[i] == 1)
        {
            decimalNumber += pow(2.0, (SIZE - i - 1));
        }
    }
    if (decimalNumber > MAX)
    {
        decimalNumber = (decimalNumber - MAX * 2);
    }
    return decimalNumber;
}

void printing(bool *binaryNumber)
{
    for (int i = 0; i < SIZE; i++)
    {
        printf("%d", binaryNumber[i]);
    }
}

int main()
{
    setlocale(LC_ALL, "Russian");
    int theFirstNumber = 0;
    int theSecondNumber = 0;
    printf("Введите числа в десятичной системе счисления:\n");
    scanf("%d %d", &theFirstNumber, &theSecondNumber);
    bool *firstBinary = new bool[SIZE];
    bool *secondBinary = new bool[SIZE];
    firstBinary = decimalToBin(theFirstNumber);
    secondBinary = decimalToBin(theSecondNumber);
    printf("В двоичной системе:\n");
    printing(firstBinary);
    printf("\n");
    printing(secondBinary);
    printf("\n");
    printf("Сумма в двоичной системе счисления:\n");
    summary(firstBinary, secondBinary);
    printf("\nЧисла в десятичной системе счисления:\n%d\n%d\nСумма в десятичной системе счисления: %d", binaryToDecimal(firstBinary), binaryToDecimal(secondBinary), binaryToDecimal(firstBinary) + binaryToDecimal(secondBinary));
    return 0;
}
