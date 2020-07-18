#include <node.h>
#include "myobject.h"
#include "myobject2.h"

using namespace v8;

Persistent<Function> MyObject::constructor;

MyObject::MyObject(double value) : value_(value) {
}

MyObject::~MyObject() {
}

void MyObject::Init(Handle<Object> exports) {
    // Prepare constructor template
    Local<FunctionTemplate> tpl = FunctionTemplate::New(New);
    tpl->SetClassName(String::NewSymbol("MyObject"));
    tpl->InstanceTemplate()->SetInternalFieldCount(1);//항상 1로 고정. constructor function은 오직 1개의 레퍼런스만 가지기 때문.
    // Prototype
    tpl->PrototypeTemplate()->Set(String::NewSymbol("plusOne"),
            FunctionTemplate::New(PlusOne)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("minusOne"),
            FunctionTemplate::New(MinusOne)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("getString"),
            FunctionTemplate::New(GetString)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("getDouble"),
            FunctionTemplate::New(GetDouble)->GetFunction());
    tpl->PrototypeTemplate()->Set(String::NewSymbol("getMyObject2"),
            FunctionTemplate::New(GetMyObject2)->GetFunction());
    constructor = Persistent<Function>::New(tpl->GetFunction());
    exports->Set(String::NewSymbol("MyObject"), constructor);
}

Handle<Value> MyObject::New(const Arguments& args) {
    HandleScope scope;

    if (args.IsConstructCall()) {
        // Invoked as constructor: `new MyObject2(...)`
        double value = args[0]->IsUndefined() ? 0 : args[0]->NumberValue();
        MyObject* obj = new MyObject(value);
        obj->Wrap(args.This());
        return args.This();
    } else {
        // Invoked as plain function `MyObject2(...)`, turn into construct call.
        const unsigned argc = 1;
        Local<Value> argv[argc] = { args[0] };
        return scope.Close(constructor->NewInstance(argc, argv));
    }
}

Handle<Value> MyObject::PlusOne(const Arguments& args) {
    HandleScope scope;

    MyObject* obj = ObjectWrap::Unwrap<MyObject>(args.This());
    obj->value_ += 1;

    return scope.Close(Number::New(obj->value_));
}

Handle<Value> MyObject::MinusOne(const Arguments& args) {
    HandleScope scope;

    MyObject* obj = ObjectWrap::Unwrap<MyObject>(args.This());
    obj->value_ -= 1;

    return scope.Close(Number::New(obj->value_));
}

Handle<Value> MyObject::GetString(const Arguments& args) {
    HandleScope scope;

    //MyObject* obj = ObjectWrap::Unwrap<MyObject>(args.This());

    return scope.Close(String::New("Hello. 안녕하세요."));
}

Handle<Value> MyObject::GetDouble(const Arguments& args) {
    HandleScope scope;

    //MyObject* obj = ObjectWrap::Unwrap<MyObject>(args.This());

    return scope.Close(Number::New((double)3.1415));
}

Handle<Value> MyObject::GetMyObject2(const Arguments& args) {
    HandleScope scope;

    const unsigned int argc = 1;
    Handle<Value> argv[argc] = {Undefined()};

    printArguments(args, 0);

    return scope.Close(MyObject2::NewInstance(argc, argv));
}

/**
 * @brief Arguments의 i번째 인자의 속성을 검사한다.
 *
 * @param args Javascript로부터 전달받은 인자
 * @param i index
 */
void MyObject::printArguments(const Arguments& args, int i)
{
    printf("[DEBUG] arg[%d] ", i);
    if(args[i]->IsArray()) {
        printf("is Array\n");
    }
    if(args[i]->IsBoolean()) {
        printf("is Boolean()\n");
    }
    if(args[i]->IsBooleanObject()) {
        printf("is BooleanObject()\n");
    }
    if(args[i]->IsDate()) {
        printf("is Date()\n");
    }
    if(args[i]->IsExternal()) {
        printf("is External()\n");
    }
    if(args[i]->IsFalse()) {
        printf("is False()\n");
    }
    if(args[i]->IsFunction()) {
        printf("is Function()\n");
    }
    if(args[i]->IsInt32()) {
        printf("is Int32()\n");
    }
    if(args[i]->IsNativeError()) {
        printf("is NativeError()\n");
    }
    if(args[i]->IsNull()) {
        printf("is Null()\n");
    }
    if(args[i]->IsNumber()) {
        printf("is Number()\n");
    }
    if(args[i]->IsNumberObject()) {
        printf("is NumberObject()\n");
    }
    if(args[i]->IsObject()) {
        printf("is Object()\n");
    }
    if(args[i]->IsRegExp()) {
        printf("is RegExp()\n");
    }
    if(args[i]->IsString()) {
        printf("is String()\n");
    }
    if(args[i]->IsStringObject()) {
        printf("is StringObject()\n");
    }
    if(args[i]->IsTrue()) {
        printf("is True()\n");
    }
    if(args[i]->IsUint32()) {
        printf("is Uint32()\n");
    }
    if(args[i]->IsUndefined()) {
        printf("is Undefined()\n");
    }
}
















