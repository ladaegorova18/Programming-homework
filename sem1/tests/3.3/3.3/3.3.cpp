#include "pch.h"
#include <iostream>
#include <fstream>
#include <vector>
using namespace std;

int* seeking(vector<vector<int>> roads)
{
	std::vector<std::vector<int>> vertices;
	int size = roads.size();
	for (int i = 0; i < size; ++i)
	{
		int count = 0;
		for (int j = 0; j < size; ++j)
		{
			if ((i != j) && (roads[i][j] > 0))
			{
				count++;
			}
		}
		if (count == size - 1)
		{
			vertices.push_back[i];
		}
	}
}

void print(std::vector<int> result)
{
	int size = result.size();
	for (int i = 0; i < size; ++i)
	{
		std::cout << result[i];
	}
}

int main()
{
	vector<vector<int>> roads;
	cout << "Enter size of matrix: " << endl;
	int size = 0;
	cin >> size;
	roads.resize(size);
	cout << "Enter the elements: " << endl;
	for (int i = 0; i < size; ++i)
	{
		roads[i].resize(size);
	}
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			int value = 0;
			cin >> value;
			roads[i].push_back(value);
		}
	}
	int* result = seeking(roads);
	print(result);
	for (int i = 0; i < size; i++)
	{
		roads[i].clear();
	}
	delete[] result;
	return 0;
}
