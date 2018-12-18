#include "pch.h"
#include <iostream>
#include "List.h"
#include <fstream>
#include <locale>
#include <assert.h>
using namespace std;

void test()
{
	Node* list = nullptr;
	makeList(list);
	adding(list, 3);
	adding(list, 5);
	adding(list, 1);
	adding(list, 4);
	adding(list, 6);
	adding(list, 8);
	Node* newList = increaseList(list);
	Node* curr = newList;
	int values[] = { 1, 4, 6, 8 };
	int i = 0;
	while (curr)
	{
		assert(curr->value == values[i]);
		curr = curr->next;
		++i;
	}
	deleteList(list);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Node* list = nullptr;
	makeList(list);
	ifstream file("array.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		deleteList(list);
		return -1;
	}
	while (!file.eof())
	{
		int value = 0;
		file >> value;
		adding(list, value);
	}
	file.close();
	Node* newList = increaseList(list);
	std::cout << "Искомый список:" << std::endl;
	printing(newList);
	deleteList(list);
	std::cout << "До свидания!" << std::endl;
	return 0;
}