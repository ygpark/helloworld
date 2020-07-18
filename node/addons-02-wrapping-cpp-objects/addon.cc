#include <node.h>
#include "myobject.h"
#include "myobject2.h"

using namespace v8;

void InitAll(Handle<Object> exports) {
  MyObject::Init(exports);
  MyObject2::Init(exports);
}

NODE_MODULE(addon, InitAll)
