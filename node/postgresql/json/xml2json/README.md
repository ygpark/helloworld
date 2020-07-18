# nodejs/02_XmltoJson/

## 필요한 라이브러리 설치
```
npm install xml2json
```

## API에는 어떤것이 있나?
```javascript
parser.toJson(xml, options);
```
```javascript
parser.toXml(json, options);
```

### 옵션엔 뭐가 있는지...
Default values:
```javascript
var options = {
    object: false,
    reversible: false,
    coerce: true,
    sanitize: true,
    trim: true,
    arrayNotation: false
};
```
* **object:** JSON을 string으로 뱉지않고, 자바스크립트 오브젝트로 리턴해줌
* **reversible:** XML로 되돌릴 수 있는 JSON을 만들어 줌.
* **coerce:** 강제로 타입을 만들어줌.
* **trim:** 엘리먼트 값의 줄 끝 뿐만 아니라, 앞과 뒤의 화이트스페이스도 제거해줌.
* **arrayNotation:** XML 자식노드는 항상 arrays로 처리한다.
* **sanitize:** 엘리먼트의 값을 깔끔하게 보이게한다?? 원문:Sanitizes the following characters present in element values:

제작자 테스트 폴더에서 사용하고 있는 예를 들자면...
- spacetext >> trim: false, coerce: false
- coerce >> coerce: false
- domain >> coerce: false
- large >> coerce: false, trim: true, sanitize: false
- array-notation >> arrayNotation: true
- 나머지 >> trim: false 

## 테스트 코드 작성해보자

- hello.js
```javascript
var parser = require('xml2json');  // xml2json 요청

var xml = "<foo>hello nousco</foo>"; // input으로 들어갈 xml작성, 스트링으로 줘도되고 파일로 줘도 된다.
var json = parser.toJson(xml)      // 여기서 주의할 점! tojson 이 아니라 toJson ->> "J"가 대문자여야 한다.

console.log(json); // json으로 나온 결과 확인하기
```

## 어떻게 실행하는지?

- 위에서 작성한 파일명이 hello.js 라면, 실행 방법은 다음과 같다.
```
node hello.js
```


## 참조한 사이트

- 다양한 예제가 들어 있다.
- MIT라이센스, 상용으로 써도 문제는 없다고 카더라.. 단지 이 XML2JSON 사용했다고 써주면 된다 카더라..
```
https://github.com/buglabs/node-xml2json
```
