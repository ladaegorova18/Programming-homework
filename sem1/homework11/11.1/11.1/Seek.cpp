#include "pch.h"
#include "Seek.h"

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

int algorithmKMP(std::string main, std::string sample)
{
	int sampleLen = sample.length();
	int mainLen = main.length();
	int equalIndex = 0;
	int *index = prefixFunction(sample, sampleLen);
	for (int i = 0; i < mainLen; )
	{
		if (equalIndex == sampleLen)
		{
			return i - equalIndex + 1;
		}
		if (main[i] == sample[equalIndex])
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