# 프로그램 설치

	sudo apt-get install apache2
	sudo apt-get install subversion libapache2-svn


# 저장소로 사용할 디렉토리 생성 (/home/svn/)

	cd /home
	sudo mkdir svn
	sudo chown $USERID:$USERID svn


# 저장소 생성 및 초기화

	sudo svnadmin create /home/svn/svntest
	sudo chown www-data /home/svn/ -R
	sudo chmod u+w /home/svn/svntest/ -R


# 파일 수정

	sudo gedit /etc/apache2/mods-enabled/dav_svn.conf


# 다음 내용을 하단에 복사

	<Location /svn>
	DAV svn 
	SVNParentPath /home/svn/
	AuthType Basic
	AuthName "Your repository name"
	AuthUserFile /etc/svn_passwd
	Require valid-user
	</Location>


# 계정 추가

	#입력후 계정과 비번이 출력된다.
	sudo htpasswd -nd [svn고유계정]

	#출력된 계정 정보를 아래 파일에 추가한다.
	vi /etc/svn_passwd

# 확인

웹브라우저에서 `http://localhost/svn/svntest`로 접속한다.

또는 

터미널에서 `svn info http://localhost/svn/svntest`를 실행한다.
