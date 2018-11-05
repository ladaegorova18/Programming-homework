#include <stdlib.h>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <string>
using namespace std;

void reading(char* data[100])
{
    for (int linesRead = 0; linesRead < 100; linesRead++)
    {
        for (int symbol = 0; symbol < 30; symbol++)
        {
            if (data[linesRead][symbol] == ';')
            {
                while (symbol < 30)
                {
                    if (data[linesRead][symbol] != ' ')
                    {
                        printf("%c", data[linesRead][symbol]);
                    }
                    symbol++;
                }
                break;
            }
        }
    }
}

int main()
{
    FILE *file = fopen("test.txt", "r");
    if (!file)
    {
        printf("file not found!");
        return 1;
    }
    char *data[100] = { };
    int linesRead = 0;
    while (!feof(file))
    {
        char *buffer = new char[100]{};
        fgets(buffer, 30, file);
        data[linesRead] = buffer;
        ++linesRead;
    }
    fclose(file);
    reading(data);
    return 0;
}
