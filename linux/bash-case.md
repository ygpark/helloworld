# Bash-case


# 예제
	CHOICE=""
	read -p "input (1~3): " CHOICE
	echo

	case $CHOICE in
	1)
	echo "first"
	;;

	2)
	echo "second"
	;;

	3)
	echo "third"
	;;
	*)
	echo "???"
	;;
	esac


