#include "pch.h"
#include <fstream>
#include <locale>
#include <iostream>
#include "MathTree.h"
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	FILE *file = fopen("math.txt", "a+");
	Tree *myTree = new Tree();
	if (!file)
	{
		cout << "Файл не найден!" << endl;
	}
	else
	{
		while (!feof(file))
		{
			char symbol = getc(file);
			if (symbol != '(')
			{
				ungetc(symbol, file);
			}

		}
	}
	fclose(file);

	return 0;
}