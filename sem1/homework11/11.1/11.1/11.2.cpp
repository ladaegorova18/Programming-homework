#include "pch.h"
#include "Seek.h"
#include <iostream>
#include <string>
#include <locale>
#include <fstream>
#include <assert.h>

void test()
{
	std::ifstream testFile("test.txt");
	if (!testFile)
	{
		std::cout << "Тестовый файл не найден!" << std::endl;
	}
	std::string testSample = "abcabe";
	int testResult = algorithmKMP(testFile, testSample);
	assert(testResult == 7);
	std::cout << "Тест пройден:)" << std::endl;
	testFile.close();
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return 0;
	}
	std::cout << "Введите образец для поиска:" << std::endl;
	std::string sample = "";
	std::cin >> sample;
	int result = algorithmKMP(file, sample);
	if (result == 0)
	{
		std::cout << "Нет совпадений между файлом и строкой!:(" << std::endl;
		return -1;
	}
	std::cout << "Первый индекс вхождения образца в файл: " << result << std::endl;
	file.close();
	return 0;
}