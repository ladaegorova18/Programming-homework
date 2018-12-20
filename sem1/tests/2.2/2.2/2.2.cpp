#include "pch.h"
#include "List.h"
#include <iostream>
#include <locale>
#include <fstream>
#include <assert.h>

void test()
{
	Node* list = makeList();
	add(list, "hey");
	add(list, "i");
	add(list, "am");
	add(list, "fine");
	add(list, "maybe");
	add(list, "not");
	add(list, "hey");
	makeUnrepList(list);
	std::string res[] = { "hey", "i", "am", "fine", "maybe", "not" };
	print(list);
	Node* curr = list;
	int i = 0;
	while (curr)
	{
		std::cout << getInfo(curr);
		assert(getInfo(curr) == res[i]);
		curr = nextNode(curr);
		++i;
	}
	deleteList(list);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Node* list = makeList();
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "File not found!" << std::endl;
		return -1;
	}
	while (!file.eof())
	{
		std::string buffer = " ";
		std::getline(file, buffer);
		add(list, buffer);
	}
	std::cout << "Исходный список:" << std::endl;
	print(list);
	Node* newList = makeUnrepList(list);
	std::cout << "Новый список: " << std::endl;
	print(newList);
	deleteList(newList);
	deleteList(list);
	std::cout << "До свидания!" << std::endl;
	return 0;
}