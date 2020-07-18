# 버전관리되지 않은 디렉토리를 저장소에 한번에 넣기

	svn import http://localhost/svn/projectName


# 저장소 내려받기

	svn checkout http://localhost/svn/projectName
	https://192.168.100.254:8088/svn/Ehr

# 파일 수정하기
	#수정한다....
	vi main.c

# commit
	svn commit main.c
	svn ci main.c

# diff

## 사용법
	----------------------------------------------------------------------------
	사용법: 1. diff [-c M | -r N[:M]] [TARGET[@REV]...]
	        2. diff [-r N[:M]] --old=OLD-TGT[@OLDREV] [--new=NEW-TGT[@NEWREV]] \
	                [PATH...]
	        3. diff OLD-URL[@OLDREV] NEW-URL[@NEWREV]
	----------------------------------------------------------------------------


## 예제 1
	svn diff -r 1:2       b.txt
	svn diff -r 1:HEAD    b.txt
	svn diff -r PREV:HEAD b.txt

## 예제 2. diff tool 사용
	svn diff -r PREV:HEAD --diff-cmd meld a.txt

# log

	Examples:
		svn log
		svn log foo.c
		svn log http://www.example.com/repo/project/foo.c
		svn log http://www.example.com/repo/project foo.c bar.c


	svn log

	#모든 변경사항 출력
	svn log -r 1:HEAD

	#바뀐 파일 목록 출력
	svn log -r 1:HEAD -v 

	svn log -r PREV:HEAD b.txt

# branch 만들기
	svn copy trunk branches/test-branch
	svn commit


# tag 만들기

	svn copy trunk tags/release-0.1
	svn commit

# merge하기
	#리비전을 꼭 적을 것
	#TIP: 현재 branch의 버전에서 merge할 branch의 revision번호를
	      확인하고 merge할 branch의 revision번호가 더 높다면
	      merge한다.
	svn merge -r 6:HEAD http://localhost/svn/svntest/trunk

# 충돌 해결하기
	#되돌리기
	svn revert -R .

# Byond Compare 설정하기
	FIXME:

# 리비전 키워드

- NUMBER:      리비전 번호
- HEAD:        저장소의 마지막 리비전
- BASE:        작업 사본을 꺼내온 리비전
- { DATE }:    리비전이 시작하는 시각
- COMMITTED:   BASE 이전에 마지막 커밋된 리비전
- PREV:        COMMITTED 의 직전 리비전




