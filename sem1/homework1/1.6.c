#include <stdio.h>
#include <string.h>
#include <assert.h>

int count(const char s[100], const char s1[100])
{
    int count = 0;
    for (int i = 0; i < strlen(s) - strlen(s1) + 1; i++)
    {
        if (s[i] == s1[0])
        {
            int pos1 = 1;
            int pos = i + 1;
            while (pos1 < strlen(s1))
            {
                if (s[pos] == s1[pos1])
                {
                    pos++;
                    pos1++;
                }
            }
            if (pos1 == strlen(s1))
            {
                    count++;
                    pos1 = 1;
            }
        }
    }
    return count;
}

int main()
{
    test();
    char s[100];
    printf("Enter the first string:\n");
    scanf("%s", s);
    char s1[100];
    printf("Enter the second string:\n");
    scanf("%s", s1);
    count(s, s1);
    printf("%d\n", count);
    return 0;
}

void test()
{
    printf("Function test:\n");
    assert(count("aaaaa", "aa") == 4);
    assert(count("abcbcbc", "ab") == 1);
    assert(count("jsifjj34rss", "s") == 3);
}
