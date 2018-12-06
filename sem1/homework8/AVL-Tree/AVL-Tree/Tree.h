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
private:
	Node* root;
	int count;

public:
	// обнуляет корень, создавая пустое дерево
	void makeTree();
	// проверяет, пустой корень или нет
	bool isEmpty();
	// добавляет значение в дерево
	Node* adding(std::string newData, const int index, Node* temp);
	// получает значение по ключу
	std::string getData(const int key, Node* temp);
	// проверяет наличие заданного ключа
	Node* findData(const int key, Node* temp);
	// удаляет значение из дерева
	Node* deleteData(const int key, Node* temp);
	// удаляет элемент из корня дерева
	Node* deleteFromRoot();
	// возвращает корень
	Node* getRoot();
	// удаляет дерево
	void deleteTree(Node* temp);
	// возвращает количество элементов в массиве
	int getSize();
};