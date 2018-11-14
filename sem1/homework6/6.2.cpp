#include <iostream>
#include <locale>
#include <cstring>
#include "Stack1.h"
using namespace std;

bool isBracket(char symbol)
{
    return ((symbol == '[') || (symbol == '(') || (symbol == '{') || (symbol == ']') || (symbol == ')') || (symbol == '}'));
}

bool equasion(char leftBracket, char rightBracket)
{
    switch (leftBracket)
    {
    case '[':
        {
            if (rightBracket == ']')
            {
                return true;
            }
            else
            {
                return false;
            }
            break;
        }
    case '{':
        {
            if (rightBracket == '}')
            {
                return true;
            }
            else
            {
                return false;
            }
            break;
        }
    case '(':
        {
            if (rightBracket == ')')
            {
                return true;
            }
            else
            {
                return false;
            }
            break;
        }
    default:
        {
            return false;
        }
    }
}

int main()
{
    setlocale(LC_ALL, "Russian");
    stack *myStack = new stack();
    myStack->makeStack(myStack);
    char myString[MAX] = " ";
    cout << "Введите строку:" << endl;
    cin >> myString;
    int length = strlen(myString);
    for (int i = 0; i < length; i++)
    {
        if (isBracket(myString[i]))
        {
            myStack->push(myStack, (int) myString[i]);
            if (myStack->top >= 2)
            {
                char rightBracket = myStack->pop(myStack);
                char leftBracket = myStack->pop(myStack);
                if (!equasion(leftBracket, rightBracket))
                {
                    myStack->push(myStack, leftBracket);
                    myStack->push(myStack, rightBracket);
                }
            }
        }
    }
    if (myStack->top > 0)
    {
        cout << "Скобки в строке расставлены неправильно:(" << endl;
    }
    else
    {
        cout << "Скобки в строке стоят правильно:)" << endl;
    }
    return 0;
}
