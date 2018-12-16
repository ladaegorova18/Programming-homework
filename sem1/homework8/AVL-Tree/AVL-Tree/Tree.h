#pragma once
#include <iostream>
#include <string>

struct Node
{
	Node* leftChild;
	Node* rightChild;
	std::string data;
	int key;
	int height;
	Node(int index, std::string newData) { 
		key = index; 
		data = newData;
		leftChild = nullptr; 
		rightChild = nullptr; 
		height = 1; 
	}
};

struct Tree
{
	Node* root;
};

// проверяет, пустой корень или нет
bool isEmpty(Tree *tree);

// добавляет значение в дерево
Node* adding(std::string newData, const int index, Node *&temp);

// обнуляет корень, создавая пустое дерево
void makeTree(Tree *&tree);

// удаляет дерево
void deleteTree(Node*& temp);

// получает значение по ключу
std::string getData(const int key, Node* temp);

// проверяет наличие заданного ключа
Node* findData(const int key, Node* temp);

// удаляет значение из дерева
Node* deleteData(const int key, Node*& temp, Node *&root);