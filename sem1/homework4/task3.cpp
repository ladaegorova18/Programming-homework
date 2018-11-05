#include <stdlib.h>
#include <stdio.h>

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
                    printf("%c", data[linesRead][symbol]);
                    symbol++;
                }
                printf("\n");
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
        char *buffer = new char[30]{};
        fgets(buffer, 30, file);
        data[linesRead] = buffer;
        ++linesRead;
    }
    fclose(file);
    reading(data);
    return 0;
}
