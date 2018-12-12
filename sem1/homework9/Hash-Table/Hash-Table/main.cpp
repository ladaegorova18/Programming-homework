#include "pch.h"
#include "Hash-Table.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void reading(std::ifstream &file, Set &set)
{
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return;
	}
	while (!file.eof())
	{
		std::string buffer = " ";
		file >> buffer;
		adding(set, buffer);
	}
}

void test()
{
	Set testSet;
	makeSet(testSet);
	std::ifstream file("test.txt");
	reading(file, testSet);
	file.close();
	printing(testSet);
	assert(count(testSet, "в") == 4);
	assert(count(testSet, "все") == 1);
	assert(count(testSet, "коэффициент") == 1);
	assert(count(testSet, "лимоны") == 0);
	assert(coefHash(testSet) < 1);
	std::cout << "Тест пройден!" << std::endl;
	deleteSet(testSet);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Set set;
	makeSet(set);
	std::ifstream file("text.txt");
	reading(file, set);
	file.close();
	std::cout << "Слова, встречающиеся в этом тексте:" << std::endl;
	printing(set);
	statistics(set);
	deleteSet(set);
	std::cout << "До свидания!" << std::endl;
	return 0;
}