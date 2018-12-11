#pragma once
#include <vector>
#include <iostream>
const int INF = 1000000000;

struct Map
{
	// массив расстояний между городами
	std::vector< std::vector<int> > roads;

	// kingdoms[i] массив государств; в каждом есть список владений, принадлежащих им
	std::vector< std::vector<int> > kingdoms;

	// отмечаем здесь города, в которых были
	std::vector <bool> mark;

	// раздел территории
	void war();
};

// вывод на экран королевств и их владений
void printing(std::vector< std::vector<int> > kingdoms);
