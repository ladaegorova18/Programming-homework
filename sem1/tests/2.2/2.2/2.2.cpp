#include "pch.h"
#include "List.h"
#include <iostream>
#include <locale>
#include <fstream>
#include <assert.h>

void addToList(std::ifstream &file, Node*& head, int count)
{
	for (int i = 0; i < count; ++i)
	{
		int value = 0;
		file >> value;
		addingData(head, value);
	}
}

void writeToFile(std::ofstream &file, Node*& head)
{
	Node* temp = head;
	while (temp)
	{
		file << getValue(temp);
		temp = nextNode(temp);
		file << " ";
	}
}

void test()
{
	Node* firstTestList = makingList();
	Node* secondTestList = makingList();
	int firstKeys[] = { 1, 3, 6, 7 };
	int secondKeys[] = { 2, 4, 6, 6, 8 };
	for (int i = 0; i < 4; ++i)
	{
		addingData(firstTestList, firstKeys[i]);
	}
	for (int j = 0; j < 5; ++j)
	{
		addingData(secondTestList, secondKeys[j]);
	}
	Node* testResult = merge(firstTestList, secondTestList);
	int resultKeys[] = { 1, 2, 3, 4, 6, 6, 6, 7, 8 };
	Node* temp = testResult;
	int i = 0;
	while (temp)
	{
		assert(getValue(temp) == resultKeys[i]);
		temp = nextNode(temp);
		++i;
	}
	std::cout << "Тест пройден!" << std::endl;
	deleteList(testResult);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	std::ifstream file("lists.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return -1;
	}
	int count = 0;
	file >> count;
	Node* firstList = makingList();
	addToList(file, firstList, count);
	file >> count;
	Node* secondList = makingList();
	addToList(file, secondList, count);
	file.close();
	Node* result = merge(firstList, secondList);
	std::ofstream resultFile("result.txt");
	writeToFile(resultFile, result);
	resultFile.close();
	deleteList(result);
	std::cout << "Данные записаны в файл!" << std::endl;
	return 0;
}