#include "pch.h"
#include <iostream>
#include <locale>
#include "Stack1.h"
using namespace std;

bool isOper(char symbol)
{
	return ((symbol == '/') || (symbol == '*') || (symbol == '-') || (symbol == '+'));
}

int operation(int a, int b, char symbol)
{
	int tempResult = 0;
	switch (symbol)
	{
		case '+':
		{
			tempResult = a + b;
			break;
		}
		case '-':
		{
			tempResult = a - b;
			break;
		}
		case '/':
		{
			tempResult = a / b;
			break;
		}
		case '*':
		{
			tempResult = a * b;
			break;
		}
	}
	return tempResult;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	stack *myStack = new stack;
	myStack->makeStack(myStack);
	cout << "Введите последовательность цифр и арифметических операций, для окончания ввода введите Q:" << endl;
	char symbol = ' ';
	int result = 0;
	while (symbol != 'Q')
	{
		cin >> symbol;
		myStack->push(myStack, symbol);
		if ((myStack->top > 2) && (isOper(symbol)))
		{
			myStack->pop(myStack);
			int last = (int)myStack->pop(myStack) - 48;
			int first = (int)myStack->pop(myStack) - 48;
			myStack->push(myStack, (char)(operation(first, last, symbol) + 48));
		}
	}
	myStack->pop(myStack);
	result = (int)myStack->pop(myStack) - 48;
	cout << "Результат равен: " << result << endl;
	return 0;
}
