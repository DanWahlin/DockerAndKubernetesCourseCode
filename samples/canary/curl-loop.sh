for ((i=1;i<=20;i++)); 
do
    curl -s "http://localhost" | grep "<title>.*</title>"
    sleep .5s
done