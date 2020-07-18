## git add

### 기본 사용법

```bash
git add <filename>
```

### 선택적으로 add하기

`git add -e <파일명>`를 실행하면 diff가 편집기에 나타난다.
이 중 add할 부분만 남기고 나머지는 지우고 저장한다.

`git diff --cached`명령으로 확인한 뒤 `commit`한다.

취소하려면 `git reset`을 실행한다.

```bash
git add -e <파일명>
git diff --cached
```

