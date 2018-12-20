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
	Tree *testTree = new Tree();
	testTree->makeTree();
	Element* current = testTree->getRoot();
	for (int i = 0; i < 10; i++)
	{
		if (resultFour[i] != '(')
		{
			current = testTree->adding(resultFour[i], current);
		}
	}
	assert(testTree->count(current) == 4);
	testTree->deleteTree(current);
	string resultEighteen = "(*(+33)(-52))";
	Tree *testEighteenTree = new Tree();
	testEighteenTree->makeTree();
	current = testEighteenTree->getRoot();
	for (int i = 0; i < 14; i++)
	{
		if (resultEighteen[i] != '(')
		{
			current = testEighteenTree->adding(resultEighteen[i], current);
		}
	}
	assert(testEighteenTree->count(current) == 18);
	cout << "Тест пройден:)" << endl;
	testEighteenTree->deleteTree(current);
}

int main()
{
	setlocale(LC_ALL, "ru");
	test();
	Tree *myTree = new Tree();
	myTree->makeTree();
	Element* current = myTree->getRoot();
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
				current = myTree->adding(symbol, current);
			}
		}
	}
	fclose(file);
	cout << "Сейчас дерево выглядит так:" << endl;
	myTree->printing(current, 0);
	cout << "Результат равен: " << myTree->count(current) << endl;
	myTree->deleteTree(current);
	return 0;
}