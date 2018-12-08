#include "pch.h"
#include "Hash-Table.h"
#include "List.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void test()
{
	Set* testSet = new Set();
	testSet->makeSet();
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "Тестовый файл не найден!" << std::endl;
		return;
	}
	while (!file.eof())
	{
		std::string buffer = " ";
		file >> buffer;
		testSet->adding(buffer);
	}
	file.close();
	assert(testSet->coefHash() < 1);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Set* set = new Set();
	set->makeSet();
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return -1;
	}
	while (!file.eof())
	{
		std::string buffer = " ";
		file >> buffer;
		set->adding(buffer);
	}
	file.close();
	std::cout << "Слова, встречающиеся в этом тексте:" << std::endl;
	set->printing();
	statistics(set);
	set->deleteSet();
	std::cout << "До свидания!" << std::endl;
	system("pause");
	return 0;
}