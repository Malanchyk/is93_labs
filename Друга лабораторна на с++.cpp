#include <iostream>
#include <cstring>
#include <cctype>

using namespace std;

class AString { 
private:
  char *value;

public:
  AString() {
    value = nullptr;
  }

  AString(const char *s) {
    value = new char[strlen(s) + 1];
    strcpy(value, s);
  }

  AString(const AString& c) {
    value = new char[strlen(c.value) + 1];
    strcpy(value, c.value);
  }

  ~AString() {
    if (value) delete value;
  }

  AString& operator =(const AString& c) {
    if (value) delete value;
    value = new char[strlen(c.value) + 1];
    strcpy(value, c.value);
    return *this;
  }

  bool operator==(const AString& c) const {
    if (!value || !c.value) return !value && !c.value;
    return !strcmp(value, c.value);
  }

  AString& operator+=(char c) {
    char *oldValue = value;
    int len = oldValue ? strlen(oldValue) : 0;

    value = new char[len + 2];

    if (oldValue) strcpy(value, oldValue);

    value[len] = c;
    value[len + 1] = '\0';

    if (oldValue) delete oldValue;

    return *this;
  }

  AString& operator+=(const AString& c) {
    char *oldValue = value;
    int len = oldValue ? strlen(oldValue) : 0;

    value = new char[len + c.Length() + 1];

    if (oldValue) strcpy(value, oldValue);

    if (c.value) {
      strcat(value, c.value);
    }

    if (oldValue) delete oldValue;

    return *this;
  }

  int Length() const {
    return value ? strlen(value) : 0;
  }

  AString Digits() const {
    if (!value) return "";

    AString ret = "";

    for (int i = 0; value[i] != '\0'; i++) {
      if (isdigit(value[i])) {
        ret += value[i];
      }
    }

    return ret;
  }

  friend ostream& operator<<(ostream& s, const AString& c) {
    return s << "AString(value=" << c.value << ")";
  }
};

class AText {
private:
  AString *arr;
  int capacity;
  int size;

public:
  AText(int cap) {
    arr = new AString[cap];
    capacity = cap;
    size = 0;
  }

  AText(const AText& c) {
    arr = new AString[c.capacity];
    capacity = c.capacity;
    size = c.size;
    for (int i = 0; i < c.size; i++) {
      arr[i] = c.arr[i];
    }
  }

  void Add(const AString& s) {
    if (size == capacity) {
      cout << "text container is full" << endl;
      return;
    }
    arr[size++] = s;
  }

  void Remove(const AString& s) {
    int i;
    for (i = 0; i < size; i++) {
      if (arr[i] == s) break;
    }

    if (i == size) return;

    for (int j = i; j < size - 1; j++) {
      arr[j] = arr[j + 1];
    }

    size--;
  }

  void Clear() {
    size = 0;
  }

  int StringCount() const {
    return size;
  }

  int Length() const {
    int ret = 0;
    for (int i = 0; i < size; i++) {
      ret += arr[i].Length();
    }
    return ret;
  }

  AString MaxStringByLength() const {
    if (size == 0) {
      cout << "text container is empty" << endl;
      return "";
    }
    int k = 0;
    for (int i = 1; i < size; i++) {
      if (arr[i].Length() > arr[k].Length()) {
        k = i;
      }
    }
    return arr[k];
  }

  float PercentageOfDigits() const {
    int nDigits = 0;
    for (int i = 0; i < size; i++) {
      nDigits += arr[i].Digits().Length();
    }
    return (float) nDigits / Length();
  }

  friend ostream& operator<<(ostream& s, const AText& c) {
    s << "AText(" << endl;
    for (int i = 0; i < c.size; i++) {
      s << "  " << c.arr[i] << endl;
    }
    s << ")";
    return s;
  }
};

int main() {
  cout << "hello world" << endl;

  AText text(10);

  cout << endl;
  cout << "Empty:" << endl << text << endl;

  cout << endl;
  text.Add("I'm the programmer 1 away, 2 behind the 3 word mountains");
  cout << ".Add() x1:" << endl << text << endl;

  cout << endl;
  text.Add("Far from 4 the countries 5 Vokalia and Consonantia");
  text.Add("There live 6 the blind texts");
  text.Add("Separated they 7 live in 8 Bookmarksgrove");
  text.Add("Right at 9 the coast of the Semantics, a 0 large language ocean");
  
  cout << ".Add() x4:" << endl << text << endl;

  cout << endl;
  cout << ".MaxStringByLength():" << endl << text.MaxStringByLength() << endl;

  cout << endl;
  cout << ".Length(): " << text.Length() << endl;

  cout << endl;
  cout << ".PercentageOfDigits() * 100: " << (text.PercentageOfDigits() * 100) << "%" << endl;

  cout << endl;
  cout << ".StringCount(): " << text.StringCount() << endl;

  cout << endl;
  text.Remove("There live 6 the blind texts");
  cout << ".Remove():" << endl << text << endl;

  cout << endl;
  cout << ".StringCount(): " << text.StringCount() << endl;

  cout << endl;
  text.Clear();
  cout << ".Clear():" << endl << text << endl;

  return 0;
}
