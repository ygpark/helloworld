#include <node.h>
#include "myobject2.h"

using namespace v8;

Persistent<Function> MyObject2::constructor;

MyObject2::MyObject2(double value) : value_(value)
{
}

MyObject2::~MyObject2()
{
}

void MyObject2::Init(Handle<Object> exports)
{
    // Prepare constructor template
    Local<FunctionTemplate> tpl = FunctionTemplate::New(New);
    tpl->SetClassName(String::NewSymbol("MyObject2"));
    tpl->InstanceTemplate()->SetInternalFieldCount(1);//항상 1로 고정.

    // Prototype
    tpl->PrototypeTemplate()->Set(String::NewSymbol("plusOne"),
            FunctionTemplate::New(PlusOne)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("minusOne"),
            FunctionTemplate::New(MinusOne)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("getString"),
            FunctionTemplate::New(GetString)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("getDouble"),
            FunctionTemplate::New(GetDouble)->GetFunction());
    constructor = Persistent<Function>::New(tpl->GetFunction());
    exports->Set(String::NewSymbol("MyObject2"), constructor);
}

Handle<Value> MyObject2::New(const Arguments& args)
{
    HandleScope scope;

    if (args.IsConstructCall()) {
        // Invoked as constructor: `new MyObject2(...)`
        double value = args[0]->IsUndefined() ? 0 : args[0]->NumberValue();
        MyObject2* obj = new MyObject2(value);
        obj->Wrap(args.This());
        return args.This();
    } else {
        // Invoked as plain function `MyObject2(...)`, turn into construct call.
        const unsigned argc = 1;
        Local<Value> argv[argc] = { args[0] };
        return scope.Close(constructor->NewInstance(argc, argv));
    }
}

Handle<Value> MyObject2::NewInstance(int argc, Handle<Value> argv[])
{
    HandleScope scope;
    Local<Object> instance = constructor->NewInstance(argc, argv);
    return scope.Close(instance);
}

Handle<Value> MyObject2::PlusOne(const Arguments& args)
{
    HandleScope scope;

    MyObject2* obj = ObjectWrap::Unwrap<MyObject2>(args.This());
    obj->value_ += 1;

    return scope.Close(Number::New(obj->value_));
}

Handle<Value> MyObject2::MinusOne(const Arguments& args)
{
    HandleScope scope;

    MyObject2* obj = ObjectWrap::Unwrap<MyObject2>(args.This());
    obj->value_ -= 1;

    return scope.Close(Number::New(obj->value_));
}

Handle<Value> MyObject2::GetString(const Arguments& args)
{
    HandleScope scope;

    //MyObject2* obj = ObjectWrap::Unwrap<MyObject2>(args.This());

    return scope.Close(String::New("This is MyObject2."));
}

Handle<Value> MyObject2::GetDouble(const Arguments& args)
{
    HandleScope scope;

    //MyObject2* obj = ObjectWrap::Unwrap<MyObject2>(args.This());

    return scope.Close(Number::New((double)3.1415));
}

