#include "array.h"
#include <algorithm>

int GetSize(int* a) 
{
    return sizeof(a)/sizeof(int);
}

int SumOfArray(int a[]) 
{
    int sum = 0;
    int size = GetSize(a);
    for (int i = 0; i < size; i++) 
    {
        sum += a[i];
    }
    return sum;
}

int MinInArray(int a[])
{
    int size = GetSize(a);
    if (size == 0) {
        return 0;
    }
    int minimum = a[0];
    
    for (int i = 1; i < size; i++) 
    {
        minimum = std::min(a[i], minimum);
    }
    return minimum; 
}

int MaxInArray(int a[])
{
    int size = GetSize(a);
    
    if (size == 0) {
        return 0;
    }
    int maximum = a[0];
    
    for (int i = 1; i < size; i++) 
    {
        maximum = std::max(a[i], maximum);
    }
    return maximum;
}

double Average(int a[])
{
    int size = GetSize(a);
    
    if (size == 0) {
        return 0;
    }
    int sum = SumOfArray(a);
    
    return 1.0 * sum / size;
}

int* Reverse(int a[])
{
    int size = GetSize(a);
    int* new_a = new int[size];
    
    for (int i = 0; i < size; i++) {
        new_a[i] = a[size - i];
    }

    return new_a;
}

int* Sort(int a[])
{
    int size = GetSize(a);
    int* new_a = new int[size];

    for (int i = 0; i < size; i++)
    {
        new_a[i] = a[i];
    }
    std::sort(new_a, new_a + size);
    return new_a;
}