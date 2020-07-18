# 기본 컨셉
- 에러와 비지니스 로직을 구분한다.
- 리턴 타입을 사용하지 않고 에러를 처리한다.
- 여러 함수를 거쳐 예외를 전달한다. (스택 풀기)
- 예외를 잡았으면 뭔가 해야한다.
- 잡은 후의 유형
	- 처리하고 종료
	- 다시 던진다
	- 새 예외로 던진다.
	- 무시한다.

# 주의사항
- 템플릿에서 사용하지 말자
- 예외지정자를 사용할 때엔 주의


# EHR코드에서는
- 문자열만 전달한다.
- 그리고 Exception을 전달받은 다음 bool 타입을 리턴한다.


# 제안 및 토론

- 참조자(&)를 사용하자 (복사가 되지 않도록)
- 리턴타입을 void로 사용하자
- Exception을 catch하는 범위를 구분하자. (Framework계층과 개발자 계층(GUI)을 구분)
- Exception을 상속받아서 적절한 이름을 지어주자. (예: NullPointerException, DevidedByZeroException)
- Exception을 추적하자.
  - class 이름까지 추적할 필요가 있는가?
    그렇게 하려면 모든 class를 QObject로부터 상속받아야 한다.
    또는 Macro를 사용해서 일일이 적어넣어야 한다.
- 모든 메소드의 헤더에 throw()를 붙여야 하나?
  - (예외가 발생하지 않는 함수도 확인할 수 있다.)
- 모든 예외를 처리했지만 그래도 잡지 못하는 예외는 catch(...)으로 처리
	- (토의) 예외지정에서는 상속이 통하지 않는다.
- 모든 호출자에서 Exception을 처리해야 하는가?



# 토론 결과
- 예외 지정자를 쓰지말자는 의견
- 예외를 구분하는 방법으로 상속과 virtual함수를 사용하자는 의견
  - (자식 클래스으로 throw하고 부모 클래스로 catch한 후 virtual 함수를 호출해서 부모인지 자식인지 구분하자)
- 기존 코드에서 __LINE__, __FILE__만 추가하자는 의견

