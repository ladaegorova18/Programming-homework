#pragma once
#include <vector>
#include <list>
#include <string>
const int SIZE = 100;

struct Set;

// выводит статистические данные о хэш-таблице
void statistics(Set *&set);

// создает таблицу, присваивая всем head списков значение nullptr
Set* makeSet();

// добавляет элемент
void adding(Set*& set, std::string const &data);

// выводит хэш-таблицу на экран
void printing(Set *&set);

// выводит, сколько раз подсчитано искомое слово
int count(Set *&set, std::string const &data);

// вычисляет коэффициент заполненности таблицы
double coefHash(Set *&set);

// удаляет хэш-таблицу
void deleteSet(Set *&set);