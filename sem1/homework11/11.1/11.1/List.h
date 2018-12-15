#pragma once

struct Node
{
	int value;
	Node* next;
};

void add(Node *&head, int value);

void print(Node *head);

void reverse(Node *&head);

void deleteList(Node *&head);