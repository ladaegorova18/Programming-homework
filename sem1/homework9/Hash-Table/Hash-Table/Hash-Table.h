#pragma once
#include "List.h"
#include <vector>
#include <list>
#include <string>

struct Set
{
private:
	std::vector<List> buckets;
	int elements;

public:
	// создает таблицу, присваивая всем head списков значение nullptr
	void makeSet();

	// добавляет элемент
	void adding(std::string data);

	// проверяет наличие элемента в таблице 
	bool exists(std::string const &str);

	// выводит хэш-таблицу на экран
	void printing();

	// возвращает максимальную длину списка в таблице
	int theMaxLength();

	// вычисляет среднюю длину списка в таблице
	int theAverageLength();
	
	// вычисляет коэффициент заполненности таблицы
	double coefHash();

	// удаляет хэш-таблицу
	void deleteSet();
};

// выводит статистические данные о хэш-таблице
void statistics(Set* set);