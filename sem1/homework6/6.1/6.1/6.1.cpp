#include "pch.h"
#include <assert.h>
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

void reading(Stack *myStack)
{
	cout << "Введите последовательность цифр и арифметических операций, для окончания ввода введите Q:" << endl;
	char symbol = ' ';
	while (symbol != 'Q')
	{
		cin >> symbol;
		myStack->push(symbol);
		if ((myStack->sizeOfStack() > 2) && (isOper(symbol)))
		{
			myStack->pop();
			int last = myStack->pop() - '0';
			int first = myStack->pop() - '0';
			myStack->push((char)(operation(first, last, symbol) + '0'));
		}
	}
}

void test()
{	//first test
	Stack *testNineStack = new Stack();
	testNineStack->push('4');
	testNineStack->push('5');
	testNineStack->push('+');
	char symbol = testNineStack->pop();
	int last = testNineStack->pop() - '0';
	int first = testNineStack->pop() - '0';
	assert(operation(first, last, symbol) == 9);
	//second test
	cout << "Тест пройден" << endl;
	Stack *testOneStack = new Stack();
	testOneStack->push('9');
	testOneStack->push('8');
	testOneStack->push('-');
	symbol = testOneStack->pop();
	last = testOneStack->pop() - '0';
	first = testOneStack->pop() - '0';
	assert(operation(first, last, symbol) == 1);
	delete testNineStack;
	delete testOneStack;
}

int main()
{
	setlocale(LC_ALL, "ru");
	test();
	Stack *myStack = new Stack;
	myStack->makeStack();
	reading(myStack);
	myStack->pop();
	int result = (int)myStack->pop() - '0';
	cout << "Результат равен: " << result << endl;
	delete myStack;
	return 0;
}
