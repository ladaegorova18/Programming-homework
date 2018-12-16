#include "pch.h"
#include "Tree.h"
#include "Menu.h"
#include <iostream>
#include <locale>
#include <assert.h>

void test()
{
	Tree *testTree = new Tree();
	makeTree(testTree);
	adding("apple", 4, testTree->root);
	adding("cherry", 7, testTree->root);
	adding("pear", 2, testTree->root);
	adding("grape", 8, testTree->root);
	adding("orange", 3, testTree->root);
	assert(getData(3, testTree->root) == "orange");
	assert(getData(2, testTree->root) == "pear");
	assert(getData(8, testTree->root) == "grape");
	assert(getData(4, testTree->root) == "apple");
	assert(getData(7, testTree->root) == "cherry");
	deleteData(3, testTree->root, testTree->root);
	deleteData(7, testTree->root, testTree->root);
	deleteData(4, testTree->root, testTree->root);
	deleteData(2, testTree->root, testTree->root);
	deleteData(8, testTree->root, testTree->root);
	assert(isEmpty(testTree));
	std::cout << "Тест пройден!" << std::endl;
	deleteTree(testTree->root);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Tree* myTree = new Tree();
	makeTree(myTree);
	mainMenu(myTree);
	deleteTree(myTree->root);
	return 0;
}