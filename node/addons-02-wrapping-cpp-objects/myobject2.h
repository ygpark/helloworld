#ifndef MYOBJECT2_H
#define MYOBJECT2_H

#include <node.h>

class MyObject2 : public node::ObjectWrap {
 public:
  static void Init(v8::Handle<v8::Object> exports);
  static v8::Handle<v8::Value> NewInstance(int argc, v8::Handle<v8::Value> argv[]);

 private:
  explicit MyObject2(double value = 0);
  ~MyObject2();

  static v8::Handle<v8::Value> New(const v8::Arguments& args);
  static v8::Handle<v8::Value> PlusOne(const v8::Arguments& args);
  static v8::Handle<v8::Value> MinusOne(const v8::Arguments& args);

  static v8::Handle<v8::Value> GetString(const v8::Arguments& args);
  static v8::Handle<v8::Value> GetDouble(const v8::Arguments& args);

  static v8::Persistent<v8::Function> constructor;
  double value_;
};

#endif
