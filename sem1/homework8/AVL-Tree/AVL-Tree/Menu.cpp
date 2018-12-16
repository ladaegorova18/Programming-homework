#include "pch.h"
#include "Menu.h"
using namespace std;

void mainText()
{
	cout << "Здравствуйте! Это главное меню. Нажмите:" << endl;
	cout << "1, чтобы добавить значение по заданному ключу в ассоциативный массив;" << endl;
	cout << "2, чтобы получить значение по заданному ключу из ассоциативного массива;" << endl;
	cout << "3, чтобы проверить наличие заданного ключа;" << endl;
	cout << "4, чтобы удалить заданный ключ и связанное с ним значение из ассоциативного массива;" << endl;
	cout << "0, чтобы выйти." << endl;
}

string readString()
{
	string data = " ";
	cin >> data;
	return data;
}

int readKey()
{
	int key = 0;
	cin >> key;
	return key;
}

void mainMenu(Tree* myTree)
{
	mainText();
	char option = ' ';
	cin >> option;
	while (option != '0')
	{
		switch (option)
		{
		case '1':
		{
			cout << "Здесь можно добавить значение в ассоциативный массив. Введите ключ:" << endl;
			int index = readKey();
			cout << "Введите значение:" << endl;
			string data = readString();
			if (adding(data, index, myTree->root))
			{
				cout << "Значение добавлено!" << endl;
			}
			break;
		}
		case '2':
		{
			cout << "Введите ключ, чтобы получить искомое значение:" << endl;
			int key = readKey();
			cout << "Искомое значение: " << getData(key, myTree->root) << endl;
			break;
		}
		case '3':
		{
			cout << "Введите ключ, чтобы проверить его наличие:" << endl;
			int key = readKey();
			if (isEmpty(myTree))
			{
				cout << "Массив пуст:(" << endl;
			}
			else if (findData(key, myTree->root) != nullptr)
			{
				cout << "Ключ есть в массиве:)" << endl;
			}
			else
			{
				cout << "Ключа нет в массиве:(" << endl;
			}
			break;
		}
		case '4':
		{
			cout << "Введите ключ, чтобы удалить его и связанное с ним значение:" << endl;
			int key = readKey();
			if (isEmpty(myTree))
			{
				break;
			}
			if (findData(key, myTree->root) != nullptr)
			{
				deleteData(key, myTree->root, myTree->root);
				cout << "Значение удалено!" << endl;
			}
			break;
		}
		}
		mainText();
		cin >> option;
	}
	cout << "До свидания!" << endl;
}
