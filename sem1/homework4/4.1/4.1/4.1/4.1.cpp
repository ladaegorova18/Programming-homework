#include "pch.h"
#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>
#include <stdio.h>
#include <locale>
#include <assert.h>
const int SIZE = 32;
using namespace std;

bool *conversion(int number)
{
    unsigned bit = 1 << 31;
    bool *binaryNumber = new bool[SIZE + 1]{0};
    for (int j = 0; j < SIZE; j++)
    {
        binaryNumber[j] = ((number & bit) ? 1 : 0);
        bit = bit >> 1;
    }
    return binaryNumber;
}

bool *sum(bool* first, bool* second)
{
    bool *result = new bool[SIZE + 1]{0};
    for (int i = SIZE - 1; i > -1; i--)
    {
        if ((first[i]) || (second[i]))
        {
            if (first[i] == second[i])
            {
               result[i - 1] = 1;
            }
            else if (result[i] == 1)
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
    return result;
}

int binaryToDecimal(bool* binNumber)
{
    long int decimalNumber = 0;
    int addition = 1;
    for (int i = SIZE - 1; i > -1; i--)
    {
        if (binNumber[i] == 1)
        {
            decimalNumber += addition;
        }
        addition *= 2;
    }
    return decimalNumber;
}

bool *decimalToBin(int number)
{
	return conversion(number);  
}

void printing(bool *binaryNumber)
{
    int j = 0;
    for (int i = 0; i < SIZE; i++)
    {
        printf("%d", binaryNumber[i]);
        j++;
        if (j == 8)
        {
            printf(" ");
            j = 0;
        }
    }
}

void test()
{
    int numberOne = 1;
    int maxNumberMinusOne = (1 << 31) - 2;
    bool *oneToBinary = decimalToBin(numberOne);
    bool *maxToBinary = decimalToBin(maxNumberMinusOne);
	bool *binResult = sum(oneToBinary, maxToBinary);
    int result = binaryToDecimal(binResult);
    assert(result == (1 << 31) - 1);
    int negativeTwo = -2;
    int negativeMaxPlusTwo = ((1 << 31) - 2) * (-1);
    bool *negTwoToBinary = decimalToBin(negativeTwo);
    bool *negMaxToBinary = decimalToBin(negativeMaxPlusTwo);
	bool *negBinResult = sum(negTwoToBinary, negMaxToBinary);
    int resultOfNegative = binaryToDecimal(negBinResult);
    assert(resultOfNegative == (1 << 31) * (-1));
    printf("Test passed\n");
	delete[] oneToBinary;
	delete[] maxToBinary;
	delete[] binResult;
	delete[] negTwoToBinary;
	delete[] negMaxToBinary;
	delete[] negBinResult;
}

int main()
{
	test();
    setlocale(LC_ALL, "Russian");
    int theFirstNumber = 0;
    int theSecondNumber = 0;
    printf("Введите числа в десятичной системе счисления:\n");
    scanf("%d %d", &theFirstNumber, &theSecondNumber);
    bool *firstBinary = new bool[SIZE + 1];
    bool *secondBinary = new bool[SIZE + 1];
    firstBinary = decimalToBin(theFirstNumber);
    secondBinary = decimalToBin(theSecondNumber);
    printf("В двоичной системе:\n");
    printing(firstBinary);
    printf("\n");
    printing(secondBinary);
    printf("\n");
    printf("Сумма в двоичной системе счисления:\n");
	bool *binResult = new bool[SIZE + 1];
	binResult = sum(firstBinary, secondBinary);
    printing(binResult);
    printf("\nЧисла в десятичной системе счисления:\n%d\n%d\nСумма в десятичной системе счисления: %d\n", binaryToDecimal(firstBinary), binaryToDecimal(secondBinary), binaryToDecimal(firstBinary) + binaryToDecimal(secondBinary));
	delete[] firstBinary;
	delete[] secondBinary;
	delete[] binResult;
	system("pause");
    return 0;
}
