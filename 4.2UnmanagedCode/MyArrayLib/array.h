#pragma once

extern "C" {
    __declspec(dllexport) int _stdcall SumOfArray(int a[]);
    __declspec(dllexport) int _stdcall MinInArray(int a[]);
    __declspec(dllexport) int _stdcall MaxInArray(int a[]);
    __declspec(dllexport) double _stdcall Average(int a[]);
    __declspec(dllexport) int* _stdcall Reverse(int a[]);
    __declspec(dllexport) int* _stdcall Sort(int a[]);
}