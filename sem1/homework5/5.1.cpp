#include <locale>
#include <iostream>
#include <list>
#include <iterator>
#include <cstring>

using namespace std;

typedef struct Element
{
    int value;
    Element* next;
    Element* previous;

} Element;

struct dyn_list
{
    size_t size;
    Element *head;
    Element *tail;
    Element *current;
};

void makingList(dyn_list &mylist)
{
    mylist.head = NULL;
}

bool isEmpty(dyn_list mylist)
{
    return (mylist.head == NULL);
}

void addingData(dyn_list &mylist)
{
    cout << "Здесь вы можете добавлять компоненты в список. Для выхода нажмите Q;\n";
    char key = ' ';
    while (key != 'Q')
    {
        cout << "Введите число:\n";
        cin >> key;
        int newValue = (int)key - 48;
        Element* data = new Element();
        data->value = newValue;
        if (isEmpty(mylist))
        {
            mylist.head = data;
            data->next = NULL;
            data->previous = NULL;
            mylist.head = data;
            mylist.tail = data;
            break;
        }
        else
        {
            struct Element *prev, *current;
            current = mylist.head;
            prev = NULL;

            while (current)
            {
                if (data->value <= current->value)
                {
                    prev = current;
                    current = current->next;
                }
                else
                {
                    if (current->previous)
                    {
                        current->previous->next = data;
                        data->next = current;
                        data->previous = current->previous;
                        current->previous = data;
                        break;
                    }
                    data->next = current;
                    data->previous = NULL;
                    current->previous = data;
                    mylist.head = data;
                    break;
                }
            }
            prev->next = data;
            data->next = NULL;
            data->previous = prev;
            mylist.tail = data;
        }
    }
}

void deleteData(dyn_list &mylist)
{

}

void printData(dyn_list mylist)
{
    struct Element *current;
    current = mylist.head;
    while (current)
    {
        cout << current->value << endl;
        current = current->next;
    }

}

int menu(dyn_list &mylist)
{
    cout << "Это главное меню для работы со списком. Нажмите:\n1, чтобы добавить значение в список;\n2, чтобы удалить значение из списка;\n3, чтобы распечатать список;\n0, чтобы выйти." << endl;;
    int key = -1;
    cin >> key;
    if (key == 0)
    {
        return 0;
    }
    switch (key)
    {
    case 1:
        {
            addingData(mylist);
            break;
        }
    case 2:
        {
            deleteData(mylist);
            break;
        }
    case 3:
        {
            printData(mylist);
            break;
        }
    }
    menu(mylist);
}

int main()
{
    setlocale(LC_ALL, "Russian");
    dyn_list mylist;
    makingList(mylist);
    menu(mylist);
    cout << "До свидания!";
    return 0;
}
