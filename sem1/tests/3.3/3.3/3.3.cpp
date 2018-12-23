#include "pch.h"
#include <iostream>
#include <fstream>
#include <vector>
using namespace std;

void seeking(vector<vector<int>> &matrix, int vertice, vector<bool> &used)
{
	for (int j = 0; j < (int) matrix[vertice].size(); ++j)
	{
		if (matrix[vertice][j] == -1)
		{
			int fromVertice = 0;
			while (matrix [fromVertice][j] != 1)
			{
				++fromVertice;
			}
			if (!used[fromVertice])
			{
				used[vertice] = true;
				seeking(matrix, fromVertice, used);
			}
		}
	}
	used[vertice] = true;
}

void print(vector<int> result)
{
	int size = result.size();
	for (int i = 0; i < size; ++i)
	{
		std::cout << result[i];
	}
}

int main()
{
	vector<vector<int>> matrix;
	ifstream file("matrix.txt");
	if (!file)
	{
		cout << "File not found!" << endl;
		return -1;
	}
	int rows = 0;
	int columns = 0;
	file >> rows;
	file >> columns;
	matrix.resize(rows);
	for (int i = 0; i < columns; ++i)
	{
		matrix[i].resize(columns);
	}
	while (!file.eof())
	{
		for (int i = 0; i < rows; ++i)
		{
			for (int j = 0; j < columns; ++j)
			{
				file >> matrix[i][j];
			}
		}
	}
	file.close();
	vector <int> result;
	for (int i = 0; i < rows; ++i)
	{
		vector<bool> used(rows);
		seeking(matrix, i, used);
		bool isAccessed = true;
		for (int j = 0; j < rows; ++j)
		{
			if (!used[j])
			{
				isAccessed = false;
				break;
			}
		}
		if (isAccessed)
		{
			result.push_back(i);
		}
	}
	print(result);
	return 0;
}
