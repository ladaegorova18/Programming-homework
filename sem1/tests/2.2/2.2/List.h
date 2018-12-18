#pragma once

struct Node
{
	int value;
	Node* next;
	Node* prev;
	Node(int newValue)
	{
		value = newValue;
		next = nullptr;
		prev = nullptr;
	}
};

void add(Node *&head, int value, int position);

void makeList(Node *&head);

void deleteList(Node *&head);

void print(Node *head);

void deleteFromPos(Node *&head, int position);