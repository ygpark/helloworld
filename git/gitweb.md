# gitweb 설치

/usr/share/gitweb에 설치된다.

    sudo apt-get install gitweb
    sudo apt-get install highlight
    

# 권한 설정

gitolite의 경로로 가서 권한을 바꿔준다.

    $ sudo vi $(gitolite경로)/.gitolite.rc
    UMASK => 0027


gitweb의 설정중 Gitolite를 설치해 변경된 경로를 변경

    $ sudo vi /usr/share/gitweb/gitweb.cgi
    our $projectroot = "$(gitolite경로)/repositories/";
    our $projects_list = "$(gitolite경로)/projects.list";

gitweb 설정파일 안의 경로도 변경한다.

    $ sudo vi /etc/gitweb.conf
    $projectroot = "$(gitolite경로)/repositories/";
    $projects_list = "$(gitolite경로)/projects.list";

아파치 재시작

    $ sudo service apache2 restart

# 구문강조 기능 (색깔)

구문강조를 위해 `highlight`의 설치가 필요하다.

    sudo apt-get install highlight

gitweb의 설정에 추가한다.

    $ sudo vim /etc/gitweb.conf

    # change $projectroot to /home/git/repositories
    # change $projects_list to /home/git/projects.list
    # Add Highlighting at the end
    $feature{'highlight'}{'default'} = [1];

    # URL을 보여주는 옵션이다.
    # 아니면 gitolite의 repository의 각 저장소에 cloneurl 파일을 만들어서 넣어준다.
    # <출력예:> URL git clone git@192.168.0.38:/h100/u-boot.git
    #
    @git_base_url_list[0]="git clone git\@192.168.0.38:$project";

    # description 가로길이 늘리기. 기본값 25
    $projects_list_description_width=100;





