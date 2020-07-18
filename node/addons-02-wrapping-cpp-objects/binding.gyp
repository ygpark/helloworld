{
    "targets": [{
        "target_name": "addon",
        "sources": [ "addon.cc", "myobject.cc" , "myobject2.cc" ],
        'conditions': [
            ['OS=="linux"', {
                'cflags': [
                    '<!@(pkg-config --cflags QtCore QtGui QtTest)'
                ],
                'ldflags': [
                    '<!@(pkg-config --libs-only-L --libs-only-other QtCore QtGui QtTest)'
                ],
                'libraries': [
                    '<!@(pkg-config --libs-only-l QtCore QtGui QtTest)'
                ]
            }]
        ]
    }]
}
