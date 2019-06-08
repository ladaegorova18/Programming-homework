#pragma once
#include <iostream>
#include <string>

struct Node;

struct List;

List* merge(List *&firstList, List *&secondList);

Node* getHead(List *&list);

List* makingList();

int getValue(Node* list);

Node* nextNode(Node *list);

void addingData(List *&list, int newValue);

void deleteList(List *&head);
