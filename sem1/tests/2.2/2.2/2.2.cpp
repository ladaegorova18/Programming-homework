#include "pch.h"
#include "List.h"
#include <iostream>
#include <locale>
#include <fstream>
#include <assert.h>

void test()
{
	Node* list = makeList();
	add(list, 3, 0);
	add(list, 4, 1);
	add(list, 1, 2);
	add(list, 5, 3);
	add(list, 8, 1);
	int result[] = { 3, 8, 4, 1, 5 };
	int i = 0;
	Node* temp = list;
	while (temp)
	{
		assert(getValue(temp) == result[i]);
		temp = getNext(temp);
		++i;
	}
	deleteList(list);
	std::cout << "Тест пройден!" << std::endl;
}

void mainText()
{
	std::cout << "Нажмите 1, чтобы добавить значение в позицию:" << std::endl;
	std::cout << "Нажмите 2, чтобы удалить значение из позиции:" << std::endl;
	std::cout << "Нажмите 3, чтобы распечатать список:" << std::endl;
	std::cout << "Нажмите 0, чтобы выйти." << std::endl;
}

void mainMenu(Node* list)
{
	mainText();
	char key = ' ';
	std::cin >> key;
	while (key != '0')
	{
		switch (key)
		{
		case '1':
		{
			std::cout << "Введите значение:" << std::endl;
			int value = 0;
			std::cin >> value;
			std::cout << "Введите позицию:" << std::endl;
			int pos = 0;
			std::cin >> pos;
			if (!add(list, value, pos))
			{
				std::cout << "Неверная позиция!" << std::endl;
			}
			break;
		}
		case '2':
		{
			std::cout << "Введите позицию:" << std::endl;
			int pos = 0;
			std::cin >> pos;
			if (!deleting(list, pos))
			{
				std::cout << "Неверная позиция!" << std::endl;
			}
			break;
		}
		case '3':
		{
			if (isEmpty(list))
			{
				std::cout << "Список пуст!" << std::endl;
			}
			print(list);
			break;
		}
		}
		mainText();
		std::cin >> key;
	}
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Node* list = makeList();
	mainMenu(list);
	deleteList(list);
	std::cout << "До свидания!" << std::endl;
	return 0;
}