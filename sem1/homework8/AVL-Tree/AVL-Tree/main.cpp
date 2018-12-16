#include "pch.h"
#include "Tree.h"
#include "Menu.h"
#include <iostream>
#include <locale>
#include <assert.h>

void test()
{
	Tree *testTree = new Tree();
	testTree->makeTree();
	Node* root = testTree->getRoot();
	testTree->adding("apple", 4, root);
	testTree->adding("cherry", 7, root);
	testTree->adding("pear", 2, root);
	testTree->adding("grape", 8, root);
	testTree->adding("orange", 3, root);
	assert(testTree->getSize() == 5);
	testTree->deleteData(3, root);
	testTree->deleteData(7, root);
	testTree->deleteData(2, root);
	testTree->deleteData(8, root);
	testTree->deleteData(4, root);
	assert(testTree->isEmpty());
	testTree->deleteTree(root);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Tree* myTree = new Tree();
	myTree->makeTree();
	mainMenu(myTree);
	Node* root = myTree->getRoot();
	myTree->deleteTree(root);
	return 0;
}