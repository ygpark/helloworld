# gitolite

## STEP1. git 계정 만들기

	sudo adduser \
	    --system \
	    --shell /bin/bash \
	    --gecos 'git version control' \
	    --group \
	    --disabled-password \
	    --home /srv/git \
	    git


## STEP2. gitolite 설치하기
	
1. gitolite 다운로드

	git clone git://github.com/sitaramc/gitolite


2. gitolite 설치

	sudo mkdir /opt/gitolite
	sudo gitolite/install -to /opt/gitolite
	sudo ln -s /opt/gitolite /usr/local/
	sudo ln -s /opt/gitolite/gitolite /usr/local/bin/gitolite


3. public key 생성(id_rsa.pub)

	ssh-keygen -trsa


4. git 계정에 gitolite 설치

	sudo su git

	# 3에서 만든 id_rsa.pub키의 경로를 입력한다.
	gitolite setup -pk {$KEY_PATH}/id_rsa.pub

	# 사용자 계정으로 전환
	exit

5. key 등록하기

	git clone <git@서버>:gitolite-admin.git

`keydir/`에 public키를 등록하고 `conf/gitolite.conf`에 사용자를 등록한다.

