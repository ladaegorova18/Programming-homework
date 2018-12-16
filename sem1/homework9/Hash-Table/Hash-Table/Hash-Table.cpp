#include "pch.h"
#include <iostream>
#include "Hash-Table.h"
#include <algorithm>
#include <iterator>

void makeSet(Set& set)
{
	int size = SIZE;
	set.buckets.resize(size);
	set.elements = 0;
}

int hashFunction(std::string const &str)
{
	int sum = 0;
	int length = str.size();
	for (int i = 0; i < length; ++i)
	{
		sum += sum * 5 + str[i];
	}
	return sum;
}

void adding(Set& set, std::string const data)
{
	set.elements++;
	int hash = hashFunction(data) % set.buckets.size();
	if (hash < 0)
	{
		hash *= -1;
	}
	if (!exists(set, data))
	{
		Node temp(data);
		set.buckets[hash].push_back(temp);
	}
	else
	{
		for (auto it = set.buckets[hash].begin(); it != set.buckets[hash].end(); ++it)
		{
			if (data == it->data)
			{
				it->count++;
			}
		}
	}
}

bool exists(Set set, std::string const data)
{
	int hash = hashFunction(data) % set.buckets.size();
	for (auto it = set.buckets[hash].begin(); it != set.buckets[hash].end(); ++it)
	{
		if (data == it->data)
		{
			return true;
		}
	}
	return false;
}

int count(Set set, std::string const data)
{
	if (exists(set, data))
	{
		int hash = hashFunction(data) % set.buckets.size();
		for (auto it = set.buckets[hash].begin(); it != set.buckets[hash].end(); ++it)
		{
			if (data == it->data)
			{
				return it->count;
			}
		}
	}
	return 0;
}

void printing(Set set)
{
	for (int i = 0; i < SIZE; i++)
	{
		if (!set.buckets[i].empty())
		{
			for (auto it = set.buckets[i].begin(); it != set.buckets[i].end(); ++it)
			{
				std::cout << it->data << "\t";
				std::cout << it->count << std::endl;
			}
		}
	}
}

void deleteSet(Set set)
{
	for (int i = 0; i < SIZE; i++)
	{
		set.buckets[i].clear();
	}
}

int theAverageLength(Set set)
{
	unsigned int arifMean = 0;
	unsigned int count = 0;
	for (int i = 0; i < SIZE; i++)
	{
		if (!set.buckets[i].empty())
		{
			arifMean += set.buckets[i].size();
			count++;
		}
	}
	if (count != 0)
	{
		return arifMean /= count;
	}
	return 0;
}

int theMaxLength(Set set)
{
	unsigned int max = 0;
	for (int i = 0; i < SIZE; i++)
	{
		if (max < set.buckets[i].size())
		{
			max = set.buckets[i].size();
		}
	}
	return max;
}

double coefHash(Set set)
{
	return set.elements / (double) set.buckets.size();
}

void statistics(Set set)
{
	std::cout << "Средняя длина списка таблицы: " << theAverageLength(set) << std::endl;
	std::cout << "Максимальная длина списка таблицы: " << theMaxLength(set) << std::endl;
	std::cout << "Коэффициент заполнения таблицы: " << coefHash(set) << std::endl;
}