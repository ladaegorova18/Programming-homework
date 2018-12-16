#pragma once
#include <vector>
#include <list>
#include <string>
const int SIZE = 100;

struct Node
{
	std::string data;
	unsigned int count;
	Node(std::string const newData)
	{
		data = newData;
		count = 1;
	}
};

struct Set
{
	std::vector<std::list<Node>> buckets;
	unsigned int elements;
};

// выводит статистические данные о хэш-таблице
void statistics(Set set);

// создает таблицу, присваивая всем head списков значение nullptr
void makeSet(Set& set);

// добавляет элемент
void adding(Set& set, std::string const data);

// проверяет наличие элемента в таблице 
bool exists(Set set, std::string const str);

// выводит хэш-таблицу на экран
void printing(Set set);

// выводит, сколько раз подсчитано искомое слово
int count(Set set, std::string const data);

// вычисляет среднюю длину списка в таблице
int theAverageLength(Set set);

// возвращает максимальную длину списка в таблице
int theMaxLength(Set set);

// вычисляет коэффициент заполненности таблицы
double coefHash(Set set);

// удаляет хэш-таблицу
void deleteSet(Set set);