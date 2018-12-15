#ifndef HEADER_H
#define HEADER_H
#include <iostream>

struct List
{
	std::string name;
	int phoneNumber;
	List* next;
};

// создает список, обнул€€ первый элемент
void makingList(List *&myList);

// добавл€ет элементы в список
void addingData(List *&myList, std::string tempName, int tempPhoneNumber);

//печатает список
void printData(List *head);

// сортировка сли€нием(основна€ функци€)
void mergeSort(List *&myList, char key);

// удал€ет список
void deleteList(List *&myList);

#endif // HEADER_H
