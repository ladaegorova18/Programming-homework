#pragma once
#include <iostream>
#include <string>

struct Node
{
	int count;
	std::string value;
	Node* next;
	Node(std::string newValue)
	{
		count = 1;
		value = newValue;
		next = nullptr;
	}
};

struct List
{
private:
	Node* head;
	Node* tail;
	int length;
public:
	// создает список
	void makeList();
	
	// добавляет элемент в список
	void adding(std::string value);
	
	// проверяет список на пустоту
	bool isEmpty();
	
	// возвращает элемент с искомым значением
	Node* getNode(std::string value);
	
	// печатает список
	void printing(int index);
	
	// удаляет список
	void deleteList();
	
	// возвращает длину списка
	int getLength();
};