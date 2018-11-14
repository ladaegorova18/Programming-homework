#include <iostream>
using namespace std;

int insertion(dynList *mylist, int newValue)
{
    Element* data = new Element;
    Element* previous = nullptr;
    data->value = newValue;
    if (isEmpty(mylist))
    {
        mylist->head = data;
        data->next = nullptr;
        return 0;
    }
    else
    {
        Element* current = mylist->head;
        while (current != nullptr)
        {
            if (current->value >= newValue)
            {
                data->next = current;
                if (previous != nullptr)
                {
                    previous->next = data;
                }
                else
                {
                    mylist->head = data;
                }
                return 0;
            }
        previous = current;
        current = current->next;
        }
    previous->next = data;
    }
}

int addingData(dynList *mylist)
{
    cout << "Здесь вы можете добавлять компоненты в список. Для выхода нажмите Q;\n";
    char key = ' ';
    cin >> key;
    while (key != 'Q')
    {
        cout << "Введите число:" << endl;
        int newValue = (int)key - 48;
        insertion(mylist, newValue);
        cin >> key;
    }
}

void deleteData(dynList *mylist)
{
    cout << "Здесь можно удалять определеннные значения из списка. Введите значение или нажмите Q, чтобы выйти:" << endl;
    char key = ' ';
    cin >> key;
    if (key != 'Q')
    {
        int order = (int)key - 48;
        Element* current = mylist->head; // проходим по всем элементам и сравниваем каждый с нашим "заказом"
        Element* previous = nullptr;
        while (current != nullptr)
        {
            if (current->value == order) // если совпали, то смотрим на предыдущий
            {
                if (previous == nullptr) // если его нет, то мы находимся в начале списка и нужно заменить head на следующий
                {
                    mylist->head = mylist->head->next;
                }
                else
                {
                    previous->next = current->next; // если он есть, то делаем следующим за ним не текущий, а следующий за текущим
                }
            }
            previous = current;
            current = current->next;
        }
    }
    cout << "Значение удалено!";
}

void printData(dynList *mylist)
{
    if (mylist->head == nullptr)
    {
        cout << "Список пуст:(" << endl;
    }
    else
    {
        cout << "Сейчас список выглядит так:" << endl;
        struct Element *current;
        current = mylist->head;
        while (current)
        {
            cout << current->value << endl;
            cout << endl;
            current = current->next;
        }
    }
}
