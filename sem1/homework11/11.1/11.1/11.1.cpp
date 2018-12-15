#include "pch.h"
#include "Seek.h"
#include <iostream>
#include <string>
#include <locale>
#include <fstream>
#include <assert.h>
/*
void test()
{
	std::string testMainString = "abcabdabcabe";
	std::string testSample = "abcabe";
	assert(algorithmKMP(testMainString, testSample) == 6);
	std::string testAbcString = "abcabc";
	std::string testSampleAbc = "abc";
	assert(algorithmKMP(testAbcString, testSampleAbc) == 1);
	std::string testKkkString = "kkkkkkk";
	std::string testAString = "aaa";
	assert(algorithmKMP(testKkkString, testAString) == 0);
	std::cout << "Тест пройден:)" << std::endl;
}*/

int main()
{
	setlocale(LC_ALL, "rus");
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return 0;
	}
	std::cout << "Введите образец для поиска:" << std::endl;
	std::string sample = "";
	std::cin >> sample;
	if (algorithmKMP(file, sample) == 0)
	{
		std::cout << "Нет совпадений между файлом и строкой!:(" << std::endl;
		return -1;
	}
	std::cout << "Первый индекс вхождения образца в файл: " << algorithmKMP(file, sample) << std::endl;
	file.close();
	return 0;
}