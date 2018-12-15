#include "pch.h"
#include "Seek.h"
#include <fstream>

int* prefixFunction(std::string str, int len)
{
	int *index = new int[len] {0};
	for (int i = 0; i < len - 1; i++)
	{
		if (str[i + 1] == str[index[i]])
		{
			index[i + 1] = index[i] + 1;
		}
		else
		{
			index[i + 1] = 0;
		}
	}
	return index;
}

int algorithmKMP(std::ifstream &file, std::string sample)
{
	int sampleLen = sample.length();
	int equalIndex = 0;
	int *index = prefixFunction(sample, sampleLen);
	std::cout << index[0];
	int i = 0;
	while (!file.eof())
	{
		char temp = ' ';
		file >> temp;
		std::cout << temp;
		if (equalIndex == sampleLen)
		{
			return i - equalIndex + 1;
		}
		if (temp == sample[equalIndex])
		{
			equalIndex++;
			i++;
		}
		else if (equalIndex == 0)
		{
			i++;
		}
		else
		{
			equalIndex = index[equalIndex - 1];
		}
	}
	delete[] index;
	return equalIndex;
}