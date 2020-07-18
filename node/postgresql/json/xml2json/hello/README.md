# nodejs/02_XmltoJson/hello

## 필요한 라이브러리 설치

    npm install xml2json

## 테스트 코드 작성

- hello.js

    var parser = require('xml2json');  // xml2json 요청

    var xml = "<foo>hello nousco</foo>"; // input으로 들어갈 xml작성, 스트링으로 줘도되고 파일로 줘도 된다.
    var json = parser.toJson(xml)      // 여기서 주의할 점! tojson 이 아니라 toJson ->> "J"가 대문자여야 한다.

    console.log(json); // json으로 나온 결과 확인하기


## 어떻게 실행하는지?

- 위에서 작성한 파일명이 hello.js 라면, 실행 방법은 다음과 같다.
    node hello.js


## 참조한 사이트

- 다양한 예제가 들어 있다.
- MIT라이센스, 상용으로 써도 문제는 없다고 카더라.. 단지 이 XML2JSON 사용했다고 써주면 된다 카더라..
    https://github.com/buglabs/node-xml2json
