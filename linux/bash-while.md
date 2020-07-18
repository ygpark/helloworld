# bash-while

#예제1

	echo "aa \nbb" | while read line 
	do 
		echo $line 
	done

#예제1

	while read line 
	do 
		echo $line 
	done < <(echo "a\nb")
