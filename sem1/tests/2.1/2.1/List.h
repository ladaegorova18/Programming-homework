#pragma once
#include <iostream>
#include <string>

struct Node
{
	int value;
	Node* next;
	Node(int newValue)
	{
		value = newValue;
		next = nullptr;
	}
};

Node* increaseList(Node* list);

// создает список
void makeList(Node*& head);

// добавляет элемент в список
void adding(Node*& head, int value);

// проверяет список на пустоту
bool isEmpty(Node* head);

// печатает список
void printing(Node* head);

// удаляет список
void deleteList(Node*& head);