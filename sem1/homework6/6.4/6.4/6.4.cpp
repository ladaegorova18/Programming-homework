#include "pch.h"
#include <iostream>
#include <locale>
#include <fstream>
#include <assert.h>
#include "List.h"

void test()
{
	List* testNameSort = makingList();
	addingData(testNameSort, "Ольга", 23);
	addingData(testNameSort, "Алина", 6);
	addingData(testNameSort, "Павел", 44);
	addingData(testNameSort, "Дмитрий", 12);
	addingData(testNameSort, "Григорий", 5);
	mergeSort(testNameSort, '1');
	std::string names[] = { "Алина", "Григорий", "Дмитрий", "Ольга", "Павел" };
	List* temp = testNameSort;
	for (int i = 0; i < 5; i++)
	{
		assert(getName(temp) == names[i]);
		temp = nextNode(temp);
	}
	List* testNumberSort = makingList();
	addingData(testNumberSort, "Ольга", 23);
	addingData(testNumberSort, "Алина", 6);
	addingData(testNumberSort, "Павел", 44);
	addingData(testNumberSort, "Дмитрий", 12);
	addingData(testNumberSort, "Григорий", 5);
	mergeSort(testNumberSort, '2');
	int numbers[] = { 5, 6, 12, 23, 44 };
	temp = testNumberSort;
	for (int i = 0; i < 5; i++)
	{
		assert(getNumber(temp) == numbers[i]);
		temp = nextNode(temp);
	}
	std::cout << "Тест пройден!" << std::endl;
	deleteList(temp);
	deleteList(testNameSort);
	deleteList(testNumberSort);
}

void fileRead(std::ifstream &file, List*& head)
{
	while (!file.eof())
	{
		std::string tempName = "";
		int tempPhoneNumber = 0;
		file >> tempName;
		file >> tempPhoneNumber;
		addingData(head, tempName, tempPhoneNumber);
	}
}

int main()
{
	setlocale(LC_ALL, "ru");
	test();
	List *head = makingList();
	std::ifstream file;
	file.open("phonebook.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		deleteList(head);
		return -1;
	}
	fileRead(file, head);
	file.close();
	std::cout << "Выберите, как отсортировать записи в файле, " << std::endl;
	std::cout << "по имени (нажмите 1) или по номеру телефона (нажмите 2):" << std::endl;
	char key = ' ';
	std::cin >> key;
	mergeSort(head, key);
	std::cout << "Отсортированный файл выглядит так:" << std::endl;
	printData(head);
	deleteList(head);
	std::cout << std::endl;
	std::cout << "До свидания!" << std::endl;
	return 0;
}

