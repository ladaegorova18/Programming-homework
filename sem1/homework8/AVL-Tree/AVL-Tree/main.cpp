#include "pch.h"
#include "Tree.h"
#include "Menu.h"
#include <iostream>
#include <locale>
#include <assert.h>

void test()
{
	Tree *testTree = makeTree();
	addData("apple", 4, testTree);
	addData("cherry", 7, testTree);
	addData("pear", 2, testTree);
	addData("grape", 8, testTree);
	addData("orange", 3, testTree);
	assert(getData(3, testTree) == "orange");
	assert(getData(2, testTree) == "pear");
	assert(getData(8, testTree) == "grape");
	assert(getData(4, testTree) == "apple");
	assert(getData(7, testTree) == "cherry");
	deleteInfo(3, testTree);
	deleteInfo(7, testTree);
	deleteInfo(2, testTree);
	deleteInfo(4, testTree);
	deleteInfo(8, testTree);
	assert(isEmpty(testTree));
	std::cout << "Тест пройден!" << std::endl;
	deleteTree(testTree);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Tree* myTree = makeTree();
	mainMenu(myTree);
	deleteTree(myTree);
	return 0;
}