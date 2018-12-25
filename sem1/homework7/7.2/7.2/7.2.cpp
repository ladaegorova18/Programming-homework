#include "pch.h"
#define _CRT_SECURE_NO_WARNINGS
#include <fstream>
#include <locale>
#include <assert.h>
#include <iostream>
#include "MathTree.h"
using namespace std;

void test()
{
	string resultFour = "(*(+11)2)";
	Tree *testTree = makeTree();
	Element* current = getRoot(testTree);
	for (int i = 0; i < 10; i++)
	{
		if (resultFour[i] != '(')
		{
			current = adding(testTree, resultFour[i], current);
		}
	}
	assert(count(current) == 4);
	deleteTree(testTree);
	string resultEighteen = "(*(+33)(-52))";
	Tree *testEighteenTree = makeTree();
	current = getRoot(testEighteenTree);
	for (int i = 0; i < 14; i++)
	{
		if (resultEighteen[i] != '(')
		{
			current = adding(testEighteenTree, resultEighteen[i], current);
		}
	}
	assert(count(current) == 18);
	deleteTree(testEighteenTree);
	cout << "Тест пройден:)" << endl;
}

int main()
{
	setlocale(LC_ALL, "ru");
	test();
	Tree *myTree = makeTree();
	Element* current = getRoot(myTree);
	FILE *file = fopen("math.txt", "a+");
	if (!file)
	{
		cout << "Файл не найден!" << endl;
	}
	else
	{
		while (!feof(file))
		{
			char symbol = getc(file);
			if (symbol != '(')
			{
				current = adding(myTree, symbol, current);
			}
		}
	}
	fclose(file);
	cout << "Сейчас дерево выглядит так:" << endl;
	printing(current, 0);
	cout << "Результат равен: " << count(current) << endl;
	deleteTree(myTree);
	return 0;
}