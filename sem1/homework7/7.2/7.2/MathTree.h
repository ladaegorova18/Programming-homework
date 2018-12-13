#pragma once

struct Element
{
	char operand;
	Element* leftChild;
	Element* rightChild;
	Element* parent;
	int value;
};

struct Tree
{
private:
	Element* root;
public:
	// вычисляет результат арифметического выражения
	int count(Element* current);

	// создает корень дерева и делает детей nullptr'ами
	void makeTree();

	// добавляет символ из выражения на свое место в дереве
	Element* adding(const char symbol, Element *current);

	// возвращает, равен ли корень nullptr
	bool isEmpty();

	// возвращает корень дерева
	Element* getRoot();

	// печатает дерево в явном виде
	void printing(Element* current, const int level);

	// удаляет дерево
	void deleteTree(Element* current);
};