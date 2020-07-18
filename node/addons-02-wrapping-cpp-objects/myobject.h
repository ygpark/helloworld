#ifndef MYOBJECT_H
#define MYOBJECT_H

#include <node.h>

class MyObject : public node::ObjectWrap {
 public:
  static void Init(v8::Handle<v8::Object> exports);

 private:
  explicit MyObject(double value = 0);
  ~MyObject();

  static void printArguments(const v8::Arguments& args, int i);
  static v8::Handle<v8::Value> New(const v8::Arguments& args);

  static v8::Handle<v8::Value> PlusOne(const v8::Arguments& args);
  static v8::Handle<v8::Value> MinusOne(const v8::Arguments& args);

  static v8::Handle<v8::Value> GetString(const v8::Arguments& args);
  static v8::Handle<v8::Value> GetDouble(const v8::Arguments& args);
  static v8::Handle<v8::Value> GetMyObject2(const v8::Arguments& args);

  static v8::Persistent<v8::Function> constructor;
  double value_;
};

#endif
