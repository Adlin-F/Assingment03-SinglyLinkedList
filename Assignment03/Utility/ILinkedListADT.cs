﻿using System;

namespace Assignment03
{
    public interface ILinkedListADT
    {
        bool IsEmpty();
        void Clear();
        void AddLast(User value);
        void AddFirst(User value);
        void Add(User value, int index);
        void Replace(User value, int index);
        int Count();
        void RemoveFirst();
        void RemoveLast();
        void Remove(int index);
        User GetValue(int index);
        int IndexOf(User value);
        bool Contains(User value);
    }
}
