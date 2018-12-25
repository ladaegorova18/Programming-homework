#include "pch.h"
#include <locale>
#include <iostream>
#include <cctype>
#include <assert.h>
#include "Stack1.h"
using namespace std;

bool isOperator(char symbol)
{
	return ((symbol == '/') || (symbol == '*') || (symbol == '+') || (symbol == '-'));
}

bool isBracket(char symbol)
{
	return ((symbol == '(') || (symbol == ')'));
}

bool isLeftBracket(char symbol)
{
	return (symbol == '(');
}

void makeSpace(string &postfixExpression)
{
	postfixExpression += " ";
}

bool isPriorityOperator(char symbol)
{
	return ((symbol == '*') || (symbol == '/'));
}

bool isLast(char symbol)
{
	return (symbol == '|');
}

bool makingExpression(Stack *myStack, char symbol, string &postfixExpression)
{
	if (isdigit((int)symbol))
	{
		postfixExpression += symbol;
		makeSpace(postfixExpression);
	}
	else if (isOperator(symbol))
	{
		if (myStack->isEmpty() || isLeftBracket(myStack->topElement()))
		{
			myStack->push(symbol);
		}
		else if (isPriorityOperator(symbol) && !isPriorityOperator(myStack->topElement()))
		{
			myStack->push(symbol);
		}
		else
		{
			postfixExpression += myStack->pop();
			makeSpace(postfixExpression);
			makingExpression(myStack, symbol, postfixExpression);
		}
	}
	else if (isBracket(symbol))
	{
		if (isLeftBracket(symbol))
		{
			myStack->push(symbol);
		}
		else if (isOperator(myStack->topElement()))
		{
			postfixExpression += myStack->pop();
			makeSpace(postfixExpression);
			makingExpression(myStack, symbol, postfixExpression);
		}
		else if (isLeftBracket(myStack->topElement()))
		{
			myStack->pop();
		}
	}
	else if (isLast(symbol))
	{
		if (myStack->isEmpty())
		{
			return 1;
		}
		else if (isOperator(myStack->topElement()))
		{
			while (!myStack->isEmpty())
			{
				postfixExpression += myStack->pop();
				makeSpace(postfixExpression);
			}
		}
		else
		{
			return (!isLeftBracket((myStack->topElement())));
		}
	}
}

void test()
{	// Тест 1
	Stack *testNineStack = new Stack();
	string testNineString = "5 + 4 | ";
	string resultExpression = "";
	int i = 0;
	while (testNineString[i])
	{
		makingExpression(testNineStack, testNineString[i], resultExpression);
		i++;
	}
	assert (resultExpression == "5 4 + ");
	// Тест 2
	Stack *testBracketsStack = new Stack();
	string testBracketsString = "(1 + 1) * 2 |";
	resultExpression = "";
	i = 0;
	while (testBracketsString[i])
	{
		makingExpression(testBracketsStack, testBracketsString[i], resultExpression);
		i++;
	}
	assert(resultExpression == "1 1 + 2 * ");
	// тест 3
	Stack *testMultipWithoutBracketsStack = new Stack();
	string testMultipWithoutBracketsString = "1 + 2 * 3 + 4 |";
	resultExpression = "";
	i = 0;
	while (testMultipWithoutBracketsString[i])
	{
		makingExpression(testMultipWithoutBracketsStack, testMultipWithoutBracketsString[i], resultExpression);
		i++;
	}
	assert(resultExpression == "1 2 3 * + 4 + ");
	delete testNineStack;
	delete testBracketsStack;
	delete testMultipWithoutBracketsStack;
	cout << "Тест пройден:)" << endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Stack *myStack = new Stack();
	myStack->makeStack();
	string postfixExpression = "";
	cout << "Введите арифметическое выражение в инфиксной форме, для окончания ввода нажмите |:" << endl;
	char symbol = ' ';
	while (symbol != '|')
	{
		cin >> symbol;
		makingExpression(myStack, symbol, postfixExpression);
	}
	cout << "Выражение в постфиксной форме:" << endl;
	cout << postfixExpression << endl;
	cout << "До свидания!" << endl;
	delete myStack;
	return 0;
}