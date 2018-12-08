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
	void makeList();
	void adding(std::string value);
	bool isEmpty();
	bool find(std::string value); 
	Node* getNode(std::string value);
	void printing(int index);
	void deleteList();
	int getLength();
};