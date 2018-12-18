#include "pch.h"
#include "List.h"
#include <iostream>
#include <locale>
#include <assert.h>

void test();

void mainText()
{
	std::cout << "Здравствуйте! Нажмите: " << std::endl;
	std::cout << "0, чтобы выйти" << std::endl;
	std::cout << "1, чтобы добавить значение в заданную позицию в двусвязный список" << std::endl;
	std::cout << "2, чтобы удалить значение из заданной позиции списка" << std::endl;
	std::cout << "3, чтобы распечатать список" << std::endl;
}

void mainMenu(Node *&list)
{
	char key = ' ';
	mainText();
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
			int position = 0;
			std::cin >> position;
			add(list, value, position);
			break;
			}
		case '2':
		{
			std::cout << "Введите позицию" << std::endl;
			int position = 0;
			std::cin >> position;
			deleteFromPos(list, position);
			break;
		}
		case '3':
		{
			if (list == nullptr)
			{
				std::cout << "Список пуст" << std::endl;
				break;
			}
			print(list);
			break;
		}
		}
		mainText();
		std::cin >> key;
	}
}

void test()
{
	Node* list;
	makeList(list);
	add(list, 5, 0);
	add(list, 4, 1);
	add(list, 2, 0);
	add(list, 3, 2);
	add(list, 1, 0);
	int array[] = { 1, 2, 5, 3, 4 };
	Node* temp = list;
	for (int i = 0; i < 4; ++i)
	{
		assert(temp->value == array[i]);
		temp = temp->next;
	}
	deleteList(list);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Node* list;
	makeList(list);
	mainMenu(list);
	deleteList(list);
	std::cout << "До свидания!" << std::endl;
}