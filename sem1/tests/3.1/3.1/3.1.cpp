#include "pch.h"
#include <iostream>
#include <locale>
#include "List.h"

int main()
{
	setlocale(LC_ALL, "rus");
	std::cout << "Введите числа: ";
	DynList *list = new DynList;
	int number = 1;
	while (number != 0)
	{
		std::cin >> number;
		insertion(list, number);
	}
	std::cout << "Frequency is:" << std::endl;
	printData(list);
	deleteList(list);
	system("pause");
	return 0;
}