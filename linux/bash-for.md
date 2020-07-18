# Bash-for

# 예제1

	for i in $(ls)
	do
		echo $i
	done

# 예제2

	for i in hello world "hello world"
	do
		echo $i
	done

	#
	# OUTPUT:
	# 
	# hello
	# world
	# hello world

# 예제3

	MYSQL_PWD=""
	MYSQL_PWD_CONFIRM=""

	for i in {1..3}
	do
		read -s -p "Please input password: " MYSQL_PWD
		echo ""

		read -s -p "Please input password to confirm: " MYSQL_PWD_CONFIRM
		echo ""

		if [ "$MYSQL_PWD" != "$MYSQL_PWD_CONFIRM" ]
		then
			echo "$PROG_NAME: Bad password"
		else
			echo "$PROG_NAME: Good password."
			break;
		fi  
	done

