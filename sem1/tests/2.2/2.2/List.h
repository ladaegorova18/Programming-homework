#pragma once
#include <iostream>
#include <string>

struct Node;

bool add(Node *&head, int value, int pos);

bool deleting(Node *&head, int pos);

Node* makeList();

void deleteList(Node *&head);

void print(Node *head);

bool isEmpty(Node *&head);

int getValue(Node *&temp);

Node* getNext(Node *&temp);