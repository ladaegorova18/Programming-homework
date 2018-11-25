#pragma once

struct Element
{
	int value;
	Element* leftChild;
	Element* rightChild;
};

struct Set
{
	Element *root;
	// adding elements
	void addingData(int data);
	// deleting an element
	Element* deleteData(Element *current, int data);
	// checking if element exists in the set
	bool checkData(int data, Element *current);
	// printing elements in increasing order
	void printRise(Element *current);
	// printing in decreasing order
	void printFalling(Element *current);
	//finds a minimal element in the tree with 'current' root
	Element* minimum(Element *current);
	// deleting a root and making a new root
	void rootRemoving();
	bool isEmpty();
};