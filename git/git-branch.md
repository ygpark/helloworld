## 브랜치

### Remote 브랜치 삭제하기

Remote 브랜치를 삭제하기 위해선 `git push <remotename> <local branch>:<remote branch>`명령을 사용한다.
왼쪽 `<local branch>`를 비워두면 빈 내용을 원격 브랜치에 채워넣으므로 삭제한다는 뜻이 된다.

```bash
git push origin :feautre
```






## Tracking 브랜치

### push와 동시에 Tracking 브랜치 만들기

`git push -u <remoteName> <branchName>` 명령을 사용한다.

```bash
git push -u origin master
```



### 새 Tracking 브랜치 만들기

`git branch --track <branchName> <remoteName/branchName>` 명령을 사용한다.

```bash
git branch --track master origin/master
```



### 새 브랜치 만들기 (Tracking되지 않는)

`git branch --no-track <branchName>` 명령을 사용한다.

```bash
git branch --no-track master origin/master
```
	


### 기존 브랜치를 Tracking 브랜치로 설정하기

`git branch --set-upstream <branchName> <remoteName/branchName>` 명령을 사용한다.

```bash
git branch --set-upstream master origin/master
```



### Tracking 해제하기

명령어로 할 때는 이렇게 하고..


```bash
git config --unset branch.<branchName>.merge 
git config --unset branch.<branchName>.remote
```


config파일을 직접 수정할 때엔 `.git/config` 파일을 편집해서 `[branch "branchName"]`항목을 삭제한다.

```config
[branch "new1"]
	remote = origin
	merge = refs/heads/master
```


### Tracking 브랜치 확인하기

```bash
git branch -vv
```



