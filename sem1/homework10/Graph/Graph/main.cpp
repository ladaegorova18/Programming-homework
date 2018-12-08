#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>

int main()
{
	setlocale(LC_ALL, "rus");
	std::ifstream file("kingdoms.txt");
	if (!file)
	{
		std::cout << "‘айл не найден!" << std::endl;
		return -1;
	}
	int n = 0; // cities
	int m = 0; // roads
	while (!file.eof())
	{
		int i = 0;
		int j = 0;
		int len = 0;
		std::cin >> i >> j >> len;

	}
	std::cout << "¬ведите число столиц: " << std::endl;
	int k = 0;
	std::cin >> k;


	return 0;
}